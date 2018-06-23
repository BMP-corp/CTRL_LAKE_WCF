using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMVCTempl.Controllers
{
    public class BarController : Controller
    {
        /*
         * NON IMPLEMENTATO IN QUESTA RELEASE
         */
        public ActionResult HomeBar()
        {
            if (Session["Username"] != null)
                return View();
            else return RedirectToAction("../Account/Login");
        }
        // GET: Bar
        public ActionResult Index()
        {
            return View();
        }
    }
}