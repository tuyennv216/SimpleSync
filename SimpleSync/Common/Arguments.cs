using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimpleSync
{
	public class Arguments
	{
		private static Arguments instance = new Arguments();
		public static Arguments i => instance;

		private string[] rawArgs;
		public Dictionary<string, string> Args;
		public Func<string, string> Get;
		public Func<string, bool> Has;

		private int length = 0;
		public bool IsEmpty => length == 0;
		public string LineInput => rawArgs != null ? string.Join(" ", rawArgs.Skip(1)) : "";
		private Arguments()
		{
			Args = new Dictionary<string, string>();
			Get = key => Args.GetValueOrDefault(key);
			Has = key => Args.ContainsKey(key);

			rawArgs = Environment.GetCommandLineArgs();

			var KeyValue = new Regex(@"^(\-|\\|\/)?(?<name>[^=]+)(=(?<value>.+))?$");
			for (int i = 1; i < rawArgs.Length; i++)
			{
				var option = rawArgs[i];
				if (KeyValue.IsMatch(option))
				{
					var match = KeyValue.Match(option);
					Args.Add(match.Groups["name"].Value, match.Groups["value"].Value);
					length++;
				}
			}
		}

		#region get arguments value
		public Task<string> ValidateOrDefault(string name, Func<string, bool> validater, string defaultValue = "")
		{
			var value = Get!(name);
			if (value == null || validater(value) == false) return Task.FromResult(defaultValue);
			return Task.FromResult(value);
		}

		public Task<string> Validate(string name, Func<string, bool> validater)
		{
			var value = Get!(name);
			if (validater(value) == false) throw new ArgumentException(Message.Param.Invalid(name));
			return Task.FromResult(value);
		}

		public Task<string> GetDefault(string name, string defaultValue)
		{
			var value = Get!(name);
			if (value == null) return Task.FromResult(defaultValue);
			return Task.FromResult(value);
		}

		#endregion

		public struct Names
		{
			public const string Folder = "folder";
			public const string Level = "level";
			public const string SavePath = "savepath";
		}
	}
}
