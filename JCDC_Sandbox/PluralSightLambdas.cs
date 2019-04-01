using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace JCDC_Sandbox
{
    /// <summary>
    /// <!-- Lambdas, Action<T> and Func<T,TResult> -->
    /// </summary>

    public class PluralSightLambdasProcess
    {
        public delegate int BizRulesDelegate(int x, int y);
        public void Process(int x, int y, BizRulesDelegate del)
        {
            var result = del(x, y);
            Console.WriteLine(result);
        }
    }

    public class PluralSightLambdasRunner
    {
        public void Run()
        {
            PluralSightLambdasProcess.BizRulesDelegate addDel = (x, y) => x + y;
            PluralSightLambdasProcess.BizRulesDelegate multiplyDel = (x, y) => x * y;
            var process = new PluralSightLambdasProcess();
            process.Process(2, 3, addDel);
            process.Process(2, 3, multiplyDel);

            //using the Action<T> .net out of the box delegate means you don't have to create your own delegate signature
            //Action<T> does not return a value
            var action = new PluralSightActionT();
            Action<int, int> addAction = (x, y) => Console.WriteLine(x + y);
            Action<int, int> multiplyAction = (x, y) => Console.WriteLine(x * y);
            action.Process(5, 6, addAction);
            action.Process(5, 6, multiplyAction);

            //use the Func<T,T,TResult> to replace the BizRulesDelegate
            var func = new PluralSightFuncT();
            Func<int, int, int> addFunc = (x, y) => x + y;
            Func<int, int, int> multiplyFunc = (x, y) => x * y;
            func.Process(5,6,addFunc);
            func.Process(5, 6, multiplyFunc);
        }
    }

    public class PluralSightActionT
    {
        public void Process(int x, int y, Action<int, int> delAction)
        {
            delAction(x, y);  //returns void
            Console.WriteLine("Action has been invoked.");
        }
    }

    public class PluralSightFuncT
    {
        public void Process(int x, int y, Func<int, int, int> delFunc)
        {
            Console.WriteLine("Func has been invoked.");
            Console.WriteLine(delFunc(x, y));
        }
    }

    public class PluralSightLinq
    {
        public PluralSightLinq()
        {
            var custs = new List<Customer>
            {
                new Customer{FirstName = "Jason", LastName = "Galloway"},
                new Customer{FirstName = "Shannon", LastName = "Galloway"},
                new Customer{FirstName = "KJ", LastName = "Galloway", NickName = "Punkin"},
                new Customer{FirstName = "Buddy", LastName = "Galloway"},
                new Customer{FirstName = "Robin", LastName = "Bobo"},
                new Customer{FirstName = "Corey", LastName = "Haan"}
            };
            DoWork(custs);
        }

        private void DoWork(List<Customer> custs)
        {
            foreach (var customer in Filter(custs))
            {
                Console.WriteLine(customer.FirstName + " " + customer.LastName);
            }
        }

        /// <summary>
        /// query syntax and method syntax with lambdas
        /// </summary>
        /// <param name="custs"></param>
        /// <returns></returns>
        public List<Customer> Filter(List<Customer> custs)
        {
            //query syntax
            var custsLinq =
                from cust in custs
                where cust.LastName == "galloway" && cust.NickName != null
                orderby cust.LastName
                select cust;
                  
            //method syntax
            return custs
                .Where(c => c.LastName == "Galloway" && c.NickName != null)
                .OrderBy(c => c.FirstName)
                .ToList();
        }

        public class Customer
        {
            public string FirstName { get; set; }
            public string  LastName { get; set; }
            public string NickName { get; set; }
        }
    }
}
