using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Text.RegularExpressions;


namespace PT4Tasks
{
    public class MyTask: PT
    {
        public static void Solve()
        {
            Task("String55");

            string str = GetString();
            var res = Regex.Matches(str, @"\b\w+\b").Cast<Match>()
                            .Select(m => m.Value).ToList().OrderByDescending(s => s.Length).First();
            Put(res);
        }
    }
}
