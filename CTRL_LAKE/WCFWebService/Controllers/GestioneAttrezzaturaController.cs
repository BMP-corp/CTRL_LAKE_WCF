using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCFWebService.Model;


namespace WCFWebService.Controllers
{
    public class GestioneAttrezzaturaController
    {
        private GestionePrenotazioniController _gpc;
        private Dictionary<string, int[]> map = new Dictionary<string, int[]>();
        private bool initialized = false;

        public GestioneAttrezzaturaController(GestionePrenotazioniController gpc)
        {
            _gpc = gpc;
        }

        public static ISession OpenConnection()
        {
            Configuration myCfg = new Configuration();
            myCfg.Configure();
            ISessionFactory factory = myCfg.BuildSessionFactory();
            ISession sess = factory.OpenSession();
            return sess;
        }

        public static void InsertAttrezzatura(Attrezzatura attrezzatura)
        {
            ISession session = OpenConnection();
            using (session.BeginTransaction())
            {
                try
                {
                    session.Save(attrezzatura);
                    session.Transaction.Commit();
                }
                catch (Exception e)
                {
                    Console.Write(e.Message);
                }
            }

        }

        public static void DeleteAttrezzatura(int id)
        {
            ISession session = OpenConnection();
            using (session.BeginTransaction())
            {

                try
                {
                    Attrezzatura attrezzatura = (Attrezzatura)session.CreateCriteria<Attrezzatura>()
                        .Add(Restrictions.Eq("IdAttrezzatura", id)).UniqueResult();
                    session.Delete(attrezzatura);
                    session.Transaction.Commit();

                }
                catch (Exception e)
                {
                    Console.Write(e.Message);
                }
            }

        }

        public bool AggiornaAttrezzatura(Attrezzatura a, int quantita)
        {
            bool result = false;
            a.IdAttrezzatura = _gpc.NewId();
            List<Attrezzatura> temp = new List<Attrezzatura>();
            if (quantita > 0)
            {
                while (quantita > 0)
                {
                    InsertAttrezzatura(a);
                    _gpc.ElencoAttrezzatura.Add(a);
                    quantita--;
                }
            }
            else
            {
                foreach (Attrezzatura attr in _gpc.ElencoAttrezzatura)
                {
                    while (quantita < 0)
                    {

                        if (attr.Tipo == a.Tipo && attr.isCancellabile())
                        {
                            temp.Add(attr);
                            quantita++;
                            
                        //    DeleteAttrezzatura(attr.IdAttrezzatura);
                        //    _gpc.ElencoAttrezzatura.RemoveWhere(s => s.IdAttrezzatura==attr.IdAttrezzatura);
                        //    quantita++;
                        //    break;
                        }
                        break;

                    }
                    if (quantita == 0) break;
                }
                foreach(Attrezzatura a1 in temp)
                {
                    DeleteAttrezzatura(a1.IdAttrezzatura);
                    _gpc.ElencoAttrezzatura.Remove(a1);
                }

            }
            result = (quantita == 0);
            return result;
        }

       
    }
}