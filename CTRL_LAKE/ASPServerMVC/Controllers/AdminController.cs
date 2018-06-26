using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVCTempl.ServiceReference1;

namespace WebMVCTempl.Controllers
{
    public class AdminController : Controller
    {
        private Dictionary<string, int[]> map = new Dictionary<string, int[]>();
        private bool initialized = false;

        ServicesClient webClient = new ServicesClient();
        // GET: Admin
        public ActionResult HomeAmministratore()
        {
            if (Session["Username"] != null)
                return View();
            else return RedirectToAction("../Account/Login");
        }

        public ActionResult GestioneAttrezzatura()
        {
            if (!initialized)
                Init();
            ViewData["Message"] = "";
            if (Request.RequestType.Equals("POST"))
            {
                string tipoDaAggiornare = Request.Form["tipo_attrezzatura"];
                int quantita = Int32.Parse(Request.Form["quantity"]);
                /*** operazioni sul model ***/
                map[tipoDaAggiornare][0] += quantita;
                map[tipoDaAggiornare][1] += quantita;
                /****************************/
                ViewData["Message"] = "Operazione Completata";
            }
            ViewData["MapAttrezzature"] = map;
            return View();
        }

        public void Init()
        {
            int[] barca = new int[2] { 2, 2 };
            int[] canoa = new int[2] { 3, 2 };
            int[] windsurf = new int[2] { 0, 0 };
            int[] sup = new int[2] { 0, 0 };
            //Attrezzatura[] attrezzature = webClient.GetAttrezzatura();
            //foreach (Attrezzatura a in attrezzature)
            //{
            //    if (a.Tipo.Equals("barcaVela"))
            //    {
            //        barca[0]++;
            //    }
            //    else if (a.Tipo.Equals("canoa"))
            //    {
            //        canoa[0]++;
            //    }
            //    else if (a.Tipo.Equals("windsurf"))
            //    {
            //        windsurf[0]++;
            //    }
            //    else
            //    {
            //        sup[0]++;
            //    }
            //}
            map.Add("barcaVela", barca);
            map.Add("canoa", canoa);
            map.Add("windsurf", windsurf);
            map.Add("sup", sup);

            initialized = true;
        }
    }
}