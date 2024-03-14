using System;
using System.Security.Cryptography;

namespace MyUtils
{
	public class ConsoleFunctions
	{

		static public int GetIntFromUserWithBounds(int min, int max, string promptMessage = "", string errorMessage = "")
		{
			int selection = min - 1;
			while (true)
			{
				Console.WriteLine(promptMessage);
				try
				{
					selection = Convert.ToInt32(Console.ReadLine());
					if (selection >= min && selection <= max) return selection;
					else Console.WriteLine(errorMessage);
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
					Console.WriteLine("Press enter to continue");
					Console.ReadLine();
				}
			}
		}

		static public int GetIntFromUserWithBounds(int min, int max)
		{
			ConsoleColor bgInitialColor = Console.BackgroundColor;
			ConsoleColor fgInitialColor = Console.ForegroundColor;


			while (true)
			{
				try
				{
					Console.WriteLine("Please select a number between " + min.ToString() + " and " + max.ToString());
					int selection = Convert.ToInt32(Console.ReadLine());
					if (selection >= min && selection <= max)
					{
						Console.BackgroundColor = bgInitialColor;
						Console.ForegroundColor = fgInitialColor;
						return selection;
					}
					else
					{
						Console.Write("Erorr, >");
						Console.BackgroundColor = ConsoleColor.Red;
						Console.ForegroundColor = ConsoleColor.Black;
						Console.Write(selection.ToString());
						Console.BackgroundColor = bgInitialColor;
						Console.ForegroundColor = fgInitialColor;
						Console.Write("< is not in the required range (" + min.ToString() + "-" + max.ToString() + ").\n");
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
					Console.WriteLine("Press enter to continue");
					Console.ReadLine();
				}
			}
		}

		static public string GetTextFromUser()
		{
			return GetTextFromUser("Please input some text here: ");
		}

		static public string GetTextFromUser(string prompt)
		{
			Console.WriteLine(prompt);
			return Console.ReadLine();
		}

		static public bool GetBoolFromUser()
		{
			while (true)
			{
				char input = Convert.ToChar(Console.ReadLine()[0]);
				if (input == 'y') return true;
				if (input == 'n') return false;
				Console.WriteLine("Please enter y / n");
			}
		}
		
		static public bool GetBoolFromUser(string prompt)
		{
			while (true)
			{
				Console.WriteLine(prompt);
				char input = Convert.ToChar(Console.ReadLine()[0]);
				if (input == 'y') return true;
				if (input == 'n') return false;
				Console.WriteLine("Please enter y / n");
			}
		}

		static public void WaitForEnter(bool clearScreenAfter = false)
		{
			Console.WriteLine("Press enter to continue:");
			Console.ReadLine();
			if (clearScreenAfter) Console.Clear();
		}

		static public void SetInitialConsoleColors()
		{
			BgInitialColor = Console.BackgroundColor;
			FgInitialColor = Console.ForegroundColor;
		}

		static public void ResetConsoleColors()
		{
			Console.BackgroundColor = BgInitialColor;
			Console.ForegroundColor = FgInitialColor;
		}

		static public void SwapConsoleColors()
		{
			(Console.BackgroundColor, Console.ForegroundColor) = (Console.ForegroundColor, Console.BackgroundColor);
		}

		static public ConsoleKey GetConsoleKeyFromUser()
		{
			return Console.ReadKey(true).Key;
		}

		static public void ClearCurrentLine()
		{
			ClearLineAt(Console.CursorTop);
		}

		static public void ClearLineAt(int line)
		{
			if (line < 0) return;
			Console.SetCursorPosition(0, line);
			Console.Write(new string(' ', Console.WindowWidth));
			Console.SetCursorPosition(0, line);
		}

		static public void WriteStringAtPosition(string s, int x = -1, int y = -1)
		{
			int initialX = Console.CursorLeft;
			int initialY = Console.CursorTop;
			if (x < 0) x = Console.CursorLeft;
			if (y < 0) y = Console.CursorTop;
			Console.SetCursorPosition(x, y);
			Console.Write(s);
			Console.SetCursorPosition(initialX, initialY);
		}

		static public void DrawFixedGrid(int startX, int startY, int rows, int cols, int rowHeight, int colWidth, bool clearScreen = false)
		{
			if (clearScreen) Console.Clear();

			Console.SetCursorPosition(startX, startY);

			string bars = StringFunctions.RepeatString("#" + new string('=', colWidth), cols) + "#";
			string cell = StringFunctions.RepeatString("|" + new string(' ', colWidth), cols) + "|";

			Console.WriteLine(bars);
			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < rowHeight; j++) Console.WriteLine(cell);
				
				Console.WriteLine(bars);
			}
		}

		static public void DrawFlexibleGrid(int startX, int startY, int[] cellWidths, int[] cellHeights, bool clearScreen = false)
		{
			if (cellWidths.Length == 0 || cellHeights.Length == 0) return;

			if (clearScreen) Console.Clear();

			Console.SetCursorPosition(startX, startY);

			string bars = "#";
			string cell = "|";

			for (int i = 0; i < cellWidths.Length; i++)
			{
				bars += new string('=', cellWidths[i]) + "#";
				cell += new string(' ', cellWidths[i]) + "|";
			}

			Console.WriteLine(bars);
			for (int i = 0; i < cellHeights.Length; i++)
			{
				for (int j = 0; j < cellHeights[i]; j++) Console.WriteLine(cell);
				Console.WriteLine(bars);
			}
		}

		static private ConsoleColor BgInitialColor { get; set; } = Console.BackgroundColor;
		static private ConsoleColor FgInitialColor { get; set; } = Console.ForegroundColor;
    }
}
