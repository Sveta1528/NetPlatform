using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public static void Solve()
        {
            Task("String66");

            string str = GetString();
            string res = "";
            for (int i = 1; i < str.Length; i += 2)
                res += str[i];
            int n = (str.Length - 1) % 2 == 0 ? str.Length - 1 : str.Length - 2;
            for (int i = n; i >= 0; i -= 2)
                res += str[i];
           Put(res);

        }
    }
}
