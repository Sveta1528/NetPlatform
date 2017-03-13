using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask: PT
    {
        private static int k;

        public static void Solve()
        {
            Task("Text38");

            k = GetInt();
            var sourceStream = new System.IO.StreamReader(GetString(), Encoding.Default);
            var finalStream = new System.IO.StreamWriter(GetString(), true, Encoding.Default);
            string cur;
            string fw;
            StringBuilder sb = new StringBuilder();
            while ((cur = sourceStream.ReadLine()) != null)
            {
                for (int i=0; i<cur.Length; i++)
                {
                    sb.Append(cur[i]);
                    
                }
                //finalStream.WriteLine();
            }

            sourceStream.Close();
            finalStream.Close();

        }
    }
}
