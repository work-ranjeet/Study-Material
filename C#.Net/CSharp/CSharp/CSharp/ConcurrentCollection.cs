using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Threading;
namespace DemoCSharp
{
    public class ConcurrentCollection
    {
        private IEnumerable<int> INumQuery = new int[] { 1, 2, 3, 4, 5, 5, 6, 4, 7, 8, 9, 90, 08, 12 };
        
        private void ConcurrentQueue()
        {
            ConcurrentQueue<int> queue = new ConcurrentQueue<int>();
            INumQuery.AsParallel<int>().ForAll(val => queue.Enqueue(val));

            queue.AsParallel().ForAll(v => Console.WriteLine(v.ToString()));
            
        }
        

        public void CallTest()
        {
            ConcurrentQueue();
            Console.ReadKey();
        }
    }
}
