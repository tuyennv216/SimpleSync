using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSync
{
	public static class ExtensionConvert
	{
		public static int ToInt(this string str)
		{
			var parse = str.Trim();
			var outindex = -1;
			for (var i = 0; i < parse.Length; i++)
				if (parse[i] < '0' || parse[i] > '9') { outindex = i; break; }
			if (outindex != -1) parse = parse.Substring(0, outindex);

			var result = 0;
			int.TryParse(parse, out result);
			return result;
		}
	}
}
