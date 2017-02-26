using PT4;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask: PT
    {
        public static void Solve()
        {
            Task("File72");
            var sourceStream = new System.IO.StreamReader(System.IO.File.Open(GetString(), System.IO.FileMode.Open));
            DateTime res = new DateTime();
            string s;
            while ((s = sourceStream.ReadLine()) != null)
                foreach (var elem in s.Split(new char[] {' ', 'P'}, StringSplitOptions.RemoveEmptyEntries))
                {
                    var date = DateTime.Parse(elem);
                    if (date.Month > 8 && date.Month < 12 && date > res)
                        res = date;
                }
            sourceStream.Close();
            Put(res == new DateTime() ? "" : res.ToString("dd/MM/yyyy").Replace('.', '/'));
        }
    }
}
