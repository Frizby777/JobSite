using JobSite.BL.Auth;
using JobSite.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace JobSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly ICurrentUser currentUser;

        public HomeController(ILogger<HomeController> logger, ICurrentUser currentUser)
        {
            this.logger = logger;
            this.currentUser = currentUser;
        }

        public IActionResult Index()
        {
            bool logged = currentUser.IsLoggedIn();
            return View(logged);
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