using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPatterns
{
    public sealed class Singleton
    {
        private static volatile Singleton instance = null;
        private static object syncRoot = new Object();

        private Singleton() { }

        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        instance = new Singleton();
                    }
                }
                return instance;
            }
        }

        public int Add(int a, int b)
        {
            return a + b;
        }
    }
}
