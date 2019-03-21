using System.Net.Http;

namespace JCDC_Sandbox
{
    public interface IHttpClient
    {
        HttpResponseMessage GetResponseMessage();
        StringContent GetContent();
        System.Net.HttpStatusCode GetStatusCode();
        string GetString();
    }
}