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
            Task("Array44");
            var arr = GetEnumerableInt().ToArray();
            int n = arr.Length;
            int i = 0, j = 0;

            while (i != n)
            {
                j = 0;
                while (j!=n && (i == j || arr[i] != arr[j]))  j++;
                if (j != n) break;
                i++;
            }

            i++; j++;
            Put(i,j);
            


        }
    }
}
