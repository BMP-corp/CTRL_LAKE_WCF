using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Tool.hbm2ddl;
using WCFWebService.Model;

namespace WCFWebService.Controllers
{
    public class LoginController
    {
        public LoginController() { }

        public static ISession OpenConnection()
        {
            Configuration myCfg = new Configuration();
            myCfg.Configure();
            ISessionFactory factory = myCfg.BuildSessionFactory();
            ISession sess = factory.OpenSession();
            return sess;
        }

        public static Credenziali GetCredenzialiByUsername(string username)
        {
            
            Credenziali temp = null;
            ISession sess = OpenConnection();

            using (sess.BeginTransaction())
            {
                ICriteria criteria = sess.CreateCriteria<Credenziali>();
                try
                {
                    List<Credenziali> l = (List<Credenziali>)criteria.Add(Expression.Like("Username", username)).List<Credenziali>();
                    if (l.Count != 0)
                        temp = l[0];
                }
                catch (Exception e)
                {
                    Console.Write(e.Message);
                }

            }
            return temp;
        }

        public Credenziali VerificaLogin(string username, string password)
        {
            Credenziali result = GetCredenzialiByUsername(username);
            if (result != null && result.Password.Equals(password))
                return result;
            else
                return null;
        }

    }
}