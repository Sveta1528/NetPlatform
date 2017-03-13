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
            var sourceReader = new System.IO.BinaryReader(File.OpenRead(filename));
            BinaryWriter resultWriter = new BinaryWriter(new FileStream("file35.tst", FileMode.Create));

            var count = 50 - (int)(sourceReader.BaseStream.Length/sizeof(int));

            for (int i=0; i<count; i++)
                resultWriter.Write(0);

            while (sourceReader.BaseStream.Position < sourceReader.BaseStream.Length)
            {
                int a = sourceReader.ReadInt32();
                resultWriter.Write(a);
            }

            sourceReader.Close();
            resultWriter.Close();

            File.Delete(filename);
            File.Move("file35.tst", filename);
        }
    }
}
