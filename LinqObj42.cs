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
            Task("LinqObj42");

            var spl = System.IO.File.ReadLines(GetString(), Encoding.Default);
            var fname = GetString();
            var arr = spl.Select(s =>
            {
                var sp = s.Split(' ');
                return new { petrol = int.Parse(sp[0]), name = sp[1], street = sp[2], price =int.Parse(sp[3])};
            });

            var result = arr.OrderBy(x => x.street).GroupBy(x => x.street).Select(x =>
            {
                var str = x.First().street;
                var price92 = x.Where(cur => cur.petrol == 92).Select(cur => cur.price).DefaultIfEmpty(0).Min();
                var price95 = x.Where(cur => cur.petrol == 95).Select(cur => cur.price).DefaultIfEmpty(0).Min();
                var price98 = x.Where(cur => cur.petrol == 98).Select(cur => cur.price).DefaultIfEmpty(0).Min();

                return String.Format("{0} {1} {2} {3}", str, price92, price95, price98);
            });
            File.WriteAllLines(fname, result, Encoding.Default);
        }
    }
}
