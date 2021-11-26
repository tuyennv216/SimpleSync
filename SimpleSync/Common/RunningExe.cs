using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSync
{
	public class RunningExe
	{
		private static RunningExe instance = new RunningExe();
		public static RunningExe i => instance;
		private RunningExe()
		{
			Path = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
			Info = new System.IO.FileInfo(Path);
			Name = System.IO.Path.GetFileNameWithoutExtension(Path);
			FullName = System.IO.Path.GetFileName(Path);
			Folder = Info.DirectoryName;
		}

		private readonly string Path;
		private readonly FileInfo Info;

		public readonly string Name;
		public readonly string FullName;
		public readonly string Folder;
	}
}
