using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using NUnit.Framework;
using System.Net.Http;
using System.Threading.Tasks;
using OwinTesting = Microsoft.Owin.Testing;

namespace Core.Test
{
    public class Tests
    {
        [Test]
        public async Task TestOwinServer()
        {
            using (var server = OwinTesting.TestServer.Create<OwinAspNet.Startup>())
            {
                using (var client = new HttpClient(server.Handler))
                {
                    var response = await client.GetAsync("http://testserver/home");
                    var result = await response.Content.ReadAsStringAsync();

                    Assert.AreEqual("\"Hello World! OWIN\"", result);
                }
            }
        }

        [Test]
        public async Task TestAspNetCoreServer()
        {
            var webHostBuilder = new WebHostBuilder().UseStartup<AspNetCore.Startup>();

            using (var server = new TestServer(webHostBuilder))
            {
                using (var client = server.CreateClient())
                {
                    var response = await client.GetAsync("http://testserver/home");
                    var result = await response.Content.ReadAsStringAsync();

                    Assert.AreEqual("Hello World! ASP.NET CORE", result);
                }
            }
        }
    }
}