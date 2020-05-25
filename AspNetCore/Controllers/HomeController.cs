using Microsoft.AspNetCore.Mvc;
using ClassLibraryStandard;

namespace AspNetCore.Controllers
{
    [Route("Home")]
    public class HomeController : Controller
    {
        [HttpGet]
        public string Get()
        {
            return Super.SuperMethod("ASP.NET CORE");
        }
    }
}
