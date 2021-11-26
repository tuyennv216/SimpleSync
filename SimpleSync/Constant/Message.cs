using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSync
{
	public class Message
	{
		public class Param
		{
			public static readonly Func<string, string> Invalid = name => "Parameter " + name + " is invalid.";
		}

		public class IO
		{
			public static readonly Func<string, string> FileNotFound = name => "File " + name + " is not found.";
			public static readonly Func<string, string> FileNotAvailable = name => "File " + name + " is not available.";
			public static readonly Func<string, string> FolderNotFound = name => "Folder " + name + " is not found.";
			public static readonly Func<string, string> FolderNotAvailable = name => "Folder " + name + " is not available.";
			public static readonly Func<string, string, string> FolderAreSame = (name1, name2) => "Folder " + name1 + " and " + name2 + " are the same";
			public static readonly Func<string, string, string> FolderAreContain = (name1, name2) => "Folder " + name1 + " and " + name2 + " are include each other";
		}

		public class Number
		{
			public static readonly Func<string, long, string> GreaterThan = (name, min) => name + " must be > " + min;
			public static readonly Func<string, long, string> GreaterOrEqualThan = (name, min) => name + " must be >= " + min;
			public static readonly Func<string, long, string> LessThan = (name, min) => name + " must be < " + min;
			public static readonly Func<string, long, string> LessOrEqualThan = (name, min) => name + " must be <= " + min;
		}
	}
}
