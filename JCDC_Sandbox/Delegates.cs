using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCDC_Sandbox
{
    class Delegates
    {
        // Create a delegate.
        delegate void Del(string message);

        // Declare a delegate.
        delegate void Printer(string s);

        /// <summary>
        /// there are several ways to use delegates
        /// </summary>
        public void CreateAndPassSomeDelegate()
        {
            // Instantiate the delegate using an anonymous method.
            //Del d1 = delegate (string message) { System.Console.WriteLine(message); };  //old school
            Del d1 = System.Console.WriteLine;  //new school

            //anonymous method call
            d1("some work");

            //passing delegate to another function to invoke
            AcceptAndExecuteSomeDelegate(d1);

            //repointing
            d1 = WriteToConsole;
            d1("repointed to a method with the same signature");


            //new function pointer to WriteToConsole "event handler"
            Del d2 = new Del(WriteToConsole);
            d2("some message");

            //add to invocation list
            d1 += d2;

            d1("which will be called from the list?");  //both in order
        }

        public void AcceptAndExecuteSomeDelegate(Delegate d)
        {
            d.DynamicInvoke("dynamic invoke");
        }

        public void WriteToConsole(string message)
        {
            Console.WriteLine(message);
        }

        public void MsDnExample()
        {
            // Instantiate the delegate type using an anonymous method.
            Printer p = delegate (string j)
            {
                System.Console.WriteLine(j);
            };

            // Results from the anonymous delegate call.
            p("The delegate using the anonymous method is called.");

            // The delegate instantiation using a named method "DoWork".
            p = DoWork;

            // Results from the old style delegate call.
            p("The delegate using the named method is called.");
        }

        // The method associated with the named delegate.
        static void DoWork(string k)
        {
            System.Console.WriteLine(k);
        }
    }
}
