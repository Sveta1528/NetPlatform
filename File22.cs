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
        public static void Solve()
        {
            Task("File22");

            var sourceStream = new System.IO.BinaryReader(System.IO.File.Open(GetString(), System.IO.FileMode.Open));
            BinaryWriter resultWriter = new BinaryWriter(new FileStream(GetString(), FileMode.Create));

            int count = (int) sourceStream.BaseStream.Length/sizeof(double);
            resultWriter.Write(count);

            sourceStream.BaseStream.Seek((count-1) * sizeof(double), SeekOrigin.Begin);
            double first = sourceStream.ReadDouble();
            sourceStream.BaseStream.Seek((count-2) * sizeof(double), SeekOrigin.Begin);
            double second = sourceStream.ReadDouble();

            for (int i = count-3; i >= 0; i--)
            {
                sourceStream.BaseStream.Seek(i*sizeof(double), SeekOrigin.Begin);
                double third = sourceStream.ReadDouble();
                if ((second > third & second > first) || (second < third & second < first))
                    resultWriter.Write(i+2);
                first = second;
                second = third;
            }
            resultWriter.Write(1);
            
            sourceStream.Close();
            resultWriter.Close();

        }
    }
}
