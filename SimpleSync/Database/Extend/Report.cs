namespace SimpleSync
{
	public struct Report
	{
		public struct Folder
		{
			public const string All = @"select id, path, level, savepath, enable from folder order by path, savepath";
			public const string Total = @"select count(1) from folder";
			public const string Enable = @"select id, path, level, savepath from folder where enable = 1 order by path, savepath";
			public const string Disable = @"select id, path, level, savepath from folder where enable = 0 order by path, savepath";
			public const string Oneway = @"select id, path, level, savepath, enable from folder where twoway = 0 order by path, savepath";
			public const string Twoway = @"select id, path, level, savepath, enable from folder where twoway = 1 order by path, savepath";
		}

		public struct File
		{
			public const string Total = @"select count(1) from file";
			public const string Waiting = @"select count(1) from file where backup = 0";
			public const string Done = @"select count(1) from file where backup = 1";
		}

		public struct Version
		{
			public const string Current = @"select name from version order by name desc limit 1";
		}
	}
}
