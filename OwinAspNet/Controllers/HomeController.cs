using ClassLibraryStandard;
using System.Web.Http;

namespace OwinAspNet.Controllers
{
    [Route("Home")]
    public class HomeController : ApiController
    {
        [HttpGet]
        public string Get()
        {
            return Super.SuperMethod("OWIN1");
        }
    }
}