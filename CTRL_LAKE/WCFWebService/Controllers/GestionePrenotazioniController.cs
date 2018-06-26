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

        public HashSet<Lezione> ElencoLezioni { get => elencoLezioni; set => elencoLezioni = value; }
        public HashSet<Attrezzatura> ElencoAttrezzatura { get => elencoAttrezzatura; set => elencoAttrezzatura = value; }
        public HashSet<Noleggio> ElencoNoleggi { get => elencoNoleggi; set => elencoNoleggi = value; }
        public HashSet<Cliente> ElencoClienti { get => elencoClienti; set => elencoClienti = value; }
        public HashSet<Istruttore> ElencoIstruttori { get => elencoIstruttori; set => elencoIstruttori = value; }

        public EffettuaNoloController Enc { get => enc; set => enc = value; }
        public PrenotazioneLezioneController Plc { get => plc; set => plc = value; }
        
        public GestionePrenotazioniController()
        {
            Enc = new EffettuaNoloController(this);
            Plc = new PrenotazioneLezioneController(this);
            if (!initialized)
                init();
        }
        private void init()
        {
            Attrezzatura a = new Attrezzatura("barcaVela", NewId(), 5);
            ElencoAttrezzatura.Add(a);
            ElencoAttrezzatura.Add(new Attrezzatura("barcaVela", NewId(), 5));
            ElencoAttrezzatura.Add(new Attrezzatura("canoa", NewId(), 2));
            Cliente c = new Cliente("Michele", "Campa", "michele.campa.19", new DateTime(1996, 8, 11), "mc@ampa.it", "123456789");
            ElencoClienti.Add(c);
            Noleggio nol = new Noleggio(NewId(), c, new DateTime(2018, 6, 28, 10, 0, 0), new DateTime(2018, 6, 28, 11, 0, 0));
            nol.AddDettaglio(new DettaglioNoleggio(nol.Id, 4, a, 45, new DateTime(2018, 6, 28, 10, 0, 0), new DateTime(2018, 6, 28, 11, 0, 0), "mc@ampa.it"));
            ElencoNoleggi.Add(nol);
            Istruttore istr = new Istruttore("Francesco", "Mazzu", "francesco.mazzu.5678",
                new DateTime(1996,4,1,0,0,0), "framaz@gmail.com", "3334456789", "fakeIban", "barcaVela", "mattina");
            ElencoIstruttori.Add(istr);
            ElencoLezioni.Add(new Lezione(NewId(),istr, new DateTime(2018, 6, 29, 9, 0, 0), new DateTime(2018, 6, 29, 11, 0, 0), 1, c));
            initialized = true;
        }

        // generazione degli ID (incrementale)
        public int NewId()
        {
            return curr_id++;
        }
        


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