using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using JCDC_Sandbox;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Serilog;
using Serilog.Sinks.Debug;

namespace JCDC_SandboxTests
{
    [TestClass]
    public class HttpClientTests
    {
        [TestMethod]
        public void UnsuccessfulTest()
        {
            try
            {
                Serilog.Log.Logger = new LoggerConfiguration()
                    .WriteTo.Debug()
                    .CreateLogger();

                Log.Information("***********************starting*********************");

                var content = new StringContent("1");
                var moqHttpMessageHandler = new Mock<JCDC_Sandbox.HttpClient>();
                //moqHttpMessageHandler.Setup(x => x.GetResponseMessage()).Returns(new HttpResponseMessage { StatusCode = HttpStatusCode.OK, Content = content });
                moqHttpMessageHandler.Setup(x => x.GetString()).Returns("test");
                //moqHttpMessageHandler.Setup(x => x.GetStatusCode()).Returns(HttpStatusCode.OK);
                //moqHttpMessageHandler.Setup(x => x.GetContent()).Returns(content);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                Assert.Fail();
            }
            

            //moqHttpMessageHandler.Setup(x => x.GetAsync(It.IsAny<string>()))
            //    .ReturnsAsync(new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError));

            //var siteContentController = new SiteContentController(moqHttpMessageHandler.Object);
            //var actionResult = siteContentController.Index();
            //var result = actionResult.Result as ViewResult;
            //var model = result?.Model as List<SiteContent>;

            //Assert.IsNull(actionResult.Exception);
            //Assert.IsNotNull(result);
            //Assert.IsNotNull(model);
        }
    }
}
