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
            PluralSightWorkerFirstDraft p1 = new PluralSightWorkerFirstDraft();
            p1.DoWork(5, new object());  //if I do this I have not wired up the event handler methods. use the client to do so
            PluralSightDelegatesAndEventsClientDraftOne pc1 = new PluralSightDelegatesAndEventsClientDraftOne();
            pc1.RunPayRoll();

            PluralSightDelegatesAndEventsClientDraftTwo pc2 = new PluralSightDelegatesAndEventsClientDraftTwo();
            pc2.RunPayRoll();

            PluralSightDelegatesAndEventsClientDraftThree pc3 = new PluralSightDelegatesAndEventsClientDraftThree();
            pc3.RunPayRoll();

            PluralSightAnonymousMethodsClient pa1 = new PluralSightAnonymousMethodsClient();

            PluralSightLambdasRunner runner = new PluralSightLambdasRunner();
            runner.Run();

            PluralSightLinq pl = new PluralSightLinq();
            Console.ReadKey();
        }

        static int Recursive(int value, ref int count)
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

    class PluralSightDelegatesAndEventsClientDraftOne
    {
        readonly PluralSightWorkerFirstDraft worker = new PluralSightWorkerFirstDraft();

        public PluralSightDelegatesAndEventsClientDraftOne()
        {
            worker.WorkPerformed += new PluralSightWorkerFirstDraft.WorkPerformedHandler(Worker_WorkPerformed);  //this uses the event and wires it to the handler method
            worker.WorkCompleted += new EventHandler(Worker_WorkCompleted);  //basic event handler
        }

        public void RunPayRoll()
        {
            worker.DoWork(10, new object());
        }

        public static void Worker_WorkPerformed(int hours, object workType)
        {
            Console.WriteLine($"{hours} hours worked so far.");
        }

        public static void Worker_WorkCompleted(object sender, EventArgs e)
        {
            Console.WriteLine($"Work Done.");
        }
    }
    
    class PluralSightDelegatesAndEventsClientDraftTwo
    {
        readonly PluralSightWorkerSecondDraft worker = new PluralSightWorkerSecondDraft();

        public PluralSightDelegatesAndEventsClientDraftTwo()
        {
            worker.WorkPerformed += new PluralSightWorkerSecondDraft.WorkPerformedHandler(Worker_WorkPerformed);
            worker.WorkCompleted += new EventHandler(Worker_WorkCompleted);
        }

        public void RunPayRoll()
        {
            worker.DoWork(10, new object());
        }

        public static void Worker_WorkPerformed(object sender, WorkPerformedEventArgs e)
        {
            Console.WriteLine($"{e.Hour} hours worked so far.");
        }

        public static void Worker_WorkCompleted(object sender, EventArgs e)
        {
            Console.WriteLine($"Work Done.");
        }
    }

    class PluralSightDelegatesAndEventsClientDraftThree
    {
        readonly PluralSightWorkerThirdDraft worker = new PluralSightWorkerThirdDraft();

        public PluralSightDelegatesAndEventsClientDraftThree()
        {
            //worker.WorkPerformed += new EventHandler<WorkPerformedEventArgs>(Worker_WorkPerformed);
            //worker.WorkCompleted += new EventHandler(Worker_WorkCompleted);
            //or Delegate Inference
            worker.WorkPerformed += Worker_WorkPerformed;
            worker.WorkCompleted += Worker_WorkCompleted;
            //or Lambda
            worker.WorkPerformed += (s, e) => Console.WriteLine($"{e.Hour} hours worked so far.");
        }

        public void RunPayRoll()
        {
            worker.DoWork(10, new object());
            Dispose();
        }

        public static void Worker_WorkPerformed(object sender, WorkPerformedEventArgs e)
        {
            Console.WriteLine($"{e.Hour} hours worked so far.");
        }

        public static void Worker_WorkCompleted(object sender, EventArgs e)
        {
            Console.WriteLine($"Work Done.");
        }

        public void Dispose()
        { 
            //not necessary, just to show how to remove an event from a handler
            worker.WorkPerformed -= Worker_WorkPerformed;
            worker.WorkCompleted -= Worker_WorkCompleted;
        }
    }
}
