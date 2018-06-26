using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using NHibernate;
using WCFWebService.Model;
using WCFWebService.Controllers;

namespace WCFWebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Services" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Services.svc or Services.svc.cs at the Solution Explorer and start debugging.
    public class Services : IServices
    {
        private static GestionePrenotazioniController gpc = new GestionePrenotazioniController();
        private static LoginController lc = new LoginController();
        private static RegistrazioneController rc = new RegistrazioneController();

        public Credenziali Login(string username, string password)
        {
            Credenziali cr = lc.VerificaLogin(username, password);
            return cr;
        }



        public string GetString()
        {
#if MOCK
            return "BellaVez";
#else            
            //database implementation
#endif
        }



        public List<string> getList()
        {
            List<String> productList = new List<string>();
#if MOCK
            productList.Add("Prova2");
            productList.Add("Prova22");
            productList.Add("Prova222");
            productList.Add("Prova2222");
#else
             try
            {
                using(WCFPROVAEntities database = new WCFPROVAEntities())
                {
                    var products = from p in database.Listino
                                   select p.Nome;

                    productList = products.ToList();
                }
            }
            catch
            {
               
            }
#endif
            return productList;
        }



        public Cliente getCliente()
        {
#if MOCK
            Cliente c = new Cliente("Luca", "Braga", "luca.braga.21", new DateTime(2015, 05, 05), "bella@tin.it", "3478478002");
            return c;
#else
            //database implementation
#endif
        }

//        public UserAccount Login(String username)
//        {
//#if MOCK
//            UserAccount user = new UserAccount();
//            if (username == "Cliente")
//            {
//                user.Username = "Cliente";
//                user.Password = "c";
//                user.AccountRole = "Cliente";
//            }
//            else if (username == "Segreteria")
//            {
//                user.Username = "Segreteria";
//                user.Password = "s";
//                user.AccountRole = "Segreteria";
//            }
//            return user;
//#else
//            //data base implementation
//#endif
//        }

        public UserAccount GetUser(String username)
        {
#if MOCK
            UserAccount user = new UserAccount();
            if (username == "Zio.Pero")
            {
                user.Nome = "Zio";
                user.Cognome = "Pero";
                user.Email = "Ziopero@tin.it";
                user.Password = "m";
                user.Telefono = "347804848";
                user.Username = user.Nome + "." + user.Cognome;
            }
            return user;

#else
            //data base implementation
#endif
        }

        public string Register(Cliente c, string pw)
        {
            return rc.RegistraCliente(c, pw);
        }

        public string DeleteUser(UserAccount user)
        {
#if MOCK
            string confirmation = "nomeutenteeliminato";
            return confirmation;
#else
            //db implementation
#endif
        }



        public string CancellaPrenotazione(int daEliminare)
        {

            Noleggio n = null; Lezione l = null;
            bool foundNolo = false, foundLezione=false;
            foreach (Noleggio nol in gpc.ElencoNoleggi)
                if (nol.Id == daEliminare)
                {
                    n = nol; foundNolo = true;  break;
                }
            if (!foundNolo)
                foreach(Lezione lez in gpc.ElencoLezioni)
                    if (lez.Id == daEliminare)
                    {
                        l = lez; foundLezione = true; break;
                    }
            try
            {
                if (foundNolo)
                {
                    for (int i = n.ElencoDettagli.Count - 1; i >= 0; i--)
                    {
                        // METODO PERSISTENZA DELETE DETTAGLIO
                        n.ElencoDettagli[i].Elimina(n.Inizio, n.Fine);
                        n.RimuoviDettaglio(n.ElencoDettagli[i]);
                    }
                    gpc.ElencoNoleggi.Remove(n);
                }
                else if (foundLezione)
                {
                    // METODO PERSISTENZA DELETE LEZIONE (?)
                    gpc.ElencoLezioni.Remove(l);
                }
                else
                {
                    throw new Exception("NON TROVATO LEZIONE/NOLEGGIO DA ELIMINARE");
                }
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


        public List<string[]> GetLezioni(string username)
        {
            List<string[]> lezioni = new List<string[]>();
            foreach (Lezione lez in gpc.ElencoLezioni)
            {
                if (lez.Cliente.Username.Equals(username)
                    && lez.Inizio.CompareTo(DateTime.Today) >= 0)
                {
                    string[] l = new string[4];
                    l[0] = "" + lez.Id;
                    l[1] = lez.Inizio.ToString();
                    l[2] = lez.Fine.ToString();
                    l[3] = lez.Istruttore.Nome;
                    lezioni.Add(l);
                }
            }
            return lezioni;
        }


        public int[][] DisponibilitaAttrezzatura(DateTime date)
        {
            return gpc.Enc.GetDisponibilita(date);
        }

        public string CreaNoleggio(string user, DateTime inizio, DateTime fine, string[] attr, int[] pers)
        {
            return gpc.Enc.CreaNoleggio(user, inizio, fine, attr, pers);
        }

    }
}

