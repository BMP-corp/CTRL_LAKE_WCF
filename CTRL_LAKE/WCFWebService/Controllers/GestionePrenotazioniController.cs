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
        private static HashSet<Lezione> elencoLezioni;
        private static HashSet<Noleggio> elencoNoleggi = new HashSet<Noleggio>();
        private static bool initialized = false;

        private static int curr_id;

        public HashSet<Lezione> ElencoLezioni { get => elencoLezioni; set => elencoLezioni = value; }
        public HashSet<Attrezzatura> ElencoAttrezzatura { get => elencoAttrezzatura; set => elencoAttrezzatura = value; }
        public HashSet<Noleggio> ElencoNoleggi { get => elencoNoleggi; set => elencoNoleggi = value; }

        
        public GestionePrenotazioniController()
        {
            if (!initialized)
                init();
        }
        private void init()
        {
            Attrezzatura a = new Attrezzatura("barcaVela", NewId(), 5);
            ElencoAttrezzatura.Add(a);
            ElencoAttrezzatura.Add(new Attrezzatura("barcaVela", NewId(), 5));
            ElencoAttrezzatura.Add(new Attrezzatura("canoa", NewId(), 2));
            Cliente c = new Cliente("Michele", "Campa", "Cliente", new DateTime(1996, 8, 11), "mc@ampa.it", "123456789");
            elencoClienti.Add(c);
            Noleggio nol = new Noleggio(NewId(), c, new DateTime(2018, 6, 28, 10, 0, 0), new DateTime(2018, 6, 28, 11, 0, 0));
            nol.AddDettaglio(new DettaglioNoleggio(nol.Id, 4, a, 45, new DateTime(2018, 6, 28, 10, 0, 0), new DateTime(2018, 6, 28, 11, 0, 0), "mc@ampa.it"));
            ElencoNoleggi.Add(nol);
            initialized = true;
        }

        // generazione degli ID (incrementale)
        public int NewId()
        {
            return curr_id++;
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


        public HashSet<Attrezzatura> getDbAttrezzatura(DbConnection conn)
        {
            throw new NotImplementedException();
        }

        public HashSet<Cliente> getDbClienti(DbConnection conn)
        {
            throw new NotImplementedException();
        }

        public HashSet<Istruttore> getDbIstruttori(DbConnection conn)
        {
            throw new NotImplementedException();
        }
    }
}