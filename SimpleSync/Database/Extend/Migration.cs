using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSync
{
	public class Migration
	{
		public static async Task<bool> UpdateFromVersion(string currentVersion)
		{
			var allVersion = VersionHistory.AllVersion;
			var allUpdate = new List<string>();
			var getUpdate = false;
			for (var i = 0; i < allVersion.Length; i++)
			{
				var version = allVersion[i];
				if (version == currentVersion) getUpdate = true;
				if (getUpdate == true)
				{
					allUpdate.Add(File.newUpdate.GetValueOrDefault(version) ?? "");
					allUpdate.Add(Folder.newUpdate.GetValueOrDefault(version) ?? "");
					allUpdate.Add(Version.newUpdate.GetValueOrDefault(version) ?? "");
				}
			}

			var commandText = string.Join(";\n", allUpdate);

			using (var connect = Database.i.newConnect)
			{
				connect.Open();
				var updateLatestCommand = connect.CreateCommand();
				updateLatestCommand.CommandText = commandText;
				var result = await updateLatestCommand.ExecuteNonQueryAsync();

				connect.Close();
				return result > 0;
			}
		}

		public struct File
		{
			public static readonly Dictionary<string, string> newUpdate = new Dictionary<string, string>
			{
				{ VersionHistory.v100, "select 1" }
			};
		}

		public struct Folder
		{
			public static readonly Dictionary<string, string> newUpdate = new Dictionary<string, string>
			{
				{ VersionHistory.v100, "select 2" }
			};
		}

		public struct Version
		{
			public static readonly Dictionary<string, string> newUpdate = new Dictionary<string, string>
			{
				{ VersionHistory.v100, "select 3" }
			};
		}
	}
}
