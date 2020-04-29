using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using reCAPTCHAv3.Models;
using reCAPTCHAv3.Services;

namespace reCAPTCHAv3.Controllers
{
    public class HomeController : Controller
    {

        private readonly ReCAPTCHAService _reCAPTCHAService;
        public HomeController(ReCAPTCHAService reCAPTCHAService)
        {
            _reCAPTCHAService = reCAPTCHAService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            var response = _reCAPTCHAService.VerifyCaptcha(model.Token);

            if (!response.Result.Success && response.Result.Score <= 0.5)
            {
                ModelState.AddModelError(string.Empty, "You are not human.");
                return View("Error");
            }

            if (model.Email == "berkancep@gmail.com" && model.Password == "123456")
            {
                return View("Success");

            }

            ModelState.AddModelError(string.Empty, "Username or password is wrong.");
            return View("Error");

        }

    }
}
