using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVCTempl.ServiceReference1;

namespace WebMVCTempl.Controllers
{
    public class ClienteController : Controller
    {
        ServicesClient webClient = new ServicesClient();
        public ActionResult HomeCliente()
        {
            if (Session["Username"] != null)
            {

                //if (!initialized)
                //{
                //    init();
                //}
                //var username = Request.QueryString["username"];
                //Cliente c = null;
                //foreach (Cliente c1 in elencoClienti)
                //{
                //    if (c1.Username.Equals(username))
                //    {
                //        c = c1; break;
                //    }
                //}
                //if (c == null)
                //    return Redirect("/Home/Index");
                ViewData["Message"] = "";
                if (Request.RequestType.Equals("POST"))
                {
                    try
                    {
                        int daEliminare = Int32.Parse(Request.Form["todelete"]);

                        string res = webClient.CancellaPrenotazione(daEliminare);

                        ViewData["Message"] = "res";
                    }
                    catch (Exception e)
                    {
                        System.Diagnostics.Debug.WriteLine(e.Message);
                        ViewData["Message"] = "Non è stato possibile rimuovere la prenotazione";
                    }
                }
                Cliente c = webClient.getCliente();
                Noleggio[] noleggi = webClient.GetPrenotazioni((string)Session["Username"]);
                //List<Noleggio> noleggi = webClient.GetPrenotazioni((string)Session["Username"]);
                
                
                ViewData["Cliente"] = c;
                ViewData["Noleggi"] = noleggi;
                return View();
            }
            else return RedirectToAction("../Account/Login");
        }
    }
}