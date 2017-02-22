using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace PT4Tasks
{
    public class MyTask: PT
    {
        public static void Solve()
        {
            Task("String43");

            string str = GetString();
            var m = Regex.Matches(str, @"\w*[À]+\w*\s*");
            Put(m.Count);
        }
    }
}
