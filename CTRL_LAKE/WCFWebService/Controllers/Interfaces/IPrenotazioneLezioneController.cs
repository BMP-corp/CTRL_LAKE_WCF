using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WCFWebService.Interfaces
{
    interface IPrenotazioneLezioneController
    {

        Lezione creaLezione(DateTime inizio, DateTime fine, Cliente c, Istruttore i,int partecipanti, int id);
        void eliminaLezione(int id);
        Dictionary<int, Istruttore[]> mostraDisponibilitaIstruttori(DateTime giorno, String tipo);
        Dictionary<int, List<Attrezzatura>> mostraDisponibilitaAttrezzatura(DateTime giorno, String tipo);
    }
}
