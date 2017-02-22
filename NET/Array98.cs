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
            Task("Array98");

            var arr = GetEnumerableInt().ToList();
            arr.RemoveAll(item => (arr.FindAll(x => x == item)).Count < 3);
            Put(arr.Count);
            foreach (int elem in arr)
                Put(elem);
        }
    }
}
