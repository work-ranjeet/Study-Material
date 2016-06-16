using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoCSharp._2.O
{
    #region Description

    // AnonymousMethods : A method having no name called as Anonymous methos. 
    // A delegate come in picture when we use Anonymous method
    // but where I use delegete, 
    // delegates in the .NET type system or the C# delegate syntax? 
    // Do you mean "when do you use the delegate syntax instead of lambda expression syntax" 
    // do you mean "when do you use delegates instead of classes/interfaces/virtual methods/etc."?
    // this all things are no meaning of delegate but when I use lambda expression then delegate is present in back.
    

    #endregion
    public class AnonymousAndDelegate
    {
        // A simple example to define delegate

        delegate void SomeDelegate(string str);
        public void InvokeMethod()
        {
            SomeDelegate del = delegate
            {
                Console.WriteLine("Hello"); 
            }; 
            

            del("\nParameter is ignored"); // this parameter is ignored  at run time

            SomeDelegate delP = delegate(string s)
            {
                Console.WriteLine(s);
            };
            delP("\nParameter is passed");
        }


        //Anonymous Method as Event Handler


    }

    public partial class CallClass_2_O
    {
        
        public void InvokeAnonymousMethod()
        {
            AnonymousAndDelegate obj = new AnonymousAndDelegate();
            obj.InvokeMethod();
        }
    }

}
