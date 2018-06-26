using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServerRichieste.Controller;

namespace ServerRichieste.Model
{
    public class Prove
    {

        public static void Main()
        {

            GestioneAttrezzaturaController gat = new GestioneAttrezzaturaController();

            bool result = gat.aggiornaAttrezzatura("barca", 1);
            if (result)
            {
                System.Diagnostics.Debug.WriteLine("attrezzatura aggiornata correttamente!");
            }

        }
    }
}