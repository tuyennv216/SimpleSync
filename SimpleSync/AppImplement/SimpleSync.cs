using System.Threading.Tasks;

namespace SimpleSync
{
	public class SimpleSync : IApp
	{
		public async Task<Runcode> Initial()
		{
			using (var connect = Database.i.newConnect)
			{
				connect.Open();
				await Flow.Initial.i.InitialTable(connect);
				connect.Close();
				return Runcode.Success;
			}
		}

		public async Task<Runcode> Run()
		{
			await Flow.Process.i.ProcessArguments();
			return Runcode.Success;
		}

		public Task<Runcode> Guide()
		{
			Flow.Help.i.DisplayGuide();
			return Task.FromResult(Runcode.Success);
		}

		public Task<Runcode> Status()
		{
			Flow.Help.i.DisplayStatus();
			return Task.FromResult(Runcode.Success);
		}

		public void Dispose()
		{

		}

	}
}
