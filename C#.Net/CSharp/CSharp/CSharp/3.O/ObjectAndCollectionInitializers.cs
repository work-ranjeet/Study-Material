using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoCSharp._3
{

    public class ObjectAndCollectionInitializers
    {


        //if I wanted to create a object of the type customer and fill up the public variables and properties then in C#2.0 I need to do something like

        //Customer customer = new Customer();

        //customer.name = "Abhinaba Basu";

        //customer.address = "1835 73rd Ave NE, Medina, WA 98039";

        //customer.Age = 99;

        //With the new object initializer syntax it possible to do all of the above in one statement as in

        //var cust = new Customer{name = "Abhinaba Basu", 
        //                 address = "1835 73rd Ave NE, Medina, WA 98039",
        //                 Age = 99 };
        //This not only reduces lines of code but increases flexibility a lot. So no more being forced to write 5 overloads of a contructor that just accepts these                 variables and assigns them to fields.This syntax works for both public fields and properties.

        //In case the class contains other classes as fields then the same statement can also initialize the contained class (see code below in bold).
        class Customer
        {

            public string name;

            public string address;

            int age;

            public int Age { get { return age; } set { age = value; } }

        }

        class Phone
        {

            public int countryCode;

            public int areaCode;

            public int number;

        }

        class Customer1
        {

            public string name;

            public string address;

            public Phone phone;

        }

        #region Object Initializers
        public void UseTestCustomer()
        {
            var cust = new Customer
            {
                name = "Abhinaba Basu",
                address = "1835 73rd Ave NE, Medina, WA 98039",
                Age = 99
            };
        }

        public void useTestCustomer1()
        {
            var cust = new Customer1
            {
                name = "Abhinaba Basu",
                address = "1835 73rd Ave NE, Medina, WA 98039",

                phone = new Phone
                {
                    countryCode = 1,
                    areaCode = 425,
                    number = 9999999
                }
            };
        }
        #endregion

        #region Collection Initializers

        public void CollectionInitializers()
        {
            List<int> digits = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            //For the Customer and Phone number class discussed above the collection initializer will look like

            List<Customer1> custList = new List<Customer1> {    new Customer1 {
                                                                    name = "Samrat", address = "NJ, USA", 
                                                                    phone = new Phone {countryCode = 91, areaCode = 999, number = 8888888}
                                                                },
                                                                new Customer1 {
                                                                    name = "Kaushik", address = "Behala, Kolkata",
                                                                    phone = new Phone {countryCode = 91, areaCode = 33, number = 3333333}
                                                                },
                                                                new Customer1 {
                                                                    name = "Rahul", address = "Kerala", 
                                                                    phone = new Phone {countryCode = 91, areaCode = 00, number = 4444}
                                                                }
                                                            };
        }
        #endregion
    }
}