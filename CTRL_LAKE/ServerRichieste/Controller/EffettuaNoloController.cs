using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerRichieste.Controller
{
    public class EffettuaNoloController
    {
        private GestionePrenotazioniController gpc;

        private bool CreaNoleggio(DateTime inizio, DateTime fine, Cliente c)
        {
            bool result = true;
            try
            {
                Noleggio n = new Noleggio(gpc.NewId(), c, inizio, fine);
            } catch (Exception e) {
                result = false;
            }
            return result;
        }

        private bool AggiungiANoleggio(int id, Attrezzatura a, int utilizzatori)
        {
            bool result = true;
            try
            {
                Noleggio nol = gpc.NoloById(id);
                IDettaglioPagamento dettaglio = new DettaglioNoleggio(id, utilizzatori, a, 999.99, nol.Inizio, nol.fine);
            } catch (Exception e)
            {
                result = false;
            }
            return result;
        }

    }
}