using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSync
{
	public class Validator
	{
		private Validator() { }
		public class Param
		{
			public static readonly Func<string, bool> Folder = name =>
			{
				if (name == null || name.Length == 0) return false;
				if (System.IO.Directory.Exists(name) == false) throw new ArgumentException(Message.IO.FolderNotFound(name));

				return true;
			};

			public static readonly Func<string, bool> Level = number =>
			{
				int.TryParse(number, out int level);
				if (level <= 0) throw new ArgumentException(Message.Number.GreaterThan(number, 0));

				return true;
			};

			public static readonly Func<string, bool> SavePath = name =>
			{
				if (name == null || name.Length == 0) return false;
				if (System.IO.Directory.Exists(name) == false) throw new ArgumentException(Message.IO.FolderNotFound(name));

				return true;
			};
		}

		public class Unique
		{
			public static readonly Func<string, string, bool> FolderSavePath = (folder, savePath) =>
			{
				var folderFullPath = System.IO.Path.GetFullPath(folder);
				var saveFullPath = System.IO.Path.GetFullPath(savePath);

				var isSameFolder = folderFullPath.CompareTo(saveFullPath) == 0;
				var isContain = folderFullPath.StartsWith(saveFullPath) || saveFullPath.StartsWith(folderFullPath);

				if (isSameFolder) throw new ArgumentException(Message.IO.FolderAreSame(folderFullPath, saveFullPath));
				if (isContain) throw new ArgumentException(Message.IO.FolderAreContain(folderFullPath, saveFullPath));

				return true;
			};
		}
	}
}
