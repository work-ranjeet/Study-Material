using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace DemoCSharp._2.O
{
    class Iterators
    {
        public void test()
        {
            string[] cities = { "New York", "Paris", "London" };
            foreach(string city in cities)
            {
                Console.WriteLine(city);
            }
        }


        // IEnumerator  examples

    }

}



/*
    Iterato is a data structure as array or collection. useing a foreach loop.
 
 *  we can use any custom data collection in the foreach loop, 
    as long as that collection type implements a GetEnumerator method that returns an IEnumerator interface.
 
 * Both are interface
IEnumerable code are clear and can be used in foreach loop
IEnumerator use While, MoveNext, current to get current record
IEnumerable doesn’t remember state
IEnumerator persists state means which row it is reading
IEnumerator cannot be used in foreach loop
IEnumerable defines one method GetEnumerator which returns an IEnumerator
IEnumerator allows readonly access to a collection 
*/