using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerRichieste.Controller
{
    public class GestionePrenotazioniController
    {
        private static int id = 100;
        private List<Attrezzatura> elencoAttrezzatura;
        private List<Cliente> elencoClienti;
        private List<Noleggio> elencoNoleggi;

        public List<Attrezzatura> ElencoAttrezzatura { get => elencoAttrezzatura; set => elencoAttrezzatura = value; }
        public List<Noleggio> ElencoNoleggi { get => elencoNoleggi; set => elencoNoleggi = value; }
        public List<Cliente> ElencoClienti { get => elencoClienti; set => elencoClienti = value; }

        public int NewId() { return id++; }

        public Noleggio NoloById(int id)
        {
            foreach(Noleggio n in elencoNoleggi) {
                if (n.Id == id)
                    return n;
            }
            return null;
        }
    }
}