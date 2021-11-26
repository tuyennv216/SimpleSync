using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimpleSync
{
	public interface ICommand : IDisposable
	{
		public Task<Runcode> Start(Match match, Dictionary<string, string> data);
	}
}
