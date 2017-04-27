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
            Task("LinqObj80");

            var splD = System.IO.File.ReadLines(GetString(), Encoding.Default);
            var splE = System.IO.File.ReadLines(GetString(), Encoding.Default);
            var fname = GetString();

            var arrD = splD.Select(s =>
            {
                var sp = s.Split(' ');
                return new { price = int.Parse(sp[0]), name = sp[1], articul = sp[2]};
            });

            var arrE = splE.Select(s =>
            {
                var sp = s.Split(' ');
                return new { articul = sp[0], name = sp[1], code = int.Parse(sp[2])};
            });

            var result = arrD.OrderBy(x => x.name).ThenBy(x => x.articul).Select(x =>
            {
                return String.Format("{0} {1} {2}", x.name, x.articul, x.price * arrE.Where(e => e.name == x.name).Count(e => e.articul == x.articul));
            });

            File.WriteAllLines(fname, result, Encoding.Default);

        }
    }
}
