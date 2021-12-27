using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WP.Controllers
{
    [Authorize]
    public class AdminPageController : Controller
    {
        // GET
       [Authorize(Roles ="Admin")]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Editor")]
        public ActionResult Index2()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Index3()
        { 
            return View();
        }
    }
}