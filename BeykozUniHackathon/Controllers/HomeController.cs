using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeykozUniHackathon.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            if (Session["AppUserId"] != null)
            {
                //kullanıcı login olmuş ise
                return View();
            }
            // login olmadıysa
            return this.RedirectToAction("Index", "Login");
        }

        
    }
}