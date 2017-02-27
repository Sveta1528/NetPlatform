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
            Task("Text54");


            var sourceStream = new System.IO.StreamReader(GetString(), Encoding.Default);
            var finalStream = new System.IO.StreamWriter(GetString(), true, Encoding.Default);
            string s = "";
            HashSet<char> hash=new HashSet<char>();

            while ((s = sourceStream.ReadLine()) != null)
                for (int i = 0; i < s.Length; i++)
                    if (!hash.Contains(s[i]))
                    {
                        hash.Add(s[i]);
                        finalStream.Write(s[i]);
                    }


            sourceStream.Close();
            finalStream.Close();

        }
    }
}
