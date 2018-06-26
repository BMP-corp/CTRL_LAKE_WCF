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

        ////mostra la pagina di registrazione (http request)
        //public ActionResult Register()
        //{
        //    return View();
        //}

        ////invia la POST con i dati di registrazione e salva su db
        //[HttpPost]
        //public ActionResult Register(UserAccount account)
        //{
        //    account.Username = account.Nome + "." + account.Cognome;
        //    //string esito = webClient.Register(account);
        //    //if (esito == account.Username)
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
            return View();
        }

        //metodo POST per effettuare il login
        [HttpPost]
        public ActionResult Login(UserAccount user)
        {   //LOCALDB
            //using (OurDbContext db = new OurDbContext())
            //{
            //    var usr = db.UserAccount.Single(u => u.Username == user.Username && u.Password == user.Password);
            //    if (usr != null)
            //    {
            //        //Session["UserID"] = user.UserID.ToString();
            //        Session["Username"] = user.Username.ToString();
            //        return RedirectToAction("LoggedIn");
            //    }
            //    else
            //    {
            //        ModelState.AddModelError("", "Username or Password errati.");
            //    }
            //}
            if (user != null)
            {
                UserAccount usr = webClient.Login(user.Username);
                if (usr != null)
                {
                    Session["Username"] = user.Username.ToString();
                    if (usr.AccountRole == "Cliente")
                        return RedirectToAction("../Cliente/HomeCliente");
                    else if (usr.AccountRole == "Istruttore")
                        return RedirectToAction("../Istruttore/HomeIstruttore");
                    else if (usr.AccountRole == "Admin")
                        return RedirectToAction("../Admin/HomeAmministratore");
                    else if (usr.AccountRole == "Segreteria")
                        return RedirectToAction("../Segreteria/HomeSegreteria");
                    else if (usr.AccountRole == "Bar")
                        return RedirectToAction("../Bar/HomeBar");
                    else ModelState.AddModelError("", "Utente non assegnato. Chi diavolo sei? Contatta subito l'Amministratore!");
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password errati. Sforzati un po'.");
                }
            }
            return View();
        }


        //TODO MM$ DA SISTEMARE: non riceve nessun tipo di account, quindi non può rimuoverlo
        //    public ActionResult DeleteUser(UserAccount account)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            using (OurDbContext db = new OurDbContext())
        //            {
        //                db.UserAccount.Remove(account);
        //                db.SaveChanges();

        //            }
        //            ModelState.Clear(); //pulisce il contenuto di tutti gli input controls 
        //            ViewBag.Message ="Account " + account.Username + ":" + account.Username + " Rimosso Correttamente.";
        //        }
        //        return RedirectToAction("Index");
        //    }
    }
}