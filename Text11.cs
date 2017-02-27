using PT4;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask: PT
    {
        public static void Solve()
        {
            Task("Text11");

            string filename = GetString();
            var sourceStream = new System.IO.StreamReader(filename, Encoding.Default);
            var finalStream = new System.IO.StreamWriter("text11.tst", true, Encoding.Default);
            string s = "";
            while ((s = sourceStream.ReadLine()) != null)
            {
                finalStream.WriteLine(s);
                if (s=="")
                    finalStream.WriteLine();
            }
            sourceStream.Close();
            finalStream.Close();
            System.IO.File.Delete(filename);
            System.IO.File.Move("text11.tst", filename);

        }
    }
}
