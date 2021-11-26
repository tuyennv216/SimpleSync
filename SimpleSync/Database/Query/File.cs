using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSync.Query
{
	public struct File
	{
		// Definition
		public const string CreateTable = @"create table if not exists file (md5 text primary key, info text, backup integer default 0);";
		public const string DropTable = @"drop table if exists file;";

		// Query
		public const string ExistsMd5 = @"select exists (select 1 from file where md5 = $md5 limit 1);";

		// Manipulation
		public const string InsertOrUpdate = @"insert into file (md5, info) values ($md5, $info) on conflict(md5) do update set info = $info;";
		public const string UpdateBackup = @"update file set backup = 1 where md5 = $md5;";
	}
}
