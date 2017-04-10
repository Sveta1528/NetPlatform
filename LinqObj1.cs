using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        // Для чтения набора строк из исходного текстового файла
        // в массив a типа string[] используйте оператор:
        //
        //   a = File.ReadAllLines(GetString(), Encoding.Default);
        //
        // Для записи последовательности s типа IEnumerable<string>
        // в результирующий текстовый файл используйте оператор:
        //
        //   File.WriteAllLines(GetString(), s.ToArray(), Encoding.Default);
        //
        // При решении задач группы LinqObj доступны следующие
        // дополнительные методы расширения, определенные в задачнике:
        //
        //   Show() и Show(cmt) - отладочная печать последовательности,
        //     cmt - строковый комментарий;
        //
        //   Show(e => r) и Show(cmt, e => r) - отладочная печать
        //     значений r, полученных из элементов e последовательности,
        //     cmt - строковый комментарий.

        class Client
        {
            public int code { get; set; }
            public int year { get; set; }
            public int month { get; set; }
            public int duration { get; set; }

            public Client(int c, int y, int m, int d)
            {
                code = c;
                year = y;
                month = m;
                duration = d;
            }

            public override string ToString() => String.Format("{0} {1} {2}", duration, year, month);
        }

        public static void Solve()
        {
            Task("LinqObj1");
            var spl = System.IO.File.ReadAllLines(GetString(), Encoding.Default);
            System.IO.File.WriteAllText(GetString(), spl.Select(s =>
            {
                var sp = s.Split(' ');
                return new Client(int.Parse(sp[0]), int.Parse(sp[1]), int.Parse(sp[2]), int.Parse(sp[3]));
            }).OrderByDescending(x => x.duration).Last().ToString());
        }
    }
}
