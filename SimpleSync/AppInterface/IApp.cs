using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSync
{
	public interface IApp : IDisposable
	{
		public Task<Runcode> Initial();
		public Task<Runcode> Run();
		public Task<Runcode> Status();
		public Task<Runcode> Guide();
	}
}
