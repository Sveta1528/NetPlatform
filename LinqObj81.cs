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
        class B
        {


            public string articul { get; set; }
            public string country { get; set; }
            public string category { get; set; }

            public B(string a, string c, string cat)
            {
                articul = a;
                country = c;
                category = cat;
            }
        }

        class D
        {

            public string name { get; set; }
            public string articul { get; set; }
            public int price { get; set; }

            public D(string n, string a, int p)
            {
                price = p;
                name = n;
                articul = a;
            }
        }

        class E
        {

            public string name { get; set; }
            public int code { get; set; }
            public string articul { get; set; }


            public E(string n, int c, string a)
            {
                articul = a;
                name = n;
                code = c;
            }
        }

        public static void Solve()
        {
            Task("LinqObj81");
            var splB = System.IO.File.ReadAllLines(GetString(), Encoding.Default);
            var splD = System.IO.File.ReadAllLines(GetString(), Encoding.Default);
            var splE = System.IO.File.ReadAllLines(GetString(), Encoding.Default);
            var fname = GetString();

            var arrB = splB.Select(s =>
            {
                var sp = s.Split(' ');
                return new B(sp[0], sp[1], sp[2]);
            }).ToArray();

            var arrD = splD.Select(s =>
            {
                var sp = s.Split(' ');
                return new D(sp[0], sp[1], int.Parse(sp[2]));
            }).ToArray();

            var arrE = splE.Select(s =>
            {
                var sp = s.Split(' ');
                return new E(sp[0], int.Parse(sp[1]), sp[2]);
            }).ToArray();

            var result = arrB.OrderBy(x => x.country).GroupBy(x => x.country).Select(x =>
            {
                var articules = x.Select(e => e.articul);
                var articulesE = arrE.Select(e => e.articul);
                var articulesD = arrD.Select(e => e.articul);
                var cnt = arrE.Count(e => articules.Contains(e.articul));
                var totalprice = articules.Where(a => articulesE.Contains(a)).Where(a => articulesD.Contains(a)).Select(a =>
                {
                    var prices = arrD.Where(cc => cc.articul == a).Select(cc => new Tuple<string, int>(cc.name, cc.price)).ToArray();
                    var tp = prices.Select(cc =>
                    {
                        var c = arrE.Where(ccc => ccc.articul == a).Count(ccc => ccc.name == cc.Item1);
                        return cc.Item2 * c;
                    });

                    return tp.Sum();
                }).Sum();
                return cnt > 0 ? String.Format("{0} {1} {2}", x.First().country, cnt, totalprice) : "";
            }).Where(x => x != "").ToArray();
            File.WriteAllLines(fname, result.ToArray(), Encoding.Default);

        }
    }
}
