using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask: PT
    {
        static System.IO.StreamWriter finalWriter;
        static StringBuilder str;
        static int n;

        static void Step(int k, int sum, char c)
        {
            str[k] = c;

            if (n == k)
            {
                if (sum == 0) finalWriter.WriteLine(str);
                return;
            }

            if (c!='A') Step(k + 1, sum + 1, 'A');
            if (c!='B') Step(k + 1, sum, 'B');
            if (c!='C') Step(k + 1, sum - 1, 'C');
        }

        public static void Solve()
        {
            Task("Recur30");

            n = GetInt();
            str = new StringBuilder(n);

            str.Append('D', n + 1);
            finalWriter = new System.IO.StreamWriter(GetString());

            Step(0, 0, 'D');

            finalWriter.Close();

        }
    }
}
