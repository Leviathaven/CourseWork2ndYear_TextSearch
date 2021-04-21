using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace CourseWorkTextSearch
{
    class JaroWinkler
    {        
        public static double GetJaroDistance(string s1, string s2)
        {            
            if (s1 == s2)
                return 1.0;            
            int len1 = s1.Length,
                len2 = s2.Length;
            if (len1 == 0 || len2 == 0)
                return 0.0;            
            int max_dist = (int)Math.Floor((double)
                            Math.Max(len1, len2) / 2) - 1;          
            int match = 0;           
            int[] hash_s1 = new int[s1.Length];
            int[] hash_s2 = new int[s2.Length];           
            for (int i = 0; i < len1; i++)
            {               
                for (int j = Math.Max(0, i - max_dist); j < Math.Min(len2, i + max_dist + 1); j++)
                    if (s1[i] == s2[j] &&
                        hash_s2[j] == 0)
                    {
                        hash_s1[i] = 1;
                        hash_s2[j] = 1;
                        match++;
                        break;
                    }
            }           
            if (match == 0)
                return 0.0;          
            double t = 0;
            int point = 0;           
            for (int i = 0; i < len1; i++)
                if (hash_s1[i] == 1)
                {                   
                    while (hash_s2[point] == 0)
                        point++;

                    if (s1[i] != s2[point++])
                        t++;
                }
            t /= 2;            
            return (((double)match) / ((double)len1)
                    + ((double)match) / ((double)len2)
                    + ((double)match - t) / ((double)match))
                / 3.0;
        }
        
        public static double GetJaroWinklerDistance(string s1, string s2)
        {
            double jaro_dist = GetJaroDistance(s1, s2);
            
            if (jaro_dist > 0.7)
            {                
                int prefix = 0;
                for (int i = 0; i < Math.Min(s1.Length,
                                            s2.Length); i++)
                {                   
                    if (s1[i] == s2[i])
                        prefix++;                   
                    else
                        break;
                }                
                prefix = Math.Min(4, prefix);                
                jaro_dist += 0.1 * prefix * (1 - jaro_dist);
            }
            return jaro_dist;
        }
    }
}

