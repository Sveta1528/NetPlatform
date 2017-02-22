using PT4;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace PT4Tasks
{
    public class MyTask: PT
    {
        public static void Solve()
        {
            Task("String61");
            string str = GetString();
            var m = Regex.Matches(str, @"(\w+[!-?]*[0-1]*)+");
            int sz = m.Count - 2;
            if (sz == 0)
                Put(((char)92).ToString());
            else Put(m[sz].ToString());

        }
    }
}
