using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WP.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}