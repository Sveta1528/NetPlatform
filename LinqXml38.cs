using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;

namespace PT4Tasks
{
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

        static int count_parrent(XElement x)
        {
            int k = 0;
            while (x != null)
            {
                x = x.Parent;
                k++;
            }
            return k;
        }
        
        public static void Solve()
        {
            Task("LinqXml38");
            string name = GetString();
            XDocument d = XDocument.Load(name);
            var a = d.Root.Descendants().OrderBy(x=> count_parrent(x));
            string add = "";
           var y = a.First();
            y.Name = y.Name;
            XElement cur;
            foreach (var x in a)
            {
                cur = x.Parent;
                add = "";
                while (cur!=null)
                {
                    add=cur.Name+"-"+add;
                    cur = cur.Parent;

                }
                x.Name = add+x.Name;
            }

            d.Save(name);
        }
    }
}
