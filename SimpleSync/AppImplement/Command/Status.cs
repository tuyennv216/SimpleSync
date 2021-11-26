using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimpleSync.Flow.Command
{
	public class Status : ICommand
	{
		private static Status instance = new Status();
		public static Status i => instance;
		private Status() { }

		public async Task<Runcode> Start(Match match, Dictionary<string, string> data)
		{
			var topic = match.Groups[Commands.Groups.Table].Value;
			var subject = match.Groups[Commands.Groups.Type].Value;
			var commandText = GetCommandText(topic, subject);
			if (commandText == null)
			{
				Flow.Help.i.DisplayGuide();
			}
			else
			{
				var table = new DisplayTable.Table();
				table.Title = "Status at " + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
				using (var connect = Database.i.newConnect)
				{
					connect.Open();
					using (var view = await Database.i.RunReader(connect, commandText))
					{
						// column width
						var header = new string[view.FieldCount];
						for (var i = 0; i < view.FieldCount; i++) header[i] = view.GetName(i);
						table.Header = DisplayTable.Builder.i.BuildRow(header);

						// data
						var dataBody = new List<string[]>();
						while (view.Read())
						{
							var dataRow = new string[view.FieldCount];
							for (var i = 0; i < view.FieldCount; i++) dataRow[i] = view.GetString(i);
							dataBody.Add(dataRow);
							table.Rows = DisplayTable.Builder.i.BuildBody(dataBody.ToArray());
						}
					}
					connect.Close();
				}

				var width = Console.WindowWidth;
				var tableContent = DisplayTable.Render.i.RenderTable(table, width);
				Console.WriteLine(tableContent);
			}
			return Runcode.Success;
		}

		public string GetCommandText(string table, string type) => (table, type) switch
		{
			(Topic.Folder, Subject.Empty) => Report.Folder.All,
			(Topic.Folder, Subject.All) => Report.Folder.All,
			(Topic.Folder, Subject.Total) => Report.Folder.Total,
			(Topic.Folder, Subject.Enable) => Report.Folder.Enable,
			(Topic.Folder, Subject.Disable) => Report.Folder.Disable,
			(Topic.Folder, Subject.Oneway) => Report.Folder.Oneway,
			(Topic.Folder, Subject.Twoway) => Report.Folder.Twoway,

			(Topic.File, Subject.Empty) => Report.File.Total,
			(Topic.File, Subject.Total) => Report.File.Total,
			(Topic.File, Subject.Wating) => Report.File.Waiting,
			(Topic.File, Subject.Done) => Report.File.Done,

			(Topic.Version, Subject.Empty) => Report.Version.Current,
			(Topic.Version, Subject.Current) => Report.Version.Current,

			_ => null,
		};

		public struct Topic
		{
			public const string Folder = "folder";
			public const string File = "file";
			public const string Version = "version";
		}

		public struct Subject
		{
			public const string All = "all";
			public const string Total = "total";
			public const string Enable = "enable";
			public const string Disable = "disable";
			public const string Oneway = "oneway";
			public const string Twoway = "twoway";
			public const string Wating = "waiting";
			public const string Done = "done";
			public const string Current = "current";
			public const string Empty = "";
		}

		public void Dispose()
		{
		}
	}
}
