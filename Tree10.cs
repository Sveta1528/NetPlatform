using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask: PT
    {
        static private int[] count = new int[10];
        static private int k = 0;

        static void Recur(Node r)
        {
            if (r == null) return;
            k += 1;
            count[k] += 1;

            Recur(r.Left);
            Recur(r.Right);

            k -= 1;
        }

        public static void Solve()
        {
            Task("Tree10");
            var root = GetNode();
            Recur(root);
            int i = 1;
            while (count[i]!=0 && i<count.Length)
            {
                Put(count[i]);
                i++;
            }

        }
    }
}
