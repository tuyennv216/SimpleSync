using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSync.Query
{
	public struct Version
	{
		// Definition
		public const string CreateTable = @"create table if not exists version (name text primary key);";
		public const string DropTable = @"drop table if exists version;";

		// Query
		public const string GetVersion = @"select name from version order by name desc limit 1;";
		public const string MatchVersion = @"select exists (select 1 from version where name = $name limit 1);";
		public const string CheckExists = @"select exists (select 1 from sqlite_master where type='table' and name='version' limit 1);";

		// Manipulation
		public const string InsertOrUpdate = @"insert or ignore into version (name) values ($name);";
	}
}
