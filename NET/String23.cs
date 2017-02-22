using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask: PT
    {
        static int toInt(char c)
        {
            return (int)(c - '0');
        }

        public static void Solve()
        {
            Task("String23");

            string str = GetString();
            int res = toInt(str[0]), digit = 0, sign = 1;
            for (int i = 1; i < str.Length; i++)
            {
                if (str[i] == '+') sign = 1;
                else if (str[i] == '-') sign = -1;
                else res = res + sign*toInt(str[i]);
            }
            Put(res);
        }
    }
}
