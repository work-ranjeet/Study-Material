using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoCSharp._3
{
    public class PartialMethods
    {
        /*
           Partial method has its signature defined in one part of the partial type,and its implementation defined in another type.
            Partial methods enable class designers to provide method hook,similar to event handlers,that 
            developers may decide to implement or not.If the developer does not supply an implementation,
            the compiler removes the signature at compile time.
         
            * A partial method must be declared within a partial class or partial struct
            * A partial method cannot have access modifiers or the virtual, abstract, override, new, sealed, or extern modifiers
            * Partial methods must have a void return type
            * A partial method cannot have out parameters
            * Partial method must be private.
            * We cannot call partial method in the Main because it is private and we have to call it in another method of the same class.
        
         */
    }

    partial class csharp
    {
        partial void show();
    }

    partial class csharp
    {

        partial void show()
        {
            Console.WriteLine("Partial Method is Implemented");
        }

        public void disp()
        {
            //partial method is called.
            show();
        }

    }
}
