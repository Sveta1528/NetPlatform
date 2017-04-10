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

        class A
        {


            public string street { get; set; }
            public int year { get; set; }
            public int code { get; set; }

            public A(string st, int y, int c)
            {
                street = st;
                year = y;
                code = c;
            }
        }

        class C
        {


            public int code { get; set; }
            public int perc { get; set; }
            public string name { get; set; }

            public C(int c, int p, string n)
            {
                code = c;
                perc = p;
                name = n;
            }
        }

        class D
        {

            public int price { get; set; }
            public string articul { get; set; }
            public string name { get; set; }

            public D(int p, string a, string n)
            {
                price = p;
                articul = a;
                name = n;
            }
        }

        class E
        {

            public string name { get; set; }
            public string articul { get; set; }
            public int code { get; set; }

            public E(string n, string a, int c)
            {
                articul = a;
                name = n;
                code = c;
            }
        }

        public static void Solve()
        {
            Task("LinqObj96");

            var splA = System.IO.File.ReadAllLines(GetString(), Encoding.Default);
            var splC = System.IO.File.ReadAllLines(GetString(), Encoding.Default);
            var splD = System.IO.File.ReadAllLines(GetString(), Encoding.Default);
            var splE = System.IO.File.ReadAllLines(GetString(), Encoding.Default);
            var fname = GetString();

            var arrA = splA.Select(s =>
            {
                var sp = s.Split(' ');
                return new A(sp[0], int.Parse(sp[1]), int.Parse(sp[2]));
            }).ToArray();

            var arrC = splC.Select(s =>
            {
                var sp = s.Split(' ');
                return new C(int.Parse(sp[0]), int.Parse(sp[1]), sp[2]);
            }).ToArray();

            var arrD = splD.Select(s =>
            {
                var sp = s.Split(' ');
                return new D(int.Parse(sp[0]), sp[1], sp[2]);
            }).ToArray();

            var arrE = splE.Select(s =>
            {
                var sp = s.Split(' ');
                return new E(sp[0], sp[1], int.Parse(sp[2]));
            }).ToArray();

            List<string> result = new List<string>();
            foreach (var y in arrA.OrderBy(x => x.year).GroupBy(x => x.year).ToArray())
            {
                var yearCodes = y.Select(x => x.code).ToArray();
                foreach (var shop in arrE.OrderBy(x => x.name).GroupBy(x => x.name).ToArray())
                {
                    var shopCodes = shop.Select(x => x.code).ToArray();
                    var codes = yearCodes.Intersect(shopCodes).ToArray();
                    List<int> codesTovs = new List<int>();
                    foreach (var code in codes)
                    {
                        var perc = arrC.Where(x => x.name == shop.First().name).
                                   Where(x => x.code == code).DefaultIfEmpty(new C(code, 0, shop.First().name)).ToArray().First().perc;

                        var shopCodeArticules = shop.Where(e => e.code == code).Select(e => e.articul).ToArray();

                        var tovs = arrD.Where(x => x.name == shop.First().name).
                                    Where(x => shopCodeArticules.Contains(x.articul)).
                                    Select(x => (perc > 0 ? x.price - Math.Truncate(x.price * 0.01 * perc) : x.price) * 
                                    shop.Where(e => e.code == code).Where(e => e.articul == x.articul).ToArray().Count()).ToArray();

                        codesTovs.Add((int)tovs.Sum());
                    }
                    if (codesTovs.Sum() > 0)
                    {
                        result.Add(y.First().year + " " + shop.First().name + " " + codesTovs.Sum());
                    }

                }
            }
            File.WriteAllLines(fname, result.ToArray(), Encoding.Default);
        }
    }
}
