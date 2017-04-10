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
        class D
        {
            public int price { get; set; }
            public string name { get; set; }
            public string articul { get; set; }

            public D(int p, string n, string a)
            {
                price = p;
                name = n;
                articul = a;
            }
        }

        class E
        {
            public string articul { get; set; }
            public string name { get; set; }
            public int code { get; set; }


            public E(string a, string n, int c)
            {
                articul = a;
                name = n;
                code = c;
            }
        }

        public static void Solve()
        {
            Task("LinqObj80");

            var splD = System.IO.File.ReadAllLines(GetString(), Encoding.Default);
            var splE = System.IO.File.ReadAllLines(GetString(), Encoding.Default);
            var fname = GetString();

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

            var result = arrD.OrderBy(x => x.name).ThenBy(x => x.articul).Select(x =>
            {
                return String.Format("{0} {1} {2}", x.name, x.articul, x.price * arrE.Where(e => e.name == x.name).Count(e => e.articul == x.articul));
            }).ToArray();

            File.WriteAllLines(fname, result.ToArray(), Encoding.Default);

        }
    }
}
