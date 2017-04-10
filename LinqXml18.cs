using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Xml.Linq;

namespace PT4Tasks
{
    using System.Xml;

    public class MyTask: PT
    {
        // При решении задач группы LinqXml доступны следующие
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
            Task("LinqXml18");
            string name = GetString();
            XDocument d = XDocument.Load(name);
            var arr = d.Descendants().Attributes().Distinct().GroupBy(x=>x.Name).Select(x =>
            {
                var n = x.First().Name;
                var values = x.OrderBy(y=>y.Value).Select(y => y.Value);
                return new Tuple<XName,IEnumerable<string>>(n,values);
            });


            foreach (var elem in arr)
            {

                Put(elem.Item1.ToString());
                foreach (var x in elem.Item2)
                    Put(x.ToString());
            }

            }
    }
}
