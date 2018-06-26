using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using WCFWebService.Model;

namespace WCFWebService.Controllers
{
    public class RegistrazioneController
    {
        public RegistrazioneController()
        {

        }

        public static ISession OpenConnection()
        {
            Configuration myCfg = new Configuration();
            myCfg.Configure();
            ISessionFactory factory = myCfg.BuildSessionFactory();
            ISession sess = factory.OpenSession();
            return sess;
        }

        public static void InsertCliente(Cliente c)
        {
            try
            {

                ISession sess = OpenConnection();
                using (sess.BeginTransaction())
                {
                    //Cliente c = new Cliente("Mic", "Camp", "mic.cam.1", new DateTime(1996, 8, 11), "carnazza@bk.it", "3334445556");
                    sess.Persist(c);
                    sess.Transaction.Commit();
                }
            }
            catch (DuplicateMappingException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void InsertCredenziali(Credenziali credenziali)
        {
            ISession session = OpenConnection();
            using (session.BeginTransaction())
            {
                try
                {
                    session.Save(credenziali);
                    session.Transaction.Commit();
                }
                catch (DuplicateMappingException e)
                {
                    throw e;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public string RegistraCliente(Cliente c, string pw)
        {
            string result = null;
            int len = c.Telefono.Length;
            c.Username = c.Nome.ToLower() + "." + c.Cognome.ToLower() + "." + c.Telefono[5]+c.Telefono[6]+c.Telefono[7]+c.Telefono[8];
            Credenziali cr = new Credenziali(c.Username, pw, "cliente");
            try
            {
                InsertCredenziali(cr);
                InsertCliente(c);
                result = c.Username;
            } catch (Exception e)
            {
                result = "Non è stato possibile effettuare la registrazione! Account già presente.";
            }
            return result;
        }
    }
}