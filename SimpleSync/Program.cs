using System;
using System.Threading.Tasks;

namespace SimpleSync
{
	class Program
	{
		static async Task Main(string[] args)
		{
			using (var simpleSync = new SimpleSync())
			{
				await simpleSync.Initial();
				await simpleSync.Run();
			}
		}
	}
}
