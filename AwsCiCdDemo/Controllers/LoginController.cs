using AwsCiCdDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AwsCiCdDemo.Controllers
{
    public class LoginController : Controller
    {
        private AuthService authService;

        public LoginController()
        {
            this.authService = AuthService.Instance;
        }

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.title = "Login: AWS CI/CD Demo";
            return View();
        }

        [HttpPost]
        public ActionResult Index(string password)
        {
            bool success = authService.authenticate(HttpContext.Response, password);
            if (success)
            {
                return new RedirectResult("/home");
            }

            ViewBag.loginUnsuccessful = true;
            return View();
        }
    }
}