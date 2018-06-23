using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFWebService
{
    [DataContract]
    public class Pagamento
    {
        private DateTime _dataOra;
        private int _id;
        private double _totale;
        private double _pagato;
        private List<IDettaglioPagamento> _dettagli;

        [DataMember]
        public DateTime DataOra { get => _dataOra; set => _dataOra = value; }
        [DataMember]
        public int Id { get => _id; set => _id = value; }
        [DataMember]
        public double Totale { get => _totale; set => _totale = value; }
        [DataMember]
        public double Pagato { get => _pagato; set => _pagato = value; }
        [DataMember]
        public List<IDettaglioPagamento> Dettagli { get => _dettagli; set => _dettagli = value; }

        public Pagamento(int id, double pagato)
        {
            if ( id < 0 || pagato < 0 )
                throw new Exception("Creazione Pagamento non riuscita, dati non validi");

            this.Id = id;
            this.Pagato = pagato;
            this._dataOra = DateTime.Now;
            this.Dettagli = new List<IDettaglioPagamento>();
            this.Totale = CalcolaTotale();
        }

        public Pagamento () {
            this._dataOra = DateTime.Now;
            this.Dettagli = new List<IDettaglioPagamento>();
            this.Totale = CalcolaTotale();
        }

        ///*****GET/SET******/
        //public double Totale 
        //{
        //    get { return _totale; }
        //    set { _totale = value; }
        //}

        //public double Pagato
        //{
        //    get { return _pagato; }
        //    set { _pagato = value; }
        //}

        //public DateTime DataOra
        //{
        //    get { return _dataOra; }
        //    set { _dataOra = value; }
        //}

        //public int Id
        //{
        //    get { return _id; }
        //    set { _id = value; }
        //}

        //public List<IDettaglioPagamento> Dettagli
        //{
        //    get { return _dettagli; }
        //    set { _dettagli = value; }
        //}



        /*****BUSINESS******/
        public void AddDettaglio(IDettaglioPagamento dettaglio)
        {
           bool exists = false;
            foreach (IDettaglioPagamento d in Dettagli)
                if (d.GetId() == dettaglio.GetId())
                {
                    exists = true;
                    break;
                }
            if (!exists)
            {
                Dettagli.Add(dettaglio);
                Totale = CalcolaTotale();
            }
            else throw new Exception("Dettaglio già esistente");
        }

        public bool IsPagato()
        {
            if (this.Pagato == this.Totale)
                return true;
            else return false;
        }

 
        public void Paga() //se non c'è importo si assume che paghi tutto
        {
            this.Pagato = this.Totale;
            _dataOra = DateTime.Now;
        }

        public double CalcolaTotale()
        {
            double totale = 0;
            foreach(IDettaglioPagamento d in this.Dettagli)
                totale += d.CalcolaCosto();
            return totale;
        }
 
    }
}//END