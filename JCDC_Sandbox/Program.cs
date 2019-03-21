using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCDC_Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            ////
            //// Call recursive method with two parameters.
            ////
            //int count = 0;
            //int total = Recursive(5, ref count);
            ////
            //// Write the result from the method calls and also the call count.
            ////
            //Console.WriteLine(total);
            //Console.WriteLine(count);

            //var mapper = new ContentPropertyMapper();

            var client = new HttpClient();
            var content = client.GetContent();
        }


        static int Recursive(int value, ref int count)
        {
            count++;
            if (value >= 10)
            {
                // throw new Exception("End");
                return value;
            }
            return Recursive(value + 1, ref count);
        }

        public static void FluentTest()
        {
            EmployeeFluentInterface foo = new EmployeeFluentInterface();
            foo.CreateEmployee("Jason").BornOn("9/4/1971").HomeTown("Tacoma");

            var bar = foo;
        }
    }
}
