using Microsoft.AspNetCore.Mvc;

namespace MWS.Web.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
