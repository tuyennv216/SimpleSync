using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSync
{
	public class SystemIO
	{
		private static SystemIO instance = new SystemIO();
		public static SystemIO i => instance;
		private SystemIO() { }

		public Task<string> GetBackupFilePath(string backupPath, string file)
		{
			var fileName = System.IO.Path.GetFileName(file);
			return Task.FromResult(System.IO.Path.Combine(backupPath, fileName));
		}

		public async Task<byte[]> GetFileMd5(string file)
		{
			using (var md5 = MD5.Create())
			{
				using (var stream = System.IO.File.OpenRead(file))
				{
					return await md5.ComputeHashAsync(stream);
				}
			}
		}

		public async Task CopyFile(string source, string destination)
		{
			using (Stream sourceStream = File.OpenRead(source))
			{
				using (Stream destinationStream = File.Create(destination))
				{
					await sourceStream.CopyToAsync(destinationStream);
				}
			}
		}
	}
}
