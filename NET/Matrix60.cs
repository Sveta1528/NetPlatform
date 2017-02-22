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
            Task("Matrix60");

            int m = PT.GetInt(), n = PT.GetInt();
            var matrix = Enumerable.Range(0, m).Select(x => PT.GetEnumerableDouble(n).ToList()).ToList();
            double temp;
            for (int i=0; i<m; i++)
                for (int j = 0; j < n/2; j++)
                {
                    temp = matrix[i][j];
                    matrix[i][j] = matrix[i][n - j - 1];
                    matrix[i][n - j - 1] = temp;
                }

            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                    Put(matrix[i][j]);

        }
    }
}
