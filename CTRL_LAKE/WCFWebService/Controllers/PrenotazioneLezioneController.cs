﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCFWebService.Controllers.Interfaces;
using WCFWebService.Model;

namespace WCFWebService.Controllers
{
    public class PrenotazioneLezioneController 
    {
        private GestionePrenotazioniController gpc;

        public PrenotazioneLezioneController(GestionePrenotazioniController gpc)
        {
            this.gpc=gpc;
        }



        // GET: PrenotazioneLezione
        //public ActionResult Index()
        //{
        //    return View();
        //}
        

        public Lezione creaLezione(DateTime inizio, DateTime fine, Cliente c, Istruttore i, int partecipanti, int id)
        {

            Lezione lezione = null;
            try
            {
                lezione = new Lezione(gpc.NewId(), i, inizio, fine, partecipanti, c);
                /*operazione di retrieve del costo della lezione*/ double costo = 30;
                lezione.Costo = costo;
                gpc.ElencoLezioni.Add(lezione); //qui o in GestionePrenotazioniController?
            } catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            return lezione;
        }

        public void eliminaLezione(int id)
        {
            throw new NotImplementedException();
        }

        //public Dictionary<int, List<Attrezzatura>> mostraDisponibilitaAttrezzatura(DateTime giorno, string tipo)
        //{
        //    DateTime dt, dt2;
        //    List<Attrezzatura> attr;
        //    Dictionary<int, List<Attrezzatura>> res = new Dictionary<int, List<Attrezzatura>>();
        //    for (int ora = 9; ora <= 18; ora++)
        //    {
        //        dt = new DateTime(giorno.Year, giorno.Month, giorno.Day, ora, 0, 0);
        //        dt2 = new DateTime(giorno.Year, giorno.Month, giorno.Day, ora+1, 0, 0);
        //        attr = new List<Attrezzatura>();
        //        foreach (Attrezzatura a in ctrl.ElencoAttrezzatura)
        //            if (a.IsLibero(dt, dt2))
        //                attr.Add(a);
        //        res.Add(ora-8, attr);
                        
        //    }
        //    return res;
        //}

        public List<string>[] GetDisponibilitaIstruttori(DateTime date, string attivita)
        {
            List<string>[] result = new List<string>[10];
            DateTime inizio = new DateTime(date.Year, date.Month, date.Day, 9, 0, 0);
            for (int i = 0; i < 10; i++)
            {
                DateTime fine = inizio.AddHours(1);
                result[i] = new List<string>();
                foreach (Istruttore istr in gpc.ElencoIstruttori)
                {
                    if (istr.IsLibero(inizio, fine) && istr.Attivita == attivita)
                        result[i].Add(istr.Nome);
                }
                inizio = inizio.AddHours(1);
            }
            return result;
        }
    }
}