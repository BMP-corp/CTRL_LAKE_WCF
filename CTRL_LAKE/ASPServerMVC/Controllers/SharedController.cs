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
        HttpWebServiceClient webClient = new HttpWebServiceClient();
        public ActionResult Home()
        {
            return View();
        }
    }
}