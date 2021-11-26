using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimpleSync.Flow.Command
{
	public class Manipulation : ICommand
	{
		private static Manipulation instance = new Manipulation();
		public static Manipulation i => instance;
		private Manipulation() { }
		public Task<Runcode> Start(Match match, Dictionary<string, string> data)
		{
			var action = match.Groups[Commands.Groups.Action].Value;
			switch (action)
			{
				case ActionName.Get:
					break;
				case ActionName.Save:
				case ActionName.Insert:
					break;
				case ActionName.Update:
					break;
				case ActionName.Delete:
					break;
				default:
					break;
			}

			return Task.FromResult(Runcode.Success);
		}

		public struct ActionName
		{
			public const string Get = "get";
			public const string Save = "save";
			public const string Insert = "insert";
			public const string Update = "update";
			public const string Delete = "delete";
		}

		public void Dispose()
		{
		}
	}
}
