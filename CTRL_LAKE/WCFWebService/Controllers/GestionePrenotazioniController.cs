using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;
using WCFWebService.Model;



namespace WCFWebService.Controllers
{
    public class GestionePrenotazioniController
    {
        private static HashSet<Attrezzatura> elencoAttrezzatura = new HashSet<Attrezzatura>();
        private static HashSet<Cliente> elencoClienti = new HashSet<Cliente>();
        private static HashSet<Istruttore> elencoIstruttori = new HashSet<Istruttore>();
        private static HashSet<Lezione> elencoLezioni = new HashSet<Lezione>();
        private static HashSet<Noleggio> elencoNoleggi = new HashSet<Noleggio>();
        private static bool initialized = false;

        private static int curr_id;

        private EffettuaNoloController enc;
        private PrenotazioneLezioneController plc;
        private GestioneAttrezzaturaController gap;

        public HashSet<Lezione> ElencoLezioni { get => elencoLezioni; set => elencoLezioni = value; }
        public HashSet<Attrezzatura> ElencoAttrezzatura { get => elencoAttrezzatura; set => elencoAttrezzatura = value; }
        public HashSet<Noleggio> ElencoNoleggi { get => elencoNoleggi; set => elencoNoleggi = value; }
        public HashSet<Cliente> ElencoClienti { get => elencoClienti; set => elencoClienti = value; }
        public HashSet<Istruttore> ElencoIstruttori { get => elencoIstruttori; set => elencoIstruttori = value; }


        public EffettuaNoloController Enc { get => enc; set => enc = value; }
        public PrenotazioneLezioneController Plc { get => plc; set => plc = value; }
        
        public GestioneAttrezzaturaController Gap { get => gap; set => gap = value; }

        public GestionePrenotazioniController()
        {
            Enc = new EffettuaNoloController(this);
            Plc = new PrenotazioneLezioneController(this);
            Gap = new GestioneAttrezzaturaController(this);

            if (!initialized)
                Init();
        }
        private void Init()
        {
            //Attrezzatura a = new Attrezzatura("barcaVela", NewId(), 5);
            //ElencoAttrezzatura.Add(a);
            //ElencoAttrezzatura.Add(new Attrezzatura("barcaVela", NewId(), 5));
            //ElencoAttrezzatura.Add(new Attrezzatura("canoa", NewId(), 2));
            //Cliente c = new Cliente("Michele", "Campa", "michele.campa.19", new DateTime(1996, 8, 11), "mc@ampa.it", "123456789");
            //ElencoClienti.Add(c);
            //Noleggio nol = new Noleggio(NewId(), c, new DateTime(2018, 6, 28, 10, 0, 0), new DateTime(2018, 6, 28, 11, 0, 0));
            //nol.AddDettaglio(new DettaglioNoleggio(nol.Id, 4, a, 45, new DateTime(2018, 6, 28, 10, 0, 0), new DateTime(2018, 6, 28, 11, 0, 0), "mc@ampa.it"));
            //ElencoNoleggi.Add(nol);
            //initialized = true;

            ElencoAttrezzatura = GetListaAttrezzatura();
            ElencoClienti = GetListaClienti();
            ElencoIstruttori = GetListaIstruttori();
            //ElencoLezioni = GetListaLezioni();
            ElencoNoleggi = GetListaNoleggi();
            initialized = true;

        }

        // generazione degli ID (incrementale)
        public int NewId()
        {
            return curr_id++;
        }

