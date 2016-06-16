using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.DesignePattern.Creational
{
    class FactoryPattern
    {
        public ICalculation GetObject(string cal)
        {
            ICalculation obj = null;
            switch (cal)
            {
                case "add":
                    obj = new ADD();
                    break;

                case "sub":
                    obj = new Substract();
                    break;

                case "mul":
                    obj = new Multiply();
                    break;

                case "div":
                    obj = new Division();
                    break;
            }

            return obj;
        }
    }

    interface ICalculation
    {

    }

    public class ADD : ICalculation
    {
        public void add() { }
    }

    public class Substract : ICalculation
    {
        public void sub() { }
    }

    public class Multiply : ICalculation
    {
        public void multi() { }
    }

    public class Division : ICalculation
    {
        public void divide() { }
    }
}
