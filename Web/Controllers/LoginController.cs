using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Web.Models.Login;

namespace Web.Controllers
{
    public class LoginController
        : Controller
    {
        [HttpGet]
        public ActionResult LoginLink()
        {
            var cookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            if (cookie != null)
            {
                var userName = System.Threading.Thread.CurrentPrincipal.Identity.Name;

                return PartialView("_LoginLink", new LoginLinkUser { IsLoggedIn = true, Login = userName });
            }

            return PartialView("_LoginLink", new LoginLinkUser { IsLoggedIn = false });
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginUser user)
        {
            if (!string.IsNullOrWhiteSpace(user.UserName) &&
                !string.IsNullOrWhiteSpace(user.Password) &&
                ModelState.IsValid)
            {
                FormsAuthentication.SetAuthCookie(user.UserName, true);

                return RedirectToAction("Index", "Default");
            }

            return View(user);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Default");
        }
    }
}