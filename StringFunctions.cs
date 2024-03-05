using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUtils
{
	public class StringFunctions
	{
		static public string RepeatString(string s, int n)
		{
			string output = "";
			for (int i = 0; i < n; i++)
			{
				output += s;
			}
			return output;
		}
	}
}
