using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp
{
    class Delegates
    {
        // Declaration of delegate
        private delegate void Calculator(int a, int b);
       

        private void Add(int a, int b) { Console.WriteLine( a + b); }
        private void Sub(int a, int b) { Console.WriteLine( a - b); }
        private void Mul(int a, int b) { Console.WriteLine( a * b); }
        private void Div(int a, int b) { Console.WriteLine( a / b); }

        // Simple Delegate
        public void SimpleDelegateCall()
        {
            Calculator cal = new Calculator(Add);
            cal.Invoke(10, 5);
        }

        // MultiCast Delegate
        public void DelegateCall()
        {
            // 1st way to add function 
            Calculator calc = Add;
            calc += Sub;
            calc += Mul;
            calc += Div;

            // 2nd way to add function
            Calculator calc3 = Add;
            Calculator calc1 = Sub;
            Calculator calc2 = Mul;
            Calculator calc4= Div;
            Calculator calc12 = calc1 + calc2 + calc3 + calc4;


            Console.WriteLine("Calling Invoke.");
            calc.Invoke(10, 5);

            Console.WriteLine("\n Simple Call.");
            calc(6, 3);

            // TO perform this delegate should have only one target
            Console.WriteLine("\n Begin Invoke.");
            IAsyncResult result = calc.BeginInvoke(10, 5, null, null);
            calc.EndInvoke(result);
            
        }

        // Capturing value from MultiCast delegate
        private delegate int MultiInvoke(int a, int b);

        private int Addition(int a, int b) { return a+b; }
        private int Substraction(int a, int b) { return a - b; }

        public void TestIndividualInvokesRetVal()
        {
           
            MultiInvoke MI1 = new MultiInvoke(Addition);
            MultiInvoke MI2 = new MultiInvoke(Substraction);

            MultiInvoke All = MI1 + MI2;

            int retVal = -1;

            Console.WriteLine("Invoke individually (Obtain each return value):");
            foreach (MultiInvoke individualMI in All.GetInvocationList())
            {
                retVal = individualMI(10, 5);
                Console.WriteLine("\tOutput: " + retVal);
            }
        }
    }
}
