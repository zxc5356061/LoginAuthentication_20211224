using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WP.Models.Interfeces;
using WP.Models.Repositories;
using WP.Models.Services;
using WP.Models.ViewModels;

namespace WP.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Authorize] /*[Authorize] only visible when login*/
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Login(LoginVM model)
        {
            ISecRepository repo = new SecurityRepository();
            SecurityService loginLogic = new SecurityService(repo);
            if (loginLogic.IsValid(model.Account, model.Password) == false) 
            {
                ModelState.AddModelError(string.Empty, "Your accountID or Password is incorrect!");
            }

            if (ModelState.IsValid)
            {
                //FormsAuthentication.RedirectFromLoginPage(model.Account, false);//Login? returnURL= null
                //return null;

                HttpCookie cookie;
                var returnUrl = loginLogic.ProcessLogin(model.Account, false, out cookie);
                Response.Cookies.Add(cookie);
                return Redirect(returnUrl);
            }
            else
            {
                return View();
            }
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}