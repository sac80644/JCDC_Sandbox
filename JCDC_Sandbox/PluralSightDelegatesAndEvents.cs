using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCDC_Sandbox
{
    public class PluralSightWorkerFirstDraft
    {
        public delegate void WorkPerformedHandler(int hours, object workType);  //this can go out of the class as it is a class itself but I am containing it here
        public event WorkPerformedHandler WorkPerformed;
        public event EventHandler WorkCompleted;  //this is a delegate type: Represents the method that will handle an event that has no event data.

        public PluralSightWorkerFirstDraft()
        {
            
        }

        public virtual void DoWork(int hours, object workType)
        {
            for (int i = 0; i < hours; i++)
            {
                OnWorkPerformed(i, workType, "");
            }
            OnWorkCompleted();
        }

        protected virtual void OnWorkPerformed(int hours, object workType, string foo)
        {
            //raise the event directly after a null check
            if (WorkPerformed != null)
            {
                WorkPerformed(hours, workType);
            }
            //slicker
            //WorkPerformed?.Invoke(hours, workType);

            //Or:
            //you can create an event instance and cast it to the delegate - why???
            WorkPerformedHandler del = WorkPerformed as WorkPerformedHandler;
            if (del != null)
            {
                del(hours, workType);
            }

            //or slicker
            //del?.Invoke(hours, workType);
        }

        protected virtual void OnWorkCompleted()
        {
            //raise the event directly after a null check
            if (WorkCompleted != null)
            {
                WorkCompleted(this, EventArgs.Empty);
            }

            //or slicker
            //WorkCompleted?.Invoke(this, EventArgs.Empty);
        }
    }

    /// <summary>
    /// This will take the event args and put them into a class WorkPerformedEventArgs that inherits from EventArgs
    /// </summary>
    public class PluralSightWorkerSecondDraft
    {
        public delegate void WorkPerformedHandler(object sender, WorkPerformedEventArgs e);
        public event WorkPerformedHandler WorkPerformed;
        //public event EventHandler<WorkPerformedEventArgs> WorkPerformed;  //public event WorkPerformedHandler WorkPerformed;
        public event EventHandler WorkCompleted;  //this is a delegate type: Represents the method that will handle an event that has no event data.

        public virtual void DoWork(int hours, object workType)
        {
            for (int i = 0; i < hours; i++)
            {
                OnWorkPerformed(i, workType);
            }
            OnWorkCompleted();
        }

        protected virtual void OnWorkPerformed(int hours, object workType)
        {
            if (WorkPerformed != null)
            {
                WorkPerformed(this, new WorkPerformedEventArgs(hours, workType));
            }
        }

        protected virtual void OnWorkCompleted()
        {
            if (WorkCompleted != null)
            {
                //raise the event directly after a null check
                WorkCompleted(this, EventArgs.Empty);
            }
        }
    }

    /// <summary>
    /// Refactoring to use all syntactic sugar
    /// </summary>
    public class PluralSightWorkerThirdDraft
    {
        public event EventHandler<WorkPerformedEventArgs> WorkPerformed;  //public event WorkPerformedHandler WorkPerformed removes need for delegate signature
        public event EventHandler WorkCompleted;  //this is a delegate type: Represents the method that will handle an event that has no event data.

        public virtual void DoWork(int hours, object workType)
        {
            for (int i = 0; i < hours; i++)
            {
                OnWorkPerformed(i, workType);
            }
            OnWorkCompleted();
        }

        protected virtual void OnWorkPerformed(int hours, object workType)
        {
            WorkPerformed?.Invoke(this, new WorkPerformedEventArgs(hours, workType));
        }

        protected virtual void OnWorkCompleted()
        {
            WorkCompleted?.Invoke(this, EventArgs.Empty);
        }
    }

    public class WorkPerformedEventArgs : EventArgs
    {
        public int Hour { get; set; }
        public object WorkType { get; set; }

        public WorkPerformedEventArgs(int hour, object workType)
        {
            Hour = hour;
            WorkType = workType;
        }
    }
}