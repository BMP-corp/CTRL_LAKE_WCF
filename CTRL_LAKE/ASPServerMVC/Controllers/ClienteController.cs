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
                    ViewData["Message"] = message;
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

    }

}