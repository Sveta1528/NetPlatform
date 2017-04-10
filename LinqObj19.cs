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

        class Enrollee
        {
            public string name { get; set; }
            public int year { get; set; }
            public int school { get; set; }

            public Enrollee(string n, int y, int s)
            {
                name = n;
                year = y;
                school = s;
            }

        }


        public static void Solve()
        {
            Task("LinqObj19");
            var spl = System.IO.File.ReadAllLines(GetString(), Encoding.Default);
            var filename = GetString();
            var arr = spl.Select(s =>
            {
                var sp = s.Split(' ');
                return new Enrollee(sp[0], int.Parse(sp[1]), int.Parse(sp[2]));
            });
            arr.Show();
            var result = arr.OrderBy(x=>x.school).GroupBy(x => x.school).Select(x =>
            {
                var e = x.First();
                return e.school + " " + x.Count() + " " + e.name;
            }).ToArray();

            File.WriteAllLines(filename, result.ToArray(), Encoding.Default);
        }
    }
}
