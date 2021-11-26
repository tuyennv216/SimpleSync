using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSync.Flow
{
	public class Initial
	{
		private static Initial instance = new Initial();
		public static Initial i => instance;
		private Initial() { }
		public async Task InitialTable(SqliteConnection connect)
		{
			var hasVersion = await Database.i.RunScalar(connect, Query.Version.CheckExists);
			if (Setting.i.ClearDatabaseAtStart && (App.IsDevelopment || (long)hasVersion == 0))
			{
				var dropFile = Database.i.RunNonQuery(connect, Query.File.DropTable);
				var dropFolder = Database.i.RunNonQuery(connect, Query.Folder.DropTable);
				var dropVersion = Database.i.RunNonQuery(connect, Query.Version.DropTable);

				await Task.WhenAll(dropFile, dropFolder, dropVersion);

				var createFile = Database.i.RunNonQuery(connect, Query.File.CreateTable);
				var createFolder = Database.i.RunNonQuery(connect, Query.Folder.CreateTable);
				var createVersion = Database.i.RunNonQuery(connect, Query.Version.CreateTable);

				await Task.WhenAll(createFile, createFolder, createVersion);

				var insertVersion = Database.i.RunNonQueryParams(connect, Query.Version.InsertOrUpdate, new[]{
					new KeyValuePair<string, object>("name", App.Version),
				});

				await Task.WhenAll(insertVersion);
			}
			else
			{
				var currentVersion = await Database.i.RunScalar(connect, Query.Version.GetVersion);
				if (currentVersion != null && App.Version.CompareTo(currentVersion.ToString()) > 0)
				{
					var insertVersion = Database.i.RunNonQueryParams(connect, Query.Version.InsertOrUpdate, new[]{
						new KeyValuePair<string, object>("name", App.Version),
					});
					var updateDatabase = Migration.UpdateFromVersion(currentVersion.ToString());
					await Task.WhenAll(insertVersion, updateDatabase);
				}
			}
		}

	}
}
