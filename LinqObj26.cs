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
        class Debtor
        {
            public int flat { get; set; }
            public string name { get; set; }
            public double debt { get; set; }

            public Debtor(int f, string n, double d)
            {
                flat = f;
                name = n;
                debt = d;
            }
        }


        public static void Solve()
        {
            Task("LinqObj26");
            var spl = System.IO.File.ReadAllLines(GetString(), Encoding.Default);
            var fname = GetString();
            var arr = spl.Select(s =>
            {
                var sp = s.Split(' ');
                return new Debtor(int.Parse(sp[0]), sp[1], double.Parse(sp[2], System.Globalization.CultureInfo.InvariantCulture));
            }).ToArray();
            var result = arr.Where(x => x.debt > 0).OrderBy(x => (x.flat - 1) / 36 + 1).GroupBy(x => (x.flat - 1) / 36 + 1).Select(x =>
            {
                var porch = (x.First().flat - 1) / 36 + 1;
                var dbt = Math.Round(x.Select(e => e.debt).Average(), 2);
                return String.Format("{0} {1} {2}", porch, x.Count(), dbt.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture));
            }).ToArray();
            File.WriteAllLines(fname, result.ToArray(), Encoding.Default);

        }
    }
}
