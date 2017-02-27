using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask: PT
    {
        static void splitText(params object[] obj)
        {
            
            var sourceStream = new System.IO.StreamReader(obj[0].ToString(), Encoding.Default);
            var finalStream = new System.IO.StreamWriter(obj[2].ToString(), true, Encoding.Default);
            var finalStream2 = new System.IO.StreamWriter(obj[3].ToString(), true, Encoding.Default);

            int k = (int) obj[1];
            string cur = " ";

            while (--k >= 0 && (cur = sourceStream.ReadLine()) != null)
                finalStream.WriteLine(cur);

            while ((cur = sourceStream.ReadLine()) != null)
                finalStream2.WriteLine(cur);

            sourceStream.Close();
            finalStream.Close();
            finalStream2.Close();
        }


        public static void Solve()
        {
            Task("Param54");


            splitText(GetString(), GetInt(), GetString(), GetString());
        }
    }
}
