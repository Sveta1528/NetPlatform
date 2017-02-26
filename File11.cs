using PT4;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.IO;

namespace PT4Tasks
{
    public class MyTask: PT
    {
        public static void Solve()
        {
            Task("File11");

            var sourceStream = new System.IO.BinaryReader(System.IO.File.Open(GetString(), System.IO.FileMode.Open));
            BinaryWriter oddWriter = new BinaryWriter(new FileStream(GetString(), FileMode.Create));
            BinaryWriter evenWriter = new BinaryWriter(new FileStream(GetString(), FileMode.Create));

            int pos = 0;
            int lg = (int) sourceStream.BaseStream.Length;
            bool flag = true;

            while (pos < lg)
            {
                double a = sourceStream.ReadDouble();
                if (flag)
                    oddWriter.Write(a);
                else
                    evenWriter.Write(a);
                flag = !flag;
                pos += sizeof(double);
            }

            sourceStream.Close();
            oddWriter.Close();
            evenWriter.Close();
            

        }
    }
}
