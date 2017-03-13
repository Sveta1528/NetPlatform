using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask: PT
    {
        static void find_comma(string s, ref string left, ref string right)
        {
            int bracket = 0;
            int pos = 0;
            while (pos < s.Length)
            {
                if (s[pos] == '(')
                {
                    ++bracket;
                    if (pos != 0) left+='(';
                }
                else if (s[pos] == ')')
                {
                    --bracket;
                    left += ')';
                }
                else if (s[pos] == ',' && bracket == 1) break;
                else left += s[pos];
                pos++;
            }
            pos++;
            right = s.Substring(pos, s.Length-pos);

        }

        static bool Recur(string s)
        {
            string or = "";
            string and = "";
            if (s.Length > 1) or = s.Substring(0, 2);
            if (s.Length > 2) and = s.Substring(0, 3);

               if (or == "Or")
               {
                   s = s.Remove(0, 2);
                   string left = "", right = "";
                   find_comma(s,ref left,ref right);
                   return Recur(left) || Recur(right);
               }
            else if (and == "And")
            {
                s = s.Remove(0, 3);
                string left = "", right = "";
                find_comma(s, ref left, ref right);
                return Recur(left) & Recur(right);
            }
            else return s[0] == 'T' ? true : false; 
        }
        
        public static void Solve()
        {
            Task("Recur21");
            Put(Recur(GetString()));
        }
    }
}
