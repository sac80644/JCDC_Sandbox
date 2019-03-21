using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JCDC_Sandbox
{
    public class HttpClient : IHttpClient
    {
        public virtual StringContent GetContent()
        {
            return new StringContent("1");
        }

        public virtual HttpStatusCode GetStatusCode()
        {
            return HttpStatusCode.OK;
        }

        public HttpResponseMessage GetResponseMessage()
        {
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        public virtual string GetString()
        {
            return "test";
        }
    }
}
