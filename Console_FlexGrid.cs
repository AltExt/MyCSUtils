using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUtils
{
	public struct Cell
	{
		public int startX;
		public int startY;
		public int endX;
		public int endY;
	}
	/*	
	 *	drawPos is here
	 *	v
	 *	#===#===#=====#
	 *	|0  |1  |2    |
	 *	#===#===#=====#
	 *	|3  |4  |5    |
	 *	#===#===#=====#
	 *	|6  |7  |8    |
	 *	#===#===#=====#
	 *	|   |   |     @ < height is internal (2)
	 *	|9  |10 |11   @ <
	 *	#===#===#=====# 
	 *	|   |   |X    | < position of startX startY
	 *	|12 |13 |14  X| < position of endX endY
	 *	#@@@#===#=====# 
	 *	 ^^^
	 *	 width is internal (3)
	 *
	 */



	public class Console_FlexGrid
	{
		private List<Cell> Cells;
		private int DrawX { get; set; }
		private int DrawY { get; set; }
		private int Width { get; set; }
		private int Height { get; set; }

		public Console_FlexGrid(int xPos, int yPos, int[] cellWidths, int[] cellHeights)
		{
			Cells = new List<Cell>();
			DrawX = xPos;
			DrawY = yPos;

			Width = cellWidths.Length;
			Height = cellHeights.Length;

			int startYPos = 1;
			for (int i = 0; i < cellHeights.Length; i++)
			{
				int startXPos = 1;
				for (int j = 0; j < cellWidths.Length; j++)
				{
					Cell c = new Cell
					{
						startX = startXPos,
						startY = startYPos
					};
					
					c.endX = c.startX + cellWidths[j] - 1;
					c.endY = c.startY + cellHeights[i] - 1;
					Cells.Add(c);

					startXPos += cellWidths[j] + 1;
				}
				startYPos += cellHeights[i] + 1;
			}
		}

		public void DrawGrid()
		{
			string barsString = "#";
			string cellString = "|";

			int y = DrawY;

			for (int i = 0; i < Width; i++)
			{
				int thisWidth = GetCellAt(i, 0).endX - GetCellAt(i, 0).startX + 1;
				barsString += new string('=', thisWidth) + "#";
				cellString += new string(' ', thisWidth) + "|";
			}

			MyUtils.ConsoleFunctions.WriteStringAtPosition(barsString, DrawX, y);
			y++;

			for (int i = 0; i < Height; i++)
			{
				int thisHeight = GetCellAt(0, i).endY - GetCellAt(0, i).startY + 1;
				for (int j = 0; j < thisHeight; j++)
				{
					MyUtils.ConsoleFunctions.WriteStringAtPosition(cellString, DrawX, y);
					y++;
				}
				MyUtils.ConsoleFunctions.WriteStringAtPosition(barsString, DrawX, y);
				y++;
			}

			Console.CursorLeft = 0;
			Console.CursorTop = y;
		}

		public Cell GetCellAt(int x, int y)
		{
			if (x < 0 || x >= Width || y < 0 || y >= Height) return new Cell();

			return Cells[x + (y * Width)];
		}
	}
}
