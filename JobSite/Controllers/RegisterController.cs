using System;
using JobSite.BL.Auth;
using JobSite.ViewMapper;
using JobSite.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace JobSite.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IAuthBL authBL;
        public RegisterController(IAuthBL authBL)
        {
            this.authBL = authBL;
        }

        [HttpGet]
        [Route("/register")]
        public IActionResult Index()
        {
            return View("Index", new RegisterViewModel());
        }

        [HttpPost]
        [Route("/register")]
        public IActionResult Index(RegisterViewModel model)
        {
            if (ModelState.IsValid)
                authBL.CreateUser(AuthMapper.MapRegisterViewModelToUserModel(model));

            return View("Index", model);
        }
    }
}
