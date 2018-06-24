using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVCTempl.ServiceReference1;

namespace WebMVCTempl.Controllers
{
    public class RegistrazioneController : Controller
    {
        ServicesClient webClient = new ServicesClient();

        public ActionResult Registra()
        {
            if (Request.RequestType.Equals("POST"))
            {
                try
                {
                    string nome = Request.Form["nome"];
                    string cognome = Request.Form["cognome"];
                    DateTime datanascita = DateTime.Parse(Request.Form["data"]);
                    string email = Request.Form["email"];
                    string telefono = Request.Form["telefono"];
                    string pw = Request.Form["password"];
                    string ruolo = Request.Form["ruolo"];
                    if (ruolo.Equals("cliente"))
                    {
                        Cliente c = new Cliente();
                        c.Nome = nome;
                        c.Cognome = cognome;
                        c.DataNascita = datanascita;
                        c.Email = email;
                        c.Telefono = telefono;
                        string esito = webClient.Register(c, pw);
                        if (!esito.StartsWith("Non è stato possibile effettuare la registrazione!"))
                            //TempData["nome_dato"] per passare dati tra controller (redirect)
                            TempData["Message"] = "Registrazione effettuata! Il tuo username è " + esito + ", non scordartelo!";
                        else
                            TempData["Message"] = esito;
                        return RedirectToAction("../Account/Login");
                    }
                    else if (ruolo.Equals("istruttore"))
                    {
                        string iban = Request.Form["iban"];
                        string attivita = Request.Form["attivita"];
                        string orario = Request.Form["orario"];
                        // COMPLETARE PER AMMINISTRATORE
                    }

                    
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e.Message);
                    ViewData["Message"] = "Errore";
                }
            }
            return View("Register");
        }
    }
}