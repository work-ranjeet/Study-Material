using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace DemoCSharp._2.O
{
    // Generic Collection, Generic Function, Geniric Class Introduced
    //generic Interface
    interface IPair<TFirst, TSecond>
    {
        TFirst First
        { get; set; }

        TSecond Second
        { get; set; }
    }

    //generic class
    public struct Pair<TFirst, TSecond>: IPair<TFirst, TSecond>
    {

        public Pair(TFirst first, TSecond second)
        {
            _First = first;
            _Second = second;
        }

        private TFirst _First;
        public TFirst First
        {
            get { return _First; }
            set { _First = value; }
        }

        private TSecond _Second;
        public TSecond Second
        {
            get { return _Second; }
            set { _Second = value; }
        }

        public T Add<T>(T val)
        {
            //if ( GetType(val) == int)
            //    val =val+1;
            return (T)Convert.ChangeType(val, typeof(T));
        }


    }

    class genericCollections
    {
        //System.Collections.Generic.IComparer
        //System.Collections.Generic.Comparer
        //Comparer<int> c

        #region System.Collections.Generic.IDictionary

        //System.Collections.Generic.IDictionary
        //System.Collections.Generic.Dictionary
        //public interface IDictionary<TKey, TValue> : ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable
        IDictionary<int, string> dic = new Dictionary<int, string>();
        #endregion

        //System.Collections.Generic.SortedDictionary

        #region System.Collections.Generic.HashSet
        // Has no duplicate elemets in hashSet like list. 
        //It will return false when we enter a duplicate number and not enter in hashSet
        public void HashSetDemo()
        {
            Func<int, string> func1 = (x) => string.Format("string = {0}", x);
            Func<HashSet<int>, bool> DisplaySet = (x) =>
            {
                Console.Write("{");
                x.ToList().ForEach(v => Console.Write(" {0}", v));
                Console.WriteLine(" }");

                return false;
            };
            HashSet<int> evenNumbers = new HashSet<int>();
            HashSet<int> oddNumbers = new HashSet<int>();

            for(int i = 0; i < 5; i++)
            {
                // Populate numbers with just even numbers.
                evenNumbers.Add(i * 2);
                Console.WriteLine(evenNumbers.Add(i * 2));

                // Populate oddNumbers with just odd numbers.
                oddNumbers.Add((i * 2) + 1);
            }

            Console.Write("evenNumbers contains {0} elements: ", evenNumbers.Count);
            DisplaySet(evenNumbers);

            Console.Write("oddNumbers contains {0} elements: ", oddNumbers.Count);
            DisplaySet(oddNumbers);

        }
        #endregion

        #region System.Collections.Generic.KeyValuePair

        #endregion

        //System.Collections.Generic.ICollection 
        //System.Collections.Generic.IEnumerable
        //System.Collections.Generic.IEnumerator
        //System.Collections.Generic.IList
        //System.Collections.Generic.ISet

        //System.Collections.Generic.LinkedList
        //System.Collections.Generic.LinkedListNode
        // System.Collections.Generic.List
        //System.Collections.Generic.Queue
       
        //System.Collections.Generic.SortedList
        //System.Collections.Generic.SortedSet
        //System.Collections.Generic.Stack

       
    }

    #region IEqualityComparer
    //System.Collections.Generic.IEqualityComparer
    //System.Collections.Generic.EqualityComparer
    class Class_reglement { public int Numf;}
    class Compare: IEqualityComparer<Class_reglement>
    {
        public bool Equals(Class_reglement x, Class_reglement y)
        {
            return x.Numf == y.Numf;
        }
        public int GetHashCode(Class_reglement codeh)
        {
            return codeh.Numf.GetHashCode();
        }
    }
    #endregion

    public partial class CallClass_2_O
    {
        genericCollections objgenericCollections = new genericCollections();

        public void CallGeneric()
        {
            Compare objCompare = new Compare();
            if(objCompare.Equals(new Class_reglement() { Numf = 0 }, new Class_reglement() { Numf = 0 }))
                Console.WriteLine("objCompare, working properly.");

            objgenericCollections.HashSetDemo();
        }
    }

}
