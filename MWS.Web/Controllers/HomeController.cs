using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MWS.Web.Areas.Identity.Data;
using MWS.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MWS.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly UserManager<ApplicationUser> _userRole;

        public HomeController(UserManager<ApplicationUser> userManager, UserManager<ApplicationUser> userRole)
        {
            _userManager = userManager;
            _userRole = userRole;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user != null)
            {
                var roles = await _userManager.GetRolesAsync(user);

                string currentRole = "";

                foreach (var role in roles)
                {
                    currentRole = role.ToString();
                }

                HttpContext.Session.Clear();
                HttpContext.Session.SetString("UNAME", user.UserName);
                HttpContext.Session.SetString("UROLE", currentRole);
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
