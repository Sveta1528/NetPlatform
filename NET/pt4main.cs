using System;
using PT4;
using PT4Tasks;

namespace PT4Main
{
    class PTMain
    {
//--------------------------------------------------//
//       WARNING! Altering the Main function        //
//  may cause Programming Taskbook to malfunction.  //
//--------------------------------------------------//
        public static int Main(string[] args)
        {
            TaskMaker.StartCS();
            try
            {
                MyTask.Solve();
            }
            catch(Exception ex) 
            {
                TaskMaker.RaisePT(ex);
            }
            TaskMaker.FreePT();
            return 0;
        }
    }
}
