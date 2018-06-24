using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using WCFWebService;

namespace WCFWebService.Model
{
    [DataContract]
    public class Noleggio
    {
        private int _id;
        private Cliente _cliente;
        private DateTime _inizio;
        private DateTime _fine;
        private List<DettaglioNoleggio> _elencoDettagli;

        [DataMember]
        public virtual int Id { get => _id; set => _id = value; }
        [DataMember]
        public virtual Cliente Cliente { get => _cliente; set => _cliente = value; }
        [DataMember]
        public virtual DateTime Inizio { get => _inizio; set => _inizio = value; }
        [DataMember]
        public virtual DateTime Fine { get => _fine; set => _fine = value; }
        [DataMember]
        public virtual List<DettaglioNoleggio> ElencoDettagli { get => _elencoDettagli; set => _elencoDettagli = value; }

        public Noleggio(int id, Cliente cliente, DateTime inizio, DateTime fine)
        {
            if ( id<0 || cliente == null || inizio == null || fine == null )
                throw new Exception("Creazione Noleggio fallita, uno o più campi inseriti non sono corretti");
            if (!dateVerified(inizio,fine))
                throw new Exception("Creazione Noleggio fallita, intervallo non valido");
                this.Id = id;
                this.Cliente = cliente;
                this.Inizio = inizio;
                this.Fine = fine;
                this.ElencoDettagli = new List<DettaglioNoleggio>();
           
        }

        public Noleggio() { 
        }

        private static bool dateVerified(DateTime inizio, DateTime fine)
        {
            if (inizio.CompareTo(fine) >= 0)
                return false;
            else if (inizio.TimeOfDay.CompareTo(new TimeSpan(9, 0, 0)) <= 0 || fine.TimeOfDay.CompareTo(new TimeSpan(19, 0, 0)) >= 0)
                return false;
            else if (!inizio.Date.Equals(fine.Date))
                return false;
            else return true;
        }

        

        /****BUSINESS****/
        public virtual void AddDettaglio(DettaglioNoleggio dettaglio)
        {
            //bool giaPresente = false;
            if (dettaglio != null)
            {
                //foreach (DettaglioNoleggio dt in this._elencoDettagli)
                //    if (dt.Id == dettaglio.Id)
                //    {
                //        giaPresente = true;
                //        break;
                //    }
                //if (giaPresente)
                //    throw new Exception("Dettaglio già inserito");
                //else
                    this.ElencoDettagli.Add(dettaglio);
            }   
        }

        public virtual void RimuoviDettaglio(DettaglioNoleggio dettaglio)
        {
            if (!this.ElencoDettagli.Remove(dettaglio))
                throw new Exception("Dettaglio non presente nella lista");
        }

    }//NOLEGGIO
}//END