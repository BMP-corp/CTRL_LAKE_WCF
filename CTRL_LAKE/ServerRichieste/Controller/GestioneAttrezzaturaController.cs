using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerRichieste.Controller
{
    public class GestioneAttrezzaturaController
    {
        private GestionePrenotazioniController gpc;

        public IDictionary<string, int[]> showAttrezzatura()
        {
            IDictionary<string, int[]> result = new Dictionary<string, int[]>();
            foreach (Attrezzatura a in gpc.ElencoAttrezzatura)
            {
                int canc = a.isCancellabile() ? 1 : 0;      // canc = 1 se a cancellabile, 0 altrimenti
                if (!result.Keys.Contains(a.Tipo))          //tipo non ancora inserito nella mappa
                {
                    int[] tot_canc = new int[2];            //[0]: totali  ,  [1]: cancellabili
                    tot_canc[0] = 1; tot_canc[1] = canc;    //totali=1, cancellabili=canc
                    result.Add(a.Tipo, tot_canc);
                }
                else                            //tipo già presente nella mappa
                {
                    result[a.Tipo][0]++;        //incremento il numero totale
                    result[a.Tipo][1] += canc;  //cancellabili += canc
                }
            }
            return result;
        }


        public bool aggiornaAttrezzatura (string attrezzatura, int quantita) //Attrezzatura o string tipo?
        {                                                                    //per ora metto tipo
            bool result = false;
            if (quantita > 0)
            {
                while (quantita > 0)
                {
                    Attrezzatura a = new Attrezzatura(attrezzatura, gpc.NewId(), AttrPosti(attrezzatura));
                    /* gpc.insertAttrezzatura(a) */ // METODO PERSISTENZA
                    gpc.ElencoAttrezzatura.Add(a);
                    quantita--;
                }
            }
            else
            {
                foreach (Attrezzatura a in gpc.ElencoAttrezzatura)
                {
                    while (quantita < 0)
                    {
                        if (a.Tipo == attrezzatura && a.isCancellabile())
                        {
                            /* gpc.deleteAttrezzatura(a.Id) */ // METODO PERSISTENZA
                            gpc.ElencoAttrezzatura.Remove(a);
                            break;
                        }
                        quantita++;
                    }
                }
            }
            result = (quantita == 0);
            return result;
        }



        private int AttrPosti(string tipoAttr)
        {
            int result = 1;
            switch (tipoAttr)
            {
                case ("barcaVela"): result = 5; break;
                case ("canoa"): result = 2; break;
                default: result = 1; break;
            }
            return result;
        }

    }
}