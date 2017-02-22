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
            Task("Array35");
            var arr = GetEnumerableDouble().ToList();
            int n = arr.Count;
            var list = new List<double>();
            if (arr[0] > arr[1]) list.Add(arr[0]);
            if (arr[n - 1] > arr[n - 2]) list.Add(arr[n - 1]);
            for (int i = 1; i < n-1; i++)
                if (arr[i] > arr[i - 1] && arr[i] > arr[i + 1]) list.Add(arr[i]);
            Put(list.Min());

        }
    }
}
