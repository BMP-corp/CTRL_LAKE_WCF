using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using WebMVCTempl.Models;
using WebMVCTempl.ServiceReference1;

namespace WebMVCTempl.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        ServicesClient webClient = new ServicesClient();
        //public ActionResult Index()
        //{
        //    //using(OurDbContext db = new OurDbContext())
        //    //    return View(db.UserAccount.ToList());
        //    return View(webClient.Get)
        //}

        //mostra la pagina di registrazione (http request)
        public ActionResult Register()
        {
            return View();
        }

        //invia la POST con i dati di registrazione e salva su db
        //[HttpPost]
        //public ActionResult Register(UserAccount account)
        //{
        //    account.Username = account.Nome + "." + account.Cognome;
        //    string esito = webClient.Register(account);
        //    if (esito == account.Username)
        //    { 
        //    //if (ModelState.IsValid)
        //    //{
        //    //salvataggio dati su db MM$ da sostituire con call API WCF
        //    //using (OurDbContext db = new OurDbContext())
        //    //{

        //    //    db.UserAccount.Add(account);
        //    //    db.SaveChanges();
        //    //}



        //        ModelState.Clear(); //pulisce il contenuto di tutti gli input controls 
        //        ViewBag.Message = account.Nome + " " + account.Cognome + "" + " registrato correttamente. Username: "+account.Username;
                
        //    }else
        //        ViewBag.Message = "Errore Nella registrazione dell'account. Controlla i campi";
        //    return View();
        //}

        //get metodo per visualizzare Login
        public ActionResult Login()
        {
            if (TempData["Message"] != null)                    //TempData["nome_dato"] per passare dati tra controller (redirect)
                ViewData["Message"] = TempData["Message"];
            if (Request.RequestType.Equals("POST"))
            {
                string username = Request.Form["username"];
                string password = Request.Form["password"];
                if (username != null && password != null)
                {
                    Credenziali account = webClient.Login(username, password);
                    {
                        if (account != null)
                        {
                            switch (account.Ruolo)
                            {
                                case ("cliente"): Session["Username"] = account.Username; return RedirectToAction("../Cliente/HomeCliente");
                                case ("istruttore"): Session["Username"] = account.Username; return RedirectToAction("../Istruttore/HomeIstruttore");
                                case ("amministratore"): Session["Username"] = account.Username; return RedirectToAction("../Admin/HomeAmministratore");
                            }
                        }
                        ModelState.AddModelError("", "Username o Password errati.");

                    }
                }
            }
            return View();
        }


    }
}