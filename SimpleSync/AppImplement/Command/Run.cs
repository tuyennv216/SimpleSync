using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimpleSync.Flow.Command
{
	public class Run : ICommand
	{
		private static Run instance = new Run();
		public static Run i => instance;
		private Run() { }
		public async Task<Runcode> Start(Match match, Dictionary<string, string> data)
		{
			var folder = Arguments.i.ValidateOrDefault(Arguments.Names.Folder, Validator.Param.Folder);
			var level = Arguments.i.ValidateOrDefault(Arguments.Names.Level, Validator.Param.Level);
			var savepath = Arguments.i.ValidateOrDefault(Arguments.Names.SavePath, Validator.Param.SavePath, Setting.i.BackupFolder);

			await Task.WhenAll(folder, level, savepath);

			Validator.Unique.FolderSavePath(folder.Result, savepath.Result);

			using (var connect = Database.i.newConnect)
			{
				connect.Open();
				await Flow.Process.i.ProcessFolder(connect, folder.Result, level.Result.ToInt(), savepath.Result);
				connect.Close();
			}

			return Runcode.Success;
		}

		public void Dispose()
		{
		}
	}
}