        public static ISession OpenConnection()
        {
            ISession sess = null;
            try
            {
                Configuration myCfg = new Configuration();
                myCfg.Configure();
                ISessionFactory factory = myCfg.BuildSessionFactory();
                sess = factory.OpenSession();
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return sess;
        }

        /*public GestionePrenotazioniController()
        {
            this.ElencoAttrezzatura = getDbAttrezzatura(c);
            this.elencoClienti = getDbClienti(c);
            this.elencoIstruttori = getDbIstruttori(c);
            //this.elencoLezioni = getDbLezioni();
            //this.elencoNoleggi = getDbNoleggi();
            curr_id = 100;
        }*/



        // GET: GestionePrenotazioni


        public static HashSet<Attrezzatura> GetListaAttrezzatura()
        {
            List<Attrezzatura> temp = null;
            HashSet<Attrezzatura> res = new HashSet<Attrezzatura>();
            List<Impegno> impegni = null;
            ISession sess = OpenConnection();
            using (sess.BeginTransaction())
            {
                ICriteria criteria = sess.CreateCriteria<Attrezzatura>();
                ICriteria critImp;
                try
                {
                    temp = (List<Attrezzatura>)criteria.List<Attrezzatura>();
                    foreach (Attrezzatura a in temp)
                    {
                        critImp = sess.CreateCriteria<Impegno>();
                        impegni = (List<Impegno>)critImp.Add(Expression.Like("Id_user", ""+a.IdAttrezzatura)).List<Impegno>();
                        foreach (Impegno imp in impegni)
                        {
                            a.Riserva(imp.Inizio, imp.Fine, a.Posti);
                        }
                        res.Add(a);
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return res;
        }

        public static List<DettaglioNoleggio> GetListaDettagliNoleggio()
        {
            List<DettaglioNoleggio> res = null;
            ISession sess = OpenConnection();
            using (sess.BeginTransaction())
            {
                ICriteria criteria = sess.CreateCriteria<DettaglioNoleggio>();
                try
                {
                    res = (List<DettaglioNoleggio>)criteria.List<DettaglioNoleggio>();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return res;
        }



        public static HashSet<Cliente> GetListaClienti()
        {

            HashSet<Cliente> res = new HashSet<Cliente>();
            Cliente cliente = null;
            List<Credenziali> temp = null;
            ISession sess = OpenConnection();
            using (sess.BeginTransaction())
            {

                ICriteria criteriaCredenziali = sess.CreateCriteria<Credenziali>();
                ICriteria criteriaClienti;


                try
                {
                    //leggo dal database tutti gli username dei clienti 
                    temp = (List<Credenziali>)criteriaCredenziali.Add(Expression.Like("Ruolo", "cliente")).List<Credenziali>();

                    foreach (Credenziali cred in temp)
                    {
                        criteriaClienti = sess.CreateCriteria<Cliente>();
                        //per ogni username cerco il cliente corrispondente nella tabella utenti
                        cliente = criteriaClienti.Add(Expression.Like("Username", cred.Username)).List<Cliente>()[0];
                        //aggiungo il cliente alla lista clienti
                        res.Add(cliente);
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return res;
        }

        public static HashSet<Istruttore> GetListaIstruttori()
        {
            HashSet<Istruttore> res = new HashSet<Istruttore>();
            List<Credenziali> temp = null;
            List<Impegno> impegni = null;
            List<Istruttore> list = null;
            ISession sess = OpenConnection();
            using (sess.BeginTransaction())
            {
                ICriteria criteriaIstruttori;
                ICriteria criteriaCredenziali = sess.CreateCriteria<Credenziali>();
                ICriteria critImp;

                try
                {
                    //leggo dal database tutti gli username dei clienti 
                    temp = (List<Credenziali>)criteriaCredenziali.Add(Expression.Like("Ruolo", "istruttore")).List<Credenziali>();

                    foreach (Credenziali cred in temp)
                    {
                        //per ogni username cerco il Istruttore corrispondente nella tabella utenti
                        criteriaIstruttori = sess.CreateCriteria<Istruttore>();
                        criteriaIstruttori.Add(Expression.Like("Username", cred.Username));
                        list = (List<Istruttore>)criteriaIstruttori.List<Istruttore>();

                        
                        foreach(Istruttore i in list)
                        {
                            critImp = sess.CreateCriteria<Impegno>();
                            impegni = (List<Impegno>)critImp.Add(Expression.Like("Id_user", i.Username)).List<Impegno>();
                            foreach (Impegno imp in impegni)
                            {
                                i.Riserva(imp.Inizio, imp.Fine);
                            }
                            //aggiungo istruttore alla lista istruttori
                            res.Add(i);
                        }
                        
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return res;
        }

        public static HashSet<Noleggio> GetListaNoleggi()
        {
            HashSet<Noleggio> res = new HashSet<Noleggio>();
            List<DettaglioNoleggio> temp;
            bool aggiunto = false;
            ISession sess = OpenConnection();

            try
            {
                temp = GetListaDettagliNoleggio();
                foreach (DettaglioNoleggio dt in temp)
                {

                    foreach (Noleggio n in res)
                    {
                        if (n.Id == dt.Id)
                        {
                            n.ElencoDettagli.Add(dt);
                            aggiunto = true;
                        }

                    }
                    if (!aggiunto)
                    {

                        foreach (Cliente c in elencoClienti)
                        {
                            if (c.Username.Equals(dt.Username))
                            {
                                Noleggio n = new Noleggio(dt.Id, c, dt.Inizio, dt.Fine);
                                n.ElencoDettagli.Add(dt);
                                res.Add(n);

                            }
                        }

                    }
                    aggiunto = false;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return res;
        }

        public static HashSet<Lezione> GetListaLezioni()
        {

            HashSet<Lezione> res = new HashSet<Lezione>();
            List<Lezione> temp = null;
            ISession sess = OpenConnection();
            using (sess.BeginTransaction())
            {
                ICriteria criteria = sess.CreateCriteria<Lezione>();
                try
                {
                    temp = (List<Lezione>)criteria.List<Lezione>();
                    foreach (Lezione l in temp)
                        res.Add(l);

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