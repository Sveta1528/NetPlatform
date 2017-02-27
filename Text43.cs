using PT4;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.IO;

namespace PT4Tasks
{
    public class MyTask: PT
    {
        public static void Solve()
        {
            Task("Text43");


            double a = GetDouble();
            double b = GetDouble();
            int n = GetInt();
            double step = (b - a)/n;

             var finalStream = new System.IO.StreamWriter(GetString(), true, Encoding.Default);

            for (int i = 0; i <= n; i++)
            {
                double x = a + step*i;
                finalStream.WriteLine(string.Format(CultureInfo.InvariantCulture, "{0,8:0.0000}", x)
                             + string.Format(CultureInfo.InvariantCulture, "{0,12:0.00000000}", Math.Sin(x))
                             + string.Format(CultureInfo.InvariantCulture, "{0,12:0.00000000}", Math.Cos(x)));
            }


            finalStream.Close();
        }

    }
}
