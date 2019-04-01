using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCDC_Sandbox
{
    public class Button
    {
        public event EventHandler Click;

        public void HumanClick()
        {
            Click?.Invoke(this, EventArgs.Empty);
        }
    }

    /// <summary>
    /// this shows the usage of an anonymous method, but these are not really used as lambdas have cleaned this up...
    /// see lambdas
    /// </summary>
    public class PluralSightAnonymousMethodsClient
    {
        public PluralSightAnonymousMethodsClient()
        {
            var button = new Button();
            button.Click += delegate(object sender, EventArgs e) { Console.WriteLine("Button Clicked"); };
            //lambda
            button.Click += (s, e) => Console.WriteLine("Button Clicked");
        }
    }
}
