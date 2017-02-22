using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask: PT
    {
        public static void Solve()
        {
            Task("Matrix33");

            int m = PT.GetInt(), n = PT.GetInt();
            var matrix = Enumerable.Range(0, m).Select(x => PT.GetEnumerableInt(n).ToArray()).ToArray();

            int res = -1, neg, pos;
            for (int j = 0; j < n; j++)
            {
                neg = 0; pos = 0;
                for (int i = 0; i < m; i++)
                {
                    if (matrix[i][j] > 0) pos++;
                    if (matrix[i][j] < 0) neg++;
                }
                if (neg == pos) res = j;

            }
            Put(res + 1);

        }
    }
}
