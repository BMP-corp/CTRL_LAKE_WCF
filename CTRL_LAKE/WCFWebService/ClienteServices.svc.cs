using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFWebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "HttpWebService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select HttpWebService.svc or HttpWebService.svc.cs at the Solution Explorer and start debugging.
    public class ClienteServices : IServices
    {
        private static GestionePrenotazioniController gpc = new GestionePrenotazioniController();

        public Cliente getCliente()
        {
#if MOCK
            Cliente c = new Cliente("Luca", "Braga", "luca.braga.21", new DateTime(2015, 05, 05), "bella@tin.it", "3478478002");
            return c;
#else
            //database implementation
#endif
        }

        public string CancellaPrenotazione (int daEliminare)
        {

            Noleggio n = null;
            
            foreach (Noleggio nol in gpc.ElencoNoleggi)
                if (nol.Id == daEliminare)
                {
                    n = nol; break;
                }
            try
            {
                for (int i = n.ElencoDettagli.Count - 1; i >= 0; i--)
                {
                    // METODO PERSISTENZA DELETE DETTAGLIO
                    n.ElencoDettagli[i].Elimina(n.Inizio, n.Fine);
                    n.RimuoviDettaglio(n.ElencoDettagli[i]);
                }
                gpc.ElencoNoleggi.Remove(n);
            }
            catch (Exception e) { return "Non è stato possibile rimuovere la prenotazione"; }
            return "Prenotazione Rimossa!";
        }

        public List<Noleggio> GetPrenotazioni(string username)
        {
            List<Noleggio> noleggi = new List<Noleggio>();
            foreach (Noleggio nol in gpc.ElencoNoleggi)
            {
                if (nol.Cliente.Username.Equals(username))
                    noleggi.Add(nol);
            }

            return noleggi;

        }

        public UserAccount Login(string username)
        {
            throw new NotImplementedException();
        }

        public UserAccount GetUser(string username)
        {
            throw new NotImplementedException();
        }

        public string Register(UserAccount user)
        {
            throw new NotImplementedException();
        }

        public string DeleteUser(UserAccount user)
        {
            throw new NotImplementedException();
        }
    }
}
