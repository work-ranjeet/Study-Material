using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections.Specialized;

namespace DemoCSharp
{
    public static class ExtentioinMethods
    {
        public static string GetFirstLetter(this string str)
        {
            return str.ToCharArray()[0].ToString();
        }

        public static TValue GetSafeValue<Tkey, TValue>(this IDictionary<Tkey, TValue> dic, Tkey key)
        {
            if (dic.ContainsKey(key))
                return dic[key];

            return default(TValue);
        }


        public static void CallTest()
        {
            string name = "ranjeet";
            Console.WriteLine(name.GetFirstLetter());

            var dic = new Dictionary<int, string>();
            dic.Add(1, "ranjeet");
            Console.WriteLine(string.Format("Fetching valid key {0} : " + dic.GetSafeValue<int, string>(1), "1"));
            Console.WriteLine(string.Format("Fetching InValid key {0} : " + dic.GetSafeValue<int, string>(2), "2"));
            Console.WriteLine("");


            var numberCollection = new int[] { 1, 2, 3, 4, 5, 5, 6, 4, 7, 8, 9, 90, 08, 12 };
            // Checking number
            var number = numberCollection.Find(IsPrime);
            foreach (var n in number)
            {
                Console.Write(n.ToString() + ", ");
            }

            Console.ReadKey();
            //System.Collections.Specialized.NameValueCollection<int, string> test = new System.Collections.Specialized.NameValueCollection<int, string>();
        }

        public static bool IsPrime(int inputNumber)
        {
            bool prime = true;
            if (inputNumber == 1) return prime;
            if (inputNumber == 2) return prime;
            if (inputNumber == 3) return prime;
            for (int i = 2; i <= (inputNumber / 2); i++)
            {
                if (inputNumber % i == 0) { prime = false; break; }
            }
            return prime;
        }

        public static bool IsOdd(int inputNumber)
        {
            bool Odd = true;

            if (inputNumber % 2 != 0) { Odd = false; }

            return Odd;
        }

        public static bool IsEven(int inputNumber)
        {
            bool Even = true;

            if (inputNumber % 2 == 0) { Even = false; }

            return Even;
        }

        //Exention method for integer
        public static IEnumerable<int> Find(this IEnumerable<int> input, Func<int, bool> function)
        {
            foreach(var number in input)
            {
                if(function(number))
                    yield return number;
            }
        }

        //Func<int ,bool> funcTest()=> 

        //Overloaded Exention method Find
        //public static Func<Tresult> Partial<TParam1, Treuslt>(this Func<TParam1, Treuslt> func, TParam1 parameter)
        //{
        //    return () => func(parameter);
        //}
    }
}
