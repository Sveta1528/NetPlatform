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
        //     cmt - строковый комментарий

        public static void Solve()
        {
            Task("LinqObj81");
            var splB = System.IO.File.ReadLines(GetString(), Encoding.Default);
            var splD = System.IO.File.ReadLines(GetString(), Encoding.Default);
            var splE = System.IO.File.ReadLines(GetString(), Encoding.Default);
            var fname = GetString();

            var arrB = splB.Select(s =>
            {
                var sp = s.Split(' ');
                return new { articul =sp[0], country = sp[1], category = sp[2]};
            });

            var arrD = splD.Select(s =>
            {
                var sp = s.Split(' ');
                return new { name = sp[0], articul = sp[1], price = int.Parse(sp[2])};
            });

            var arrE = splE.Select(s =>
            {
                var sp = s.Split(' ');
                return new { name = sp[0], code = int.Parse(sp[1]), articul = sp[2]};
            });

            var result = arrB.OrderBy(x => x.country).GroupBy(x => x.country).Select(x =>
            {
                var articules = x.Select(e => e.articul);
                var articulesE = arrE.Select(e => e.articul);
                var articulesD = arrD.Select(e => e.articul);
                var cnt = arrE.Count(e => articules.Contains(e.articul));

                var totalprice = articules.Where(a => articulesE.Contains(a)).Where(a => articulesD.Contains(a)).Select(a =>
                {
                    var prices = arrD.Where(cc => cc.articul == a).Select(cc => new {name = cc.name, price = cc.price});
                    var tp = prices.Select(cc =>
                    {
                        var c = arrE.Where(ccc => ccc.articul == a).Count(ccc => ccc.name == cc.name);
                        return cc.price * c;
                    });

                    return tp.Sum();
                }).Sum();
                return cnt > 0 ? String.Format("{0} {1} {2}", x.First().country, cnt, totalprice) : "";
            }).Where(x => x != "");

            File.WriteAllLines(fname, result, Encoding.Default);

        }
    }
}
