using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVCTempl.ServiceReference1;

namespace WebMVCTempl.Controllers
{
    public class SharedController : Controller
    {
        // GET: Home
        ServicesClient webClient = new ServicesClient();
        public ActionResult Home()
        {
            return View();
        }
    }
}