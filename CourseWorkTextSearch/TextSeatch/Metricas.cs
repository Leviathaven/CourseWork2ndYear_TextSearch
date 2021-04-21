using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWorkTextSearch
{
    class Metricas
    {
        public static int GetHammingDistance(string s, string t)
        {
            if (s.Length == t.Length)
            {
                int distance = s.ToCharArray().Zip(t.ToCharArray(), (c1, c2) => new { c1, c2 }).Count(m => m.c1 != m.c2);
                return distance;
            }
            else return -1;           
        }
        public static int GetDamerauLevenshteinDistance(string s, string t)
        {
            if (s == t)
                return 0;

            int str_len = s.Length;
            int pat_len = t.Length;
            if (str_len == 0 || pat_len == 0)
            return str_len == 0 ? pat_len : str_len;

            var matrix = new int[str_len + 1, pat_len + 1];

            for (int i = 1; i <= str_len; i++)
            {
                matrix[i, 0] = i;
                for (int j = 1; j <= pat_len; j++)
                {
                    int cost = t[j - 1] == s[i - 1] ? 0 : 1;
                    if (i == 1)
                        matrix[0, j] = j;

                    var vals = new int[] {
                    matrix[i - 1, j] + 1,
                    matrix[i, j - 1] + 1,
                    matrix[i - 1, j - 1] + cost
                };
                    matrix[i, j] = vals.Min();
                    if (i > 1 && j > 1 && s[i - 1] == t[j - 2] && s[i - 2] == t[j - 1])
                        matrix[i, j] = Math.Min(matrix[i, j], matrix[i - 2, j - 2] + cost);
                }
            }
            return matrix[str_len, pat_len];
        }
        public static int GetLevenshteinDistance(string s, string t)
        {
            int n = s.Length;
            int m = t.Length;
            int[,] matrix = new int[n + 1, m + 1];           
            if (n == 0)
            {
                return m;
            }
            if (m == 0)
            {
                return n;
            }           
            for (int i = 0; i <= n; matrix[i, 0] = i++)
            {
            }
            for (int j = 0; j <= m; matrix[0, j] = j++)
            {
            }            
            for (int i = 1; i <= n; i++)
            {               
                for (int j = 1; j <= m; j++)
                {                    
                    int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;
                    matrix[i, j] = Math.Min(
                        Math.Min(matrix[i - 1, j] + 1, matrix[i, j - 1] + 1),
                        matrix[i - 1, j - 1] + cost);
                }
            }
            return matrix[n, m];
        }
        public static double GetDiceMatch(string string1, string string2)
        {
            if (string.IsNullOrEmpty(string1) || string.IsNullOrEmpty(string2))
                return 0;

            if (string1 == string2)
                return 1;

            int strlen1 = string1.Length;
            int strlen2 = string2.Length;

            if (strlen1 < 2 || strlen2 < 2)
                return 0;

            int length1 = strlen1 - 1;
            int length2 = strlen2 - 1;

            double matches = 0;
            int i = 0;
            int j = 0;

            while (i <= length1 && j <= length2)
            {
                char a = string1[i];
                char b = string2[j];

                if (a == b)
                    matches++;

                i++;
                j++;
            }

            return (2 * matches) / (Convert.ToDouble (strlen1 + strlen2));
        }

    }
}
