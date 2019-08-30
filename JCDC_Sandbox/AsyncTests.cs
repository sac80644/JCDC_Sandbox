using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace JCDC_Sandbox
{
    class AsyncTests
    {
        public async void AsyncMethod()
        {
            var response = await Fetch();
            Console.WriteLine(response);
        }

        public async Task<int> WaitAndReturnInt()
        {
            await Task.Delay(5000);
            return 5;
        }

        public async Task<string> Fetch()
        {
            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient { BaseAddress = new Uri("http://gallowaytech.com/gallowaytechwebapi/") };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //await Task.Delay(5000);

            HttpResponseMessage res = await client.GetAsync("api/SiteContent");

            if (res.IsSuccessStatusCode)
            {
                var response = await res.Content.ReadAsStringAsync();
                return response;
            }
            else
            {
                return "nothing returned";
            }
        }
    }
}
