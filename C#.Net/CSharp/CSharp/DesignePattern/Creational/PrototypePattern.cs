using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.DesignePattern.Creational
{
    public abstract class ProductPrototype : ICloneable
    {
        public decimal Price { get; set; }

        public ProductPrototype(decimal price)
        {
            Price = price;
        }

        //public abstract ProductPrototype Clone();

        public abstract object Clone();

    }

    public class Milk : ProductPrototype
    {
        public Milk(decimal price)
            : base(price)
        {

        }

        public override object Clone()
        {
            // Shallow Copy: only top-level objects are duplicated
            return this.MemberwiseClone();

            // Deep Copy: all objects are duplicated
            //return (ProductPrototype)this.Clone();
        }
    }

    public class Bread : ProductPrototype
    {
        public Bread(decimal price)
            : base(price)
        {

        }

        public override object Clone()
        {
            // Shallow Copy: only top-level objects are duplicated
            return this.MemberwiseClone();

            // Deep Copy: all objects are duplicated
            //return (ProductPrototype)this.Clone();
        }
    }

    public class Supermarket
    {
        private Dictionary<string, ProductPrototype> _productList = new Dictionary<string, ProductPrototype>();

        public void AddProduct(string key, ProductPrototype productPrototype)
        {
            _productList.Add(key, productPrototype);
        }

        public ProductPrototype GetProduct(string key)
        {
            var product = _productList[key];
            return (ProductPrototype)product.Clone();
        }
    }

    class PrototypePattern
    {
        private static void Prototype()
        {
            // Language agnostic solution
            var supermarket = new Supermarket();

            supermarket.AddProduct("Milk", new Milk(0.89m));
            supermarket.AddProduct("Bread", new Bread(1.10m));

            decimal sourcePrice;
            decimal currentPrice;

            var clonedMilk = (Milk)supermarket.GetProduct("Milk");
            clonedMilk.Price = 1;
            sourcePrice = supermarket.GetProduct("Milk").Price;
            currentPrice = clonedMilk.Price;
            Console.WriteLine(String.Format("{0} | {1}", sourcePrice, currentPrice));

            var clonedBread = (Bread)supermarket.GetProduct("Bread");
            clonedBread.Price = 2;
            sourcePrice = supermarket.GetProduct("Bread").Price;
            currentPrice = clonedBread.Price;
            Console.WriteLine(String.Format("{0} | {1}", sourcePrice, currentPrice));

            
            Console.ReadKey();
        }
    }
}
