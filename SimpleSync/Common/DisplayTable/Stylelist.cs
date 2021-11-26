using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSync.DisplayTable
{
	public class Stylelist
	{
		private static Stylelist instance = new Stylelist();
		public static Stylelist i => instance;
		private Stylelist() { }

		public static Style DefaultStyle = new Style
		{
			Align = Align.None,
			Weight = Weight.None,
			Color = Color.None,
			ExtendDot = ExtendDot.None,
		};

		public void ApplyStyle(Cell cell)
		{
			MakeExtendDot(cell);
			MakeAlign(cell);
		}

		public void MakeAlign(Cell cell)
		{
			switch (cell.Style.Align)
			{
				case Align.Left:
					cell.Content = cell.Content.PadRight(cell.Width, ' ');
					break;
				case Align.Center:
					cell.Content = cell.Content.PadAround(cell.Width, ' ');
					break;
				case Align.Right:
					cell.Content = cell.Content.PadLeft(cell.Width, ' ');
					break;
				case Align.None:
					cell.Content = cell.Content.PadLeft(cell.Width, ' ');
					break;
			}
		}

		public void MakeExtendDot(Cell cell)
		{
			switch (cell.Style.ExtendDot)
			{
				case ExtendDot.Left:
					cell.Content = cell.Content.ExtendDotLeft(cell.Width);
					break;
				case ExtendDot.Middle:
					cell.Content = cell.Content.ExtendDotMiddle(cell.Width);
					break;
				case ExtendDot.Right:
					cell.Content = cell.Content.ExtendDotRight(cell.Width);
					break;
				case ExtendDot.None:
					cell.Content = cell.Content.ExtendDotRight(cell.Width);
					break;
			}
		}
	}

	public static class StyleExtension
	{
		public static Style Include(this Style style, params Style[] others)
		{
			foreach (var item in others)
			{
				if (item != null)
				{
					if (style.Align == Align.None) style.Align = item.Align;
					if (style.Weight == Weight.None) style.Weight = item.Weight;
					if (style.Color == Color.None) style.Color = item.Color;
					if (style.ExtendDot == ExtendDot.None) style.ExtendDot = item.ExtendDot;
				}
			}
			return style;
		}

		public static Table ApplyWidth(this Table table, int width)
		{
			int usedWidth = 0, usedColumn = 0, autoWidth;
			var header = table.Header;

			width -= header.Cells.Length + 1;
			for (var i = 0; i < header.Cells.Length; i++)
			{
				var cell = header.Cells[i];

				cell.Width = Custom.i.GetCustomWidth(cell.Content);
				cell.Style = Custom.i.GetCustomStyle(cell.Content);

				if (cell.Width != 0)
				{
					usedColumn++;
					usedWidth += cell.Width;
				}
			}

			autoWidth = (width - usedWidth) / (header.Cells.Length - usedColumn);

			for (var i = 0; i < table.Rows.Length; i++)
			{
				var row = table.Rows[i];
				for (var j = 0; j < row.Cells.Length; j++)
				{
					if (header.Cells[j].Width == 0)
					{
						header.Cells[j].Width = autoWidth;
						row.Cells[j].Width = autoWidth;
					}
					else
					{
						row.Cells[j].Width = header.Cells[j].Width;
					}

					row.Cells[j].Style.Include(header.Cells[j].Style);
				}
			}
			return table;
		}

	}
}
