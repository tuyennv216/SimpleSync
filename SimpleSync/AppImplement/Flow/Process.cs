using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace SimpleSync.Flow
{
	public class Process
	{
		private static Process instance = new Process();
		public static Process i => instance;
		private Process() { }
		public async Task ProcessFolder(SqliteConnection connect, string folderPath, int level, string backupPath)
		{
			var flow = new List<Task>();

			System.IO.Directory.CreateDirectory(backupPath);

			// save current folder

			var insertFolder = Database.i.RunNonQueryParams(connect, Query.Folder.InsertOrUpdate, new[]
			{
				new KeyValuePair<string, object>("path", folderPath),
				new KeyValuePair<string, object>("level", level),
				new KeyValuePair<string, object>("savepath", backupPath),
			});

			flow.Add(insertFolder);

			// sub files

			var files = System.IO.Directory.EnumerateFiles(folderPath);
			var batchFile = files.Take(Setting.i.BatchFileSize);
			var batchFileIndex = 0;
			while (batchFile.Any() == true)
			{
				var parallelFile = batchFile;
				var fileRun = Task.Factory.StartNew(() =>
				{
					Parallel.ForEach(parallelFile, new ParallelOptions { MaxDegreeOfParallelism = Setting.i.NumberOfParallel }, file => ProcessFile(connect, backupPath, file).Wait());
				});

				flow.Add(fileRun);

				batchFileIndex++;
				batchFile = files.Skip(batchFileIndex * Setting.i.BatchFileSize).Take(Setting.i.BatchFileSize);
			}

			await Task.WhenAll(flow);

			// sub folders

			if (level - 1 > 0)
			{
				var folders = System.IO.Directory.EnumerateDirectories(folderPath);
				var batchFolder = folders.Take(Setting.i.BatchFolderSize);
				var batchFolderIndex = 0;
				while (batchFolder.Any() == true)
				{
					var folderRun = Task.Factory.StartNew(() =>
					{
						Parallel.ForEach(batchFolder, new ParallelOptions { }, async folder =>
						{
							var folderName = new System.IO.DirectoryInfo(folder).Name;
							var backupSubPath = System.IO.Path.Combine(backupPath, folderName);
							await ProcessFolder(connect, folder, level - 1, backupSubPath);
						});
					});

					flow.Add(folderRun);

					batchFolderIndex++;
					batchFolder = folders.Skip(batchFolderIndex * Setting.i.BatchFolderSize).Take(Setting.i.BatchFolderSize);
				}
			}

			await Task.WhenAll(flow);
		}

		public async Task ProcessFile(SqliteConnection connect, string backupPath, string file)
		{
			var fileMd5 = await SystemIO.i.GetFileMd5(file);

			var isFileExists = await Database.i.RunScalarParams(connect, Query.File.ExistsMd5, new[]
			{
				new KeyValuePair<string, object>("md5", fileMd5),
			});

			if (isFileExists != null && (long)isFileExists == 0)
			{
				var fileInfo = new System.IO.FileInfo(file);
				var extend = new
				{
					Name = fileInfo.Name,
					Extension = fileInfo.Extension,
					Length = fileInfo.Length
				};

				var fileInsert = Database.i.RunNonQueryParams(connect, Query.File.InsertOrUpdate, new[]
				{
					new KeyValuePair<string, object>("md5", fileMd5 ),
					new KeyValuePair<string, object>("info", JsonSerializer.Serialize(extend)),
				});

				var backupFile = await SystemIO.i.GetBackupFilePath(backupPath, file);
				var fileCopy = SystemIO.i.CopyFile(file, backupFile);

				await Task.WhenAll(fileInsert, fileCopy);

				var fileBackup = Database.i.RunNonQueryParams(connect, Query.File.UpdateBackup, new[]
				{
					new KeyValuePair<string, object>("md5", fileMd5 ),
				});

				await Task.WhenAll(fileBackup);
			}
		}

		public async Task ProcessArguments()
		{
			var (commandType, commandMatch, command) = Commands.i.GetCommand(Arguments.i.LineInput);
			var commandData = Arguments.i.Args;

			await command.Start(commandMatch, commandData);
		}
	}
}
