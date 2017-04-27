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
            Task("File82");

            var input = GetString();
            var output = GetString();

            FileInfo fileIn = new FileInfo(input);
            BinaryReader reader = new BinaryReader(fileIn.OpenRead(), Encoding.ASCII);

            FileInfo fileOut = new FileInfo(output);
            BinaryWriter writer = new BinaryWriter(fileOut.OpenWrite(), Encoding.ASCII);

            var len = 0;
            for (; reader.PeekChar() > -1; ++len)
                reader.ReadDouble();

            reader.Close();
            reader.Dispose();

            reader = new BinaryReader(fileIn.OpenRead(), Encoding.ASCII);
            len = (int)Math.Sqrt(len);

            for (int i = 0; i < len; ++i)
                for (int j = 0; j < len; ++j)
                    if (Math.Abs(i - j) <= 1)
                        writer.Write(reader.ReadDouble());
                    else
                        reader.ReadDouble();

            reader.Close();
            writer.Close();
        }
    }
}
