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
            Task("Text38");

            int k = GetInt();
            var sourceStream = new System.IO.StreamReader(GetString(), Encoding.Default);
            var finalStream = new System.IO.StreamWriter(GetString(), true, Encoding.Default);
            string cur = "", res = " ";
            while ((cur = sourceStream.ReadLine()) != null)
            {
                finalStream.WriteLine();
            }

            sourceStream.Close();
            finalStream.Close();

        }
    }
}
