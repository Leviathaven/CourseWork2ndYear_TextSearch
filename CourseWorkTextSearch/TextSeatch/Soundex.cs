using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWorkTextSearch
{
    class Soundex
    {
		public static char returnCode (char c) {
				switch (Char.ToLower(c))
				{
				    case 'b':
				    case 'p':
				    case 'б':
				    case 'п':
					    return '1';
				    case 'f':
				    case 'v':
				    case 'ф':
				    case 'в':
					    return '2';
					case 'c':
					case 's':
					case 'k':
				    case 'ж':
				    case 'с':
				    case 'з':
				    case 'х':
					    return '3';
					case 'g':
					case 'j':
				    case 'к':
				    case 'г':
					    return '4';
					case 'q':
					case 'x':
					case 'z':
				    case 'ц':
				    case 'ч':
				    case 'ш':
				    case 'щ':
						return '5';
					case 'd':
					case 't':
				    case 'д':
				    case 'т':
						return '6';
					case 'l':
				    case 'л':
				    case 'й':
					    return '7';
					case 'm':
					case 'n':
				    case 'м':
				    case 'н':
					    return '8';
					case 'r':
				    case 'р':
					    return '9';
					default:
						return '_';
			}
		}
		public static string codeTheWord(string s)
		{
			string result = "";
			result += s[0];
			for (int i = 1; i < s.Length; i++)
			{
				char t = returnCode(s[i]);
				if (t != '_')
				{
					result += t;
				}
			}
			if (result.Length < 3) 
				for (int i = result.Length; i <3; i++)
				{
					result += "0";
				}
			return result;
		}
		public static int checkIfSame(string s, string t)
		{
			if (codeTheWord(s) == codeTheWord(t))
				return 1;
			else return 0;
		}
	}
}
