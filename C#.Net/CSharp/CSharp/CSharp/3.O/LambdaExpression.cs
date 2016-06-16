using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoCSharp._3
{
    public class LambdaExpression
    {
        /*
         * Lambda expressions are a simpler syntax for anonymous delegates and can be used everywhere an anonymous delegate can be used
         * lambda expressions can be converted to expression trees which allows for a lot of the magic that LINQ to SQL
         * Lambda expressions and anonymous delegates have an advantage over writing a separate function: 
            they implement closures which can allow you to pass local state to the function without adding parameters to the function 
            or creating one-time-use objects.
         * Lambda Expression is a concise syntax to achieve the same goal as anonymous method.
         * Left hand side of expression contains zero or more parameters followed by Lambda operator ‘=>’ 
            which is read as “goes to” and right hand side contains the expression or Statement block.
         * Lambda Operator “=>” has the same precedence as assignment “=” operator
         * 
         */


        /* Parameter Types
         * (int p) => p * 4; 	// Explicitly Typed Parameter
         * q => q * 4; 	        // Implicitly Typed Parameter
         */

        public void test()
        {
            // Simple lambda expressions
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var returnedList = numbers.Where(n => (n > 8));

            // Statement Block in Lambda Expression
            var returnedList1 = numbers.Where(n =>
                                                {
                                                    if(n < 4)
                                                        return true;
                                                    else if(n > 8)
                                                        return true;

                                                    return false;
                                                });

            // Lambda with More than One Parameter
            AddInteger addInt = (x, y) => x + y;
            int result = addInt(10, 4); // return 14

            // Lambda with Zero Parameter
            GetNextGuid getNewGuid = () => (Guid.NewGuid());
            Guid newguid = getNewGuid();
            

            // anonymous delegate
            var evens = Enumerable
                            .Range(1, 100)
                            .Where(delegate(int x) { return (x % 2) == 0; })
                            .ToList();

            // lambda expression
            var evens1 = Enumerable
                            .Range(1, 100)
                            .Where(x => (x % 2) == 0)
                            .ToList();
        }


        // Lambda with More than One Parameter
        delegate int AddInteger(int n1, int n2);

        // Lambda with Zero Parameter
        delegate Guid GetNextGuid();
    }
}
