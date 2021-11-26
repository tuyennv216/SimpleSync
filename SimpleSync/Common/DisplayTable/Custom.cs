using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSync.DisplayTable
{
	public class Custom
	{
		private static Custom instance = new Custom();
		public static Custom i => instance;

		public int GetCustomWidth(string columnName) => columnName switch
		{
			"id" => 9,
			"level" => 9,
			"enable" => 9,
			_ => 0,
		};

		public Style GetCustomStyle(string columnName) => columnName switch
		{
			"id" => new Style { Align = Align.Center },
			"level" => new Style { Align = Align.Center },
			"enable" => new Style { Align = Align.Center },
			"path" => new Style { ExtendDot = ExtendDot.Middle},
			"savepath" => new Style { ExtendDot = ExtendDot.Middle},
			_ => Stylelist.DefaultStyle,
		};
	}
}
