using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSync.DisplayTable
{
	public struct Unit
	{
		public const char sh = '─';
		public const char sv = '│';
		public const char dh = '═';
		public const char dv = '║';
	}

	public struct Cross
	{
		public const char ss = '┼';
		public const char sd = '╫';
		public const char ds = '╪';
		public const char dd = '╬';
	}

	public struct Corner
	{
		public const char ss1 = '┌';
		public const char ss2 = '┐';
		public const char ss3 = '┘';
		public const char ss4 = '└';
		public const char dd1 = '╔';
		public const char dd2 = '╗';
		public const char dd3 = '╝';
		public const char dd4 = '╚';
		public const char sd1 = '╒';
		public const char sd2 = '╕';
		public const char sd3 = '╛';
		public const char sd4 = '╘';
		public const char ds1 = '╓';
		public const char ds2 = '╖';
		public const char ds3 = '╜';
		public const char ds4 = '╙';
	}

	public struct Triple
	{
		public const char ddr = '╠';
		public const char ddl = '╣';
		public const char ddb = '╦';
		public const char ddt = '╩';
		public const char ssr = '├';
		public const char ssl = '┤';
		public const char ssb = '┬';
		public const char sst = '┴';
		public const char sdr = '╞';
		public const char sdl = '╡';
		public const char sdb = '╤';
		public const char sdt = '╨';
		public const char dsr = '╟';
		public const char dsl = '╢';
		public const char dsb = '╤';
		public const char dst = '╧';
	}

	public enum CellType { None, Border, Data }
	public enum BorderType { None, Corner, Cross, Hoz, Ver, Triangle }
	public enum Position { None, Top, Middle, Bottom, Left, Right }
	public enum Align { None, Left, Center, Right }
	public enum Weight { None, Bold, Italic, Underscore }
	public enum Color { None, Red, Green, Blue, Yellow }
	public enum ExtendDot { None, Left, Middle, Right }
}
