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
            var m = Regex.Matches(str, @"([^\\])+");
            Put(m.Count - 2 == 0 ? "\\" : m[m.Count - 2].Value);
            
        }
    }
}
