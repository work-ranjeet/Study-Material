using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.CSharp._2.O
{
    class AnonymousMethod
    {
        delegate void Compute(int a, int b);

        public void CallAnonymousMethod()
        {
            // A method without name
            Compute com = delegate(int a, int b)
            {
                Console.Write("Result = {0}", a + b);
            };

            com.Invoke(10, 5);

        }

        void StartThread()
        {
            System.Threading.Thread t1 = new System.Threading.Thread
              (delegate()
                {
                  System.Console.Write("Hello, ");
                  System.Console.WriteLine("World!");
                }
               );

            t1.Start();

            
        }


        

    }
}
