using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask: PT
    {
        // ѕри решении задач группы LinqBegin доступны следующие
        // дополнительные методы, определенные в задачнике:
        //
        //   GetEnumerableInt() - ввод числовой последовательности;
        //
        //   GetEnumerableString() - ввод строковой последовательности;
        //
        //   Put() (метод расширени€) - вывод последовательности;
        //
        //   Show() и Show(cmt) (методы расширени€) - отладочна€ печать
        //     последовательности, cmt - строковый комментарий;
        //
        //   Show(e => r) и Show(cmt, e => r) (методы расширени€) -
        //     отладочна€ печать значений r, полученных из элементов e
        //     последовательности, cmt - строковый комментарий.

        public static void Solve()
        {
            Task("LinqBegin38");
            GetEnumerableInt().Where((_, i) => i % 3 != 2).Select((x, i) => i % 2 == 0 ? 2 * x : x).Put();

        }
    }
}
