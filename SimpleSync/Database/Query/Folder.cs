using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSync.Query
{
	public struct Folder
	{
		// Definition
		public const string CreateTable = @"create table if not exists folder (id integer primary key autoincrement, path text, savepath text, level integer default 1, twoway integer default 0, enable integer default 1, unique(path, savepath));";
		public const string DropTable = @"drop table if exists folder;";

		// Query
		public const string ExistsPathSavePath = @"select exists (select 1 from folder where path = $path and savepath = $savepath limit 1);";
		public const string Find = @"select id, path, level, savepath from folder order by path, savepath" +
									" where path like ('%' || $keyword || '%') or savepath like ('%' || $keyword || '%')";

		// Manipulation
		public const string InsertOrUpdate = @"insert into folder (path, level, savepath) values ($path, $level, $savepath) on conflict(path, savepath) do update set level = $level";
		public const string UpdatePath = @"update folder set path = $path, level = $level, savepath = $savepath where id = $id";
		public const string UpdateTwoway = @"update folder set twoway = $twoway id = $id";
		public const string UpdateEnable = @"update folder set enable = $enable where id = $id";
	}
}
