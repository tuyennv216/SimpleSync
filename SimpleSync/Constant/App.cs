using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSync
{
	public struct App
	{
		public const string Version = VersionHistory.v100;
#if DEBUG
		public const string Mode = Runmode.Development;
#else
		public const string Mode = Runmode.Product;
#endif
		public static bool IsProduct => Mode == Runmode.Product;
		public static bool IsDevelopment => Mode == Runmode.Development;
	}
}
