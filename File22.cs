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

            var sourceReader= new BinaryReader(File.OpenRead(GetString()));
            BinaryWriter resultWriter = new BinaryWriter(new FileStream(GetString(), FileMode.Create));

            int count = (int) sourceReader.BaseStream.Length/sizeof(double);
            resultWriter.Write(count);

            sourceReader.BaseStream.Seek((count-1) * sizeof(double), SeekOrigin.Begin);
            double first = sourceReader.ReadDouble();

            sourceReader.BaseStream.Seek((count-2) * sizeof(double), SeekOrigin.Begin);
            double second = sourceReader.ReadDouble();

            for (int i = count-3; i >= 0; i--)
            {
                sourceReader.BaseStream.Seek(i*sizeof(double), SeekOrigin.Begin);
                double third = sourceReader.ReadDouble();
                if ((second > third & second > first) || (second < third & second < first))
                    resultWriter.Write(i+2);
                first = second;
                second = third;
            }
            resultWriter.Write(1);
            
            sourceReader.Close();
            resultWriter.Close();

        }
    }
}
