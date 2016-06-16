using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoCSharp._3
{
    // This class is mutable. Its data can be modified from 
    // outside the class.
    public class AutoImplementedProperties
    {
        // Auto-Impl Properties for trivial get and set 
        public double TotalPurchases { get; set; }
        public string Name { get; set; }
        public int CustomerID { get; set; }

        // Constructor 
        public AutoImplementedProperties(double purchases, string name, int ID)
        {
            TotalPurchases = purchases;
            Name = name;
            CustomerID = ID;
        }
        // Methods 
        public string GetContactInfo() { return "ContactInfo"; }
        public string GetTransactionHistory() { return "History"; }

        // .. Additional methods, events, etc.
    }
}
