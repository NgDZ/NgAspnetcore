using Microsoft.AspNetCore.Mvc;

namespace NgAspnetcore.HttpApi.Host.Controllers
{
    public class AngularHomeController : ControllerBase
    {
        public ActionResult Index()
        {
            return File("index.html", "text/html");
        }
    }
}
