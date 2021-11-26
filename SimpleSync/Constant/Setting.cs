using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSync
{
	public class Setting
	{
		private static Setting instance = new Setting();
		public static Setting i => instance;
		private Setting() { }

		// Running
		public int BatchFileSize => 1000;
		public int BatchFolderSize => 5;
		public int NumberOfParallel => 6;

		// Folder
		public string BackupFolder => "Backup";

		// Database
		public bool ClearDatabaseAtStart = false;
	}
}
