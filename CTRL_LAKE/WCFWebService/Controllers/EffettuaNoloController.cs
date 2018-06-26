using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCFWebService.Model;

namespace WCFWebService.Controllers
{
    public class EffettuaNoloController
    {
        private GestionePrenotazioniController gpc;

        public EffettuaNoloController(GestionePrenotazioniController gpc)
        {
            this.gpc = gpc;
        }

        public int[][] GetDisponibilita(DateTime date)
        {
            int[][] result = new int[10][];
            DateTime inizio = new DateTime(date.Year, date.Month, date.Day, 9, 0, 0);
            for (int i = 0; i < 10; i++) {
                DateTime fine = inizio.AddHours(1);
                result[i] = new int[4];
                foreach (Attrezzatura a in gpc.ElencoAttrezzatura)
                {
                    if (a.IsLibero(inizio, fine))
                        switch (a.Tipo)
                        {
                            case ("barcaVela"): result[i][0]++; break;
                            case ("canoa"): result[i][1]++; break;
                            case ("windsurf"): result[i][2]++; break;
                            case ("sup"): result[i][3]++; break;
                        }
                }
                inizio = inizio.AddHours(1);
            }
            return result;
        }

        public string CreaNoleggio(string username, DateTime inizio, DateTime fine, string[] attr, int[] persone)
        {
            string result = null;
            try
            {
                Cliente c = null;
                foreach (Cliente c1 in gpc.ElencoClienti)
                    if (c1.Username.Equals(username))
                    {
                        c = c1; break;
                    }
                Noleggio nolo = new Noleggio(gpc.NewId(), c, inizio, fine);
                for (int i=0; i<attr.Length; i++)
                {
                    foreach (Attrezzatura a in gpc.ElencoAttrezzatura)
                        if (a.Tipo.Equals(attr[i]) && a.IsLibero(inizio, fine))
                        {
                            IDettaglioPagamento dettaglio = new DettaglioNoleggio(nolo.Id, persone[i],
                                a,/*MOCK COSTO*/99.99, inizio, fine, username);
                            /***PERSISTENZA IDETTAGLIO***/
                            nolo.AddDettaglio((DettaglioNoleggio) dettaglio);
                        }
                }
                Pagamento pag = new Pagamento(nolo.Id, 0);
                foreach (IDettaglioPagamento idp in nolo.ElencoDettagli)
                    pag.AddDettaglio(idp);
                /***PERSISTENZA PAGAMENTO***/
                result = "La tua prenotazione è stata completata!";
            } catch(Exception e)
            {
                Console.WriteLine(e);
                result = "Si è verificato un errore, la tua prenotazione non è andata a buon fine.\n" +
                    "Controlla di non aver richiesto attrezzatura non disponibile.";
            }
            return result;
        }

    }
}