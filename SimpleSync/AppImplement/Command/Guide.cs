using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimpleSync.Flow.Command
{
	public class Guide : ICommand
	{
		private static Guide instance = new Guide();
		public static Guide i => instance;
		private Guide() { }
		public Task<Runcode> Start(Match match, Dictionary<string, string> data)
		{
			Flow.Help.i.DisplayGuide();
			return Task.FromResult(Runcode.Success);
		}

		public void Dispose()
		{
		}
	}
}
