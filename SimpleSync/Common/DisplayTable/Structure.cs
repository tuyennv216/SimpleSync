using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSync.DisplayTable
{
	public class Table
	{
		public string Title;
		public Row Header;
		public Row[] Rows;

		public Row this[int index]
		{
			get => Rows[index];
			set => Rows[index] = value;
		}
		public Cell this[int rowIndex, int columnIndex]
		{
			get => Rows[rowIndex][columnIndex];
			set => Rows[rowIndex][columnIndex] = value;
		}
	}

	public class Row
	{
		public Style Style;
		public Cell[] Cells;
		public Cell this[int index]
		{
			get => Cells[index];
			set => Cells[index] = value;
		}
	}

	public class Cell
	{
		public int Width;
		public string Content;
		public Style Style = new Style();
	}

	public class Style
	{
		public Align Align = Align.None;
		public Weight Weight = Weight.None;
		public Color Color = Color.None;
		public ExtendDot ExtendDot = ExtendDot.None;
	}

}
