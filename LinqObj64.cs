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


        public static void Solve()
        {
            Task("LinqObj64");

            var spl = System.IO.File.ReadLines(GetString(), Encoding.Default);
            var fname = GetString();
            var arr = spl.Select(s =>
            {
                var sp = s.Split(' ');
                return new { level = int.Parse(sp[0]), name = sp[1]+" "+sp[2], subject = sp[3], mark = int.Parse(sp[4])};
            });

            var result = arr.Where(e => e.subject == "Информатика").OrderBy(x => x.level).ThenBy(x => x.name).
                GroupBy(x => x.name).Where(x => x.Average(e => e.mark) >= 4.00).Select(x =>
                {
                    return String.Format("{0} {1} {2}", x.First().level, x.First().name,
                        (Math.Round(x.Average(e => e.mark) / 1.00, 2))
                        .ToString("0.00", System.Globalization.CultureInfo.InvariantCulture));
                }).DefaultIfEmpty("Требуемые учащиеся не найдены");

            File.WriteAllLines(fname, result, Encoding.Default);

        }
    }
}
