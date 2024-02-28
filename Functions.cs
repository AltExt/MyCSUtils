using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MyUtils
{
	public class ConsoleFunctions
	{
		/// <summary>
		/// Queries the user for an integer value between /min/ and /max/
		/// Prompts the user with prompt message
		/// If the user enters an invalid value then error message is displayed and user is queried again
		/// </summary>
		/// <param name="min"></param>
		/// <param name="max"></param>
		/// <returns> int </returns>
		static public int GetIntFromUserWithBounds(int min, int max, string promptMessage = "", string errorMessage = "")
		{
			while (true)
			{
				Console.WriteLine(promptMessage);
				int selection = Convert.ToInt32(Console.ReadLine());
				if (selection >= min && selection <= max) return selection;
				else Console.WriteLine(errorMessage);
			}
		}

		/// <summary>
		/// Queries the user for an integer value between /min/ and /max/
		/// Prompts the user to choose between min and max
		/// If the user enters an invalid value, an error message is shown and the user is queried again
		/// </summary>
		/// <param name="min"></param>
		/// <param name="max"></param>
		/// <returns> int </returns>
		static public int GetIntFromUserWithBounds(int min, int max)
		{
			ConsoleColor bgInitialColor = Console.BackgroundColor;
			ConsoleColor fgInitialColor = Console.ForegroundColor;

			while (true)
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
		}
	}
}
