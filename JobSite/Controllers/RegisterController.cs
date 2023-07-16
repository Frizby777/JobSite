using System;
using System.ComponentModel.DataAnnotations;
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
        public async Task<IActionResult> IndexSave(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                ValidationResult errorModel = await authBL.ValidateEmail(model.Email ?? "");
                if (errorModel != null)
                {
                    ModelState.TryAddModelError("Email", errorModel.ErrorMessage!);
                }
            }

            if(ModelState.IsValid)
            {
                await authBL.CreateUser(AuthMapper.MapRegisterViewModelToUserModel(model));
                return Redirect("/");
            }
            return View("Index", model);
        }
    }
}
