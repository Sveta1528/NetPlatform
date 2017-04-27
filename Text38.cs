using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace PT4Tasks
{
    public class MyTask: PT
    {
        private static int k;

        public static void Solve()
        {
            Task("Text38");

            int k = GetInt();
            var reader = new StreamReader(GetString(), Encoding.Default);
            var writer = new StreamWriter(new FileStream(GetString(), FileMode.Create), Encoding.Default);
            var acc = "";

            while (!reader.EndOfStream)
            {
                var currentString = reader.ReadLine().TrimEnd();
                if (currentString.Equals(""))
                {
                    writer.WriteLine(acc);
                    writer.WriteLine("");
                    acc = currentString;
                }
                else
                    acc = acc == "" ? currentString : acc + ' ' + currentString;
                while (acc.Length > k)
                {
                    int lastInd = acc.LastIndexOf(' ', k, k + 1);
                    int spaceIndex = lastInd != -1 ? lastInd : k;
                    var res = acc.Substring(0, spaceIndex);
                    writer.WriteLine(res);
                    int taiLength = acc[spaceIndex] == ' ' ? acc.Length - res.Length - 1 : acc.Length - res.Length;
                    int tailInd = acc[spaceIndex] == ' ' ? spaceIndex + 1 : spaceIndex;
                    acc = acc.Substring(tailInd, taiLength);
                }
            }
            if (acc != "")
                writer.WriteLine(acc);
            writer.Close();
            reader.Close();
        }

    }
    
}
