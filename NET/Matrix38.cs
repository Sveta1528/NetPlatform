using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;

namespace PT4Tasks
{
    public class MyTask: PT
    {
        public static void Solve()
        {
            Task("Matrix38");


            int m = PT.GetInt(), n = PT.GetInt();

            var matrix = Enumerable.Range(0, m).Select(x => PT.GetEnumerableInt(n).ToArray()).ToArray();
            var res = matrix.Select(r => r.GroupBy(x => x).Count() == r.Count()).Where(b => b).Count();
            PT.Put(res);

        }
    }
}
