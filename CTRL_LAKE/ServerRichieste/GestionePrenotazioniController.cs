using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerRichieste
{
    public class GestionePrenotazioniController
    {

        private List<Cliente> elencoClienti;
        private List<Istruttore> elencoIstruttori;
        private List<Attrezzatura> elencoAttrezzatura;
        private List<Noleggio> elencoNoleggi;
        private List<Lezione> elencoLezioni;

        public List<Cliente> ElencoClienti { get => elencoClienti; set => elencoClienti = value; }
        public List<Istruttore> ElencoIstruttori { get => elencoIstruttori; set => elencoIstruttori = value; }
        public List<Attrezzatura> ElencoAttrezzatura { get => elencoAttrezzatura; set => elencoAttrezzatura = value; }
        public List<Noleggio> ElencoNoleggi { get => elencoNoleggi; set => elencoNoleggi = value; }
        public List<Lezione> ElencoLezioni { get => elencoLezioni; set => elencoLezioni = value; }

        public GestionePrenotazioniController()
        {
            ElencoClienti = GetListaClienti();
            ElencoIstruttori = GetListaIstruttori();
            ElencoAttrezzatura = GetListaAttrezzature();
            ElencoLezioni = GetListaLezioni();
            ElencoNoleggi = GetListaNoleggi();
        }



        public static ISession OpenConnection()
        {
            Configuration myCfg = new Configuration();
            myCfg.Configure();
            ISessionFactory factory = myCfg.BuildSessionFactory();
            ISession sess = factory.OpenSession();
            return sess;
        }


        public static Cliente GetClienteByNome(string nome)
        {
            Cliente res = null;
            ISession sess = OpenConnection();
            using (sess.BeginTransaction())
            {
                ICriteria criteria = sess.CreateCriteria<Cliente>();
                criteria.Add(Expression.Like("Nome", nome));
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


        public static Cliente GetClienteByUsername(string username)
        {
            Cliente res = null;
            ISession sess = OpenConnection();
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


        public static Cliente GetClienteByCognome(string cognome)
        {
            Cliente res = null;
            ISession sess = OpenConnection();
            using (sess.BeginTransaction())
            {
                ICriteria criteria = sess.CreateCriteria<Cliente>();
                criteria.Add(Expression.Like("Cognome", cognome));
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


        public static Cliente GetClienteByNomeCognome(string nome, string cognome)
        {
            Cliente res = null;
            ISession sess = OpenConnection();
            using (sess.BeginTransaction())
            {
                ICriteria criteria = sess.CreateCriteria<Cliente>();
                criteria.Add(Expression.Like("Cognome", cognome));
                criteria.Add(Expression.Like("Nome", nome));
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

        public static List<Cliente> GetListaClienti()
        {
            List<Cliente> res = null;
            ISession sess = OpenConnection();
            using (sess.BeginTransaction())
            {
                ICriteria criteria = sess.CreateCriteria<Cliente>();
                try
                {
                    res = (List<Cliente>) criteria.List<Cliente>();
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return res;
        }

        public static List<Attrezzatura> GetListaAttrezzature()
        {
            List<Attrezzatura> res = null;
            ISession sess = OpenConnection();
            using (sess.BeginTransaction())
            {
                ICriteria criteria = sess.CreateCriteria<Attrezzatura>();
                try
                {
                    res = (List<Attrezzatura>)criteria.List<Attrezzatura>();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return res;
        }

        public static List<Istruttore> GetListaIstruttori()
        {
            List<Istruttore> res = null;
            ISession sess = OpenConnection();
            using (sess.BeginTransaction())
            {
                ICriteria criteria = sess.CreateCriteria<Istruttore>();
                try
                {
                    res = (List<Istruttore>)criteria.List<Istruttore>();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return res;
        }

        public static List<Noleggio> GetListaNoleggi()
        {
            List<Noleggio> res = null;
            ISession sess = OpenConnection();
            using (sess.BeginTransaction())
            {
                ICriteria criteria = sess.CreateCriteria<Noleggio>();
                try
                {
                    res = (List<Noleggio>)criteria.List<Noleggio>();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return res;
        }

        public static List<Lezione> GetListaLezioni()
        {
            List<Lezione> res = null;
            ISession sess = OpenConnection();
            using (sess.BeginTransaction())
            {
                ICriteria criteria = sess.CreateCriteria<Lezione>();
                try
                {
                    res = (List<Lezione>)criteria.List<Lezione>();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return res;
        }


        public static void Main()
        {
            Cliente cliente = GetClienteByNome("Giulia");
            System.Diagnostics.Debug.WriteLine(cliente.ToString());
            Console.ReadLine();
            cliente = GetClienteByCognome("Bologna");
            Console.WriteLine(cliente.ToString());
            Console.ReadLine();
            cliente = GetClienteByNomeCognome("Giulia", "Bologna");
            Console.WriteLine(cliente.ToString());
            Console.ReadLine();
            cliente = GetClienteByUsername("giulia.bologna.1");
            Console.WriteLine(cliente.ToString());
            Console.ReadLine();
        }
    }
}