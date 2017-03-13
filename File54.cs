using PT4;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask: PT
    {
        public static void Solve()
        {
            Task("File54");

            var resultWriter = new System.IO.BinaryWriter(System.IO.File.Open(GetString(), System.IO.FileMode.OpenOrCreate));
            var sourceStream = new System.IO.BinaryReader(System.IO.File.Open(GetString(), System.IO.FileMode.Open));

            int count = sourceStream.ReadInt32();
            int sumLength = 0;
            for (int i = 1; i <= count; i++)
            {
                sourceStream.BaseStream.Seek(i*sizeof(int),SeekOrigin.Begin);
                int length = sourceStream.ReadInt32();
                sumLength += length;
                double sum = 0;
                for (int j = 1; j <= length; j++)
                {
                    sourceStream.BaseStream.Seek((count+1)*sizeof(int)+(sumLength)*sizeof(int)-j*sizeof(int), SeekOrigin.Begin);
                    sum+= sourceStream.ReadInt32();
                }
                resultWriter.Write(sum/length);
            }
            sourceStream.Close();
            resultWriter.Close();

        }
    }
}
