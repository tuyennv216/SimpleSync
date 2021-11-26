using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSync.DisplayTable
{
	public class Render
	{
		private static Render instance = new Render();
		public static Render i => instance;
		private Render() { }

		public string RenderTable(Table table, int width)
		{
			table.ApplyWidth(width);

			var lines = new List<string>();
			lines.Add(table.Title);

			lines.Add(RenderBorder(Position.Top, table.Header));

			lines.Add(RenderRow(table.Header));

			lines.Add(RenderBorder(Position.Middle, table.Header));

			lines.Add(RenderBody(table.Rows));

			lines.Add(RenderBorder(Position.Bottom, table.Header));

			return string.Join(Environment.NewLine, lines);
		}

		public string RenderBorder(Position position, Row row)
		{
			string line = "";
			switch (position)
			{
				case Position.Top:
					line = Corner.dd1 + string.Join(Triple.dsb, row.Cells.Select(cell => new string(Unit.dh, cell.Width))) + Corner.dd2;
					break;
				case Position.Middle:
					line = Triple.dsr + string.Join(Cross.ss, row.Cells.Select(cell => new string(Unit.sh, cell.Width))) + Triple.dsl;
					break;
				case Position.Bottom:
					line = Corner.dd4 + string.Join(Triple.dst, row.Cells.Select(cell => new string(Unit.dh, cell.Width))) + Corner.dd3;
					break;
			}
			return line;
		}

		public string RenderBody(Row[] rows, params Style[] styles)
		{
			var line = string.Empty;
			line += string.Join(Environment.NewLine, rows.Select(row => RenderRow(row, styles)));
			return line;
		}

		public string RenderRow(Row row, params Style[] styles)
		{
			var style = row.Style.Include(styles);
			var line = Unit.dv + string.Join(Unit.sv, row.Cells.Select(cell => RenderCell(cell, style))) + Unit.dv;
			return line;
		}

		public string RenderCell(Cell cell, params Style[] styles)
		{
			var style = cell.Style.Include(styles);
			Stylelist.i.ApplyStyle(cell);
			return cell.Content;
		}
	}
}
