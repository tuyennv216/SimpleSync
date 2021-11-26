using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSync.DisplayTable
{
	public class Builder
	{
		private static Builder instance = new Builder();
		public static Builder i => instance;
		private Builder() { }

		public Cell BuildCell(string content)
		{
			Cell cell = new Cell();
			cell.Content = content;
			return cell;
		}

		public Row BuildRow(string[] data)
		{
			var row = new Row();
			row.Cells = data.Select(item => BuildCell(item)).ToArray();
			return row;
		}

		public Row[] BuildBody(string[][] data)
		{
			var body = new Row[data.Length];
			for (var i = 0; i < data.Length; i++) body[i] = BuildRow(data[i]);
			return body;
		}

	}

	public static class BuilderExtension
	{
		public static Cell AddStyle(this Cell cell, Style style)
		{
			cell.Style.Include(style);
			return cell;
		}

		public static Row AddStyle(this Row row, Style style)
		{
			row.Style.Include(style);
			return row;
		}
	}

}
