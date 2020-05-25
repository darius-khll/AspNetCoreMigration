using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Owin.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OwinAspNet;

namespace Owin.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestServerAssertion()
        {
            using (var server = TestServer.Create<Startup>())
            {
                using (var client = new HttpClient(server.Handler))
                {
                    var response = await client.GetAsync("http://testserver/home");
                    var result = await response.Content.ReadAsStringAsync();

                    Assert.AreEqual("\"Hello World! OWIN\"", result);
                }
            }
        }
    }
}
