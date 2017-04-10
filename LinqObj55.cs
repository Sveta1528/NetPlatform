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

        class EGE
        {
            public int maths { get; set; }
            public int russian { get; set; }
            public int informatics { get; set; }
            public string name { get; set; }
            public string initials { get; set; }
            public int schoolnumber { get; set; }

            public EGE(int m, int r, int i, string n, string init, int sn)
            {
                maths = m;
                russian = r;
                informatics = i;
                name = n;
                initials = init;
                schoolnumber = sn;
            }
        }

        public static void Solve()
        {
            Task("LinqObj55");

            var spl = System.IO.File.ReadAllLines(GetString(), Encoding.Default);
            var fname = GetString();
            var arr = spl.Select(s =>
            {
                var sp = s.Split(' ');
                return new EGE(int.Parse(sp[0]), int.Parse(sp[1]), int.Parse(sp[2]), sp[3], sp[4], int.Parse(sp[5]));
            }).ToArray();
            var result = arr.Where(x => x.maths >= 50 && x.russian >= 50 && x.informatics >= 50).OrderBy(x => x.name).ThenBy(x => x.initials).Select(x =>
            {
                var sum = x.maths + x.informatics + x.russian;
                return String.Format("{0} {1} {2} {3}", x.name, x.initials, x.schoolnumber, sum);
            }).ToArray();
            
            File.WriteAllLines(fname, result.DefaultIfEmpty("Требуемые учащиеся не найдены").ToArray(), Encoding.Default);
        }
    }
}
