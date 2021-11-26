using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimpleSync
{
	public class Commands
	{
		private static Commands instance = new Commands();
		public static Commands i => instance;
		private Commands() { }

		public enum CommandType { Guide, Run, Manipulation, Status, None }

		public (CommandType, Match, ICommand) GetCommand(string input)
		{
			if (CommandPattern.Guide.IsMatch(input))
				return (CommandType.Guide, CommandPattern.Guide.Match(input), Flow.Command.Guide.i);

			else if (CommandPattern.Run.IsMatch(input))
				return (CommandType.Run, CommandPattern.Run.Match(input), Flow.Command.Run.i);

			else if (CommandPattern.Manipulation.IsMatch(input))
				return (CommandType.Manipulation, CommandPattern.Manipulation.Match(input), Flow.Command.Manipulation.i);

			else if (CommandPattern.Status.IsMatch(input))
				return (CommandType.Status, CommandPattern.Status.Match(input), Flow.Command.Status.i);

			return (CommandType.None, null, null);
		}

		public class CommandPattern
		{
			public static readonly Regex Guide = new Regex(@"^(?<action>help|guide)");
			public static readonly Regex Run = new Regex(@"^(?<action>run)");
			public static readonly Regex Manipulation = new Regex(@"^(?<action>get|save|insert|update|delete)\s?(?<table>folder|file)\s?(?<id>\d+)");
			public static readonly Regex Status = new Regex(@"^(?<action>|status|report)\s?(?<table>folder|file)\s?(?<type>.+)");
		}

		public struct Groups
		{
			public const string Action = "action";
			public const string Table = "table";
			public const string Type = "type";
			public const string Id = "id";
		}
	}
}
