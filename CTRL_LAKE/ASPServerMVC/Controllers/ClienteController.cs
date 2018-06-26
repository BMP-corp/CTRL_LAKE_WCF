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
                ViewData["Message"] = "";
                if (Request.RequestType.Equals("POST"))
                {
                    try
                    {
                        int daEliminare = Int32.Parse(Request.Form["todelete"]);

                        string res = webClient.CancellaPrenotazione(daEliminare);

                        ViewData["Message"] = res; 
                    }
                    catch (Exception e)
                    {
                        System.Diagnostics.Debug.WriteLine(e.Message);
                        ViewData["Message"] = "Non è stato possibile rimuovere la prenotazione";
                    }
                }
                Cliente c = webClient.GetCliente((string)Session["Username"]);
                Noleggio[] noleggi = webClient.GetPrenotazioni((string)Session["Username"]);
                string[][] lezioni = webClient.GetLezioni((string)Session["Username"]);
                
                
                ViewData["Cliente"] = c;
                ViewData["Noleggi"] = noleggi;
                ViewData["Lezioni"] = lezioni;
                if (TempData["Message"] != null)
                    ViewData["Message"] = TempData["Message"];
                return View();
            }
            else return RedirectToAction("../Account/Login");
        }



        
        public ActionResult EffettuaNolo()
        {
            if (Request.RequestType.Equals("POST"))
            {
                if (Request.Form["formname"].Equals("form1"))
                {
                    /////richiesta per cambio data ( => visualizzazione disponibilità)
                    DateTime date = DateTime.Parse(Request.Form["data"]);
                    ViewData["MapAttrezzature"] = webClient.DisponibilitaAttrezzatura(date);
                    ViewData["SelectedData"] = date;
                    return View();
                }
                else ///richiesta per effettuare il noleggio
                {
                    DateTime date = DateTime.Parse(Request.Form["data"]);
                    int start = Int32.Parse(Request.Form["starttime"]);
                    int end = Int32.Parse(Request.Form["endtime"]);
                    DateTime inizio = new DateTime(date.Year, date.Month, date.Day, start, 0, 0);
                    DateTime fine = new DateTime(date.Year, date.Month, date.Day, end, 0, 0);
                    int numDettagli = Int32.Parse(Request.Form["totali"]);
                    string[] tipoAttr = new string[numDettagli];
                    int[] numPersone = new int[numDettagli];
                    string user = (string) Session["Username"];
                    for (int i=0; i<numDettagli; i++)
                    {
                        tipoAttr[i] = Request.Form["attr" + i];
                        numPersone[i] = Int32.Parse(Request.Form["pers" + i]);
                    }
                    /*******/
                    string message = webClient.CreaNoleggio((string)Session["Username"], inizio, fine, tipoAttr, numPersone);
                    /*******/
                    TempData["Message"] = message;
                    return RedirectToAction("../Cliente/HomeCliente");
                }
            }
            else        //GET: primo accesso alla pagina, si vogliono vedere le disponibilita' di oggi
            {
                ViewData["MapAttrezzature"]=webClient.DisponibilitaAttrezzatura(DateTime.Today);
                ViewData["SelectedData"] = DateTime.Today;
                return View();
            }

            return View();
        }


        public ActionResult PrenotaLezione()
        {
            if (Request.RequestType.Equals("POST"))
            {
                if (Request.Form["formname"].Equals("form1"))
                {
                    /////richiesta per cambio data ( => visualizzazione disponibilità)
                    DateTime date = DateTime.Parse(Request.Form["data"]);
                    string attivita = Request.Form["attivita"];
                    ViewData["MapAttrezzature"] = webClient.DisponibilitaAttrezzatura(date);
                    ViewData["MapIstruttori"] = webClient.DisponibilitaIstruttori(date, attivita);
                    ViewData["SelectedData"] = date;
                    ViewData["SelectedActivity"] = attivita;
                    return View();
                }
                else ///richiesta per effettuare il noleggio (da form2)
                {
                    DateTime date = DateTime.Parse(Request.Form["data"]);
                    int start = Int32.Parse(Request.Form["starttime"]);
                    int end = Int32.Parse(Request.Form["endtime"]);
                    string istr = Request.Form["nomeistr"];
                    DateTime inizio = new DateTime(date.Year, date.Month, date.Day, start, 0, 0);
                    DateTime fine = new DateTime(date.Year, date.Month, date.Day, end, 0, 0);
                    int partecipanti = Int32.Parse(Request.Form["partecipanti"]);
                    string attivita = Request.Form["attivita"];

                    /*******/
                    string message = webClient.CreaLezione((string)Session["Username"],inizio,fine,istr,partecipanti, attivita);
                    /*******/
                    TempData["Message"] = message;
                    return RedirectToAction("../Cliente/HomeCliente");
                }
            }
            else        //GET: primo accesso alla pagina, si vogliono vedere le disponibilita' di oggi
            {
                ViewData["MapIstruttori"] = webClient.DisponibilitaIstruttori(DateTime.Today, "barcaVela");
                ViewData["MapAttrezzature"] = webClient.DisponibilitaAttrezzatura(DateTime.Today);
                ViewData["SelectedData"] = DateTime.Today;
                ViewData["SelectedActivity"] = "barcaVela";
                return View();
            }
        }
    }

}