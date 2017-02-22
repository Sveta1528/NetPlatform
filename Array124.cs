using PT4;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;

namespace PT4Tasks
{
    public class MyTask: PT
    {
        public static void Solve()
        {
            Task("Array124");
            int k = GetInt() - 1;
            var arr = GetEnumerableInt().ToList();
            int n = arr.Count;
           
            List<List<int>> series = new List<List<int>>();
            int i = 0;
            while (i!=n)
            {
                List<int> temp = new List<int> {arr[i]};
                while (i != n-1 && arr[i]==arr[i+1])
                {
                    temp.Add(arr[i+1]);
                    i++;
                }
                series.Add(temp);
                i++;
            }

            int m = series.Count;

            if (k < m)
            {
                List<int> temp = series[k];
                series[k] = series[m-1];
                series[m-1] = temp;
            }


            for (int j=0; j<m; j++)
                for (int l = 0; l < series[j].Count; l++)
                    Put(series[j][l]);




        }
    }
}
