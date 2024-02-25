using Microsoft.AspNetCore.Mvc;

namespace MWS.Web.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
