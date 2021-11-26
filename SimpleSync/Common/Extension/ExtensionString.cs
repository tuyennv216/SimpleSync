using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSync
{
	public static class ExtensionString
	{
		public static string ExtendDotRight(this string str, int width)
		{
			var dot = "...";
			if (str.Length <= width) return str;
			return str.Substring(0, width - dot.Length) + dot;
		}
		public static string ExtendDotMiddle(this string str, int width)
		{
			var dot = "...";
			if (str.Length <= width) return str;
			var sideLeft = (width - dot.Length) / 2;
			var sideRight = width - sideLeft - dot.Length;
			return str.Substring(0, sideLeft) + dot + str.Substring(str.Length - sideRight);
		}
		public static string ExtendDotLeft(this string str, int width)
		{
			var dot = "...";
			if (str.Length <= width) return str;
			return dot + str.Substring(str.Length - (width - dot.Length));
		}

		public static string PadAround(this string str, int width, char paddingChar = ' ')
		{
			if (str.Length >= width) return str;
			var paddingStr = new string(paddingChar, (width - str.Length) / 2);
			var isOdd = (width - str.Length) % 2 == 1;
			return paddingStr + str + paddingStr + (isOdd ? paddingChar : "");
		}
	}
}
