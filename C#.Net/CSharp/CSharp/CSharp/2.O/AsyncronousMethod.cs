using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp.CSharp._2.O
{
    // Call and forget
    class AsyncronousMethod
    {
        public delegate DataTable mymethod(string s);

        public static DataTable dtData;

        public static mymethod inv;

        static void CallAsyncTest()
        {
            inv = new mymethod(Print);
            inv.BeginInvoke("Ranjeet", new AsyncCallback(Callback), null);
            Console.ReadLine();
        }

        public static DataTable Print(string q)
        {
            Thread.Sleep(1000);
            Console.WriteLine(q);
            var dt = new DataTable();
            dt.Columns.Add("Age");
            dt.Rows.Add(11);
            dt.Rows.Add(12);
            dt.Rows.Add(13);

            return dt;
        }

        public static void Callback(IAsyncResult t)
        {
            dtData = inv.EndInvoke(t);
            foreach (DataRow row in dtData.Rows)
            {
                Console.WriteLine(row["age"].ToString());
            }
        }

    }
}
