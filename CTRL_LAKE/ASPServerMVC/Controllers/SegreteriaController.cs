using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMVCTempl.Controllers
{
    public class SegreteriaController : Controller
    {
        // GET: Segreteria
        public ActionResult HomeSegreteria()
        {
            if (Session["Username"] != null)
                return View();
            else return RedirectToAction("../Account/Login");
        }
    }
}