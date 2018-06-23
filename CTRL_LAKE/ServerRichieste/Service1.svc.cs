using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.Loquacious;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;


namespace ServerRichieste
{
    // NOTA: è possibile utilizzare il comando "Rinomina" del menu "Refactoring" per modificare il nome di classe "Service1" nel codice, nel file svc e nel file di configurazione contemporaneamente.
    // NOTA: per avviare il client di prova WCF per testare il servizio, selezionare Service1.svc o Service1.svc.cs in Esplora soluzioni e avviare il debug.
    public class Service1 : DEP_IService1
    {
        public Noleggio GetNoleggio()
        {
            Configuration configuration = new Configuration();
            configuration.Configure();
            ISessionFactory sessionFactory = configuration.BuildSessionFactory();
            ISession session = sessionFactory.OpenSession();

            Cliente cliente=null;

            
            cliente = readCliente("mic.cam.1");

            //Cliente cliente = new Cliente("Matteo", "Menzo", "matteo.menzo.2", new DateTime(1995, 2, 5), "matteo@gmail.com", "123456789");
         
            Noleggio n = new Noleggio(123, cliente, new DateTime(2018, 6, 23, 12, 00, 00), new DateTime(2018, 6, 23, 13, 00, 00));
            
            return n;
        }



        public static Cliente readCliente(String username)
        {
            Cliente res = null;
            Configuration myCfg = new Configuration();
            myCfg.Configure();
            ISessionFactory factory = myCfg.BuildSessionFactory();
            ISession sess = factory.OpenSession();
            using (sess.BeginTransaction())
            {
                ICriteria criteria = sess.CreateCriteria<Cliente>();
                criteria.Add(Expression.Like("Username", username));
                try
                {
                    res = criteria.List<Cliente>()[0];
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return res;
        }


    }
}
