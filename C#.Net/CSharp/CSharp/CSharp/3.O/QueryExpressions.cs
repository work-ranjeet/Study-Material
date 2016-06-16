using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace DemoCSharp._3
{
    /*
     * 
     */
    class QueryExpressions
    {
        IEnumerable<int> source = new[] { 1, 2, 3, 4, 5, 6, 8, 0, 12, 34 };
        public void test()
        {
            //  Query Expressions
            var positive = from number in source
                           where number > 0
                           orderby number descending
                           select number.ToString(CultureInfo.InvariantCulture);
            /*
             * Since source is an integer array, and int[] implements IEnumerable<int>, so Where(), 
                OrderByDescending() and Select() can also be invoked on int[]
             * Where() returns a IEnumerable<int>, so we can immediately invoke OrderByDescending() on the return value of Where()
             * For the same reason, we can fluently invoke Select()
             * 
             */

            //  Method Expressions
            IEnumerable<string> positive1 = source.Where(number => number > 0)
                                     .OrderByDescending(number => number)
                                     .Select(number => number.ToString(
                                            CultureInfo.InvariantCulture));

            /*
             * Query expression will be compiled into normal method invocation, and writing exact method invocation code helps 
                understanding what is happening, and gets developers less confused;
             * In some scenarios, query cannot be implemented by pure query expression, then query method has to come out; 
                So for the consistency consideration, always using query method is preferred.
             */

            /*              IQueryable<Product> results = (from product in source
                                                           where product.Category.CategoryName == "Beverages"
                                                           orderby product.ProductName
                                                           select product) // Query expression cannot do pagination.
                                                          .Skip(50) // So it has to be mixed with query methods.
                                                          .Take(10);
             */ 
        }


    }
}
