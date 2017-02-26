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
            Task("File35");

            string filename = GetString();
            var sourceStream = new System.IO.BinaryReader(System.IO.File.Open(filename, System.IO.FileMode.Open));
            BinaryWriter resultWriter = new BinaryWriter(new FileStream("file35.tst", FileMode.Create));

            var count = 50 - (int)(sourceStream.BaseStream.Length/sizeof(int));

            for (int i=0; i<count; i++)
                resultWriter.Write(0);

            while (sourceStream.BaseStream.Position < sourceStream.BaseStream.Length)
            {
                int a = sourceStream.ReadInt32();
                resultWriter.Write(a);
            }

            sourceStream.Close();
            resultWriter.Close();

            File.Delete(filename);
            File.Move("file35.tst", filename);
        }
    }
}
