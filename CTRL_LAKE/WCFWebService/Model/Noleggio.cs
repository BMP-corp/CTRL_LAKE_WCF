﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFWebService
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
        public int Id { get => _id; set => _id = value; }
        [DataMember]
        public Cliente Cliente { get => _cliente; set => _cliente = value; }
        [DataMember]
        public DateTime Inizio { get => _inizio; set => _inizio = value; }
        [DataMember]
        public DateTime Fine { get => _fine; set => _fine = value; }
        [DataMember]
        public List<DettaglioNoleggio> ElencoDettagli { get => _elencoDettagli; set => _elencoDettagli = value; }

        public Noleggio(int id, Cliente cliente, DateTime inizio, DateTime fine)
        {
            if (id < 0 || cliente == null || inizio == null || fine == null)
                throw new Exception("Creazione Noleggio fallita, uno o più campi inseriti non sono corretti");
            if (!dateVerified(inizio, fine))
                throw new Exception("Creazione Noleggio fallita, intervallo non valido");
            this._id = id;
            this._cliente = cliente;
            this._inizio = inizio;
            this._fine = fine;
            this._elencoDettagli = new List<DettaglioNoleggio>();

        }

        public Noleggio()
        {
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

        ///****GET/SET****/
        //public int Id
        //{
        //    get { return _id; }
        //    set { _id = value; }
        //}

        //public Cliente Cliente
        //{
        //    get { return _cliente; }
        //    set { _cliente = value; }
        //}

        //public DateTime Inizio
        //{
        //    get { return _inizio; }
        //    set { _inizio = value; }
        //}

        //public DateTime Fine
        //{
        //    get { return _fine; }
        //    set { _fine = value; }
        //}

        //public List<DettaglioNoleggio> DettaglioNoleggio
        //{
        //    get { return _elencoDettagli; }

        //}

        /****BUSINESS****/
        public void AddDettaglio(DettaglioNoleggio dettaglio)
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
                this._elencoDettagli.Add(dettaglio);
            }
        }

        public void RimuoviDettaglio(DettaglioNoleggio dettaglio)
        {
            //foreach (DettaglioNoleggio dn in _elencoDettagli)
            //    if (dn.Equals(dettaglio))
            //    {
            //        bool rimosso = _elencoDettagli.Remove(dn);
            //        if (rimosso == false)
            //        {
            //            throw new Exception("Dettaglio non presente nella lista");
            //        }
            //    }

            if (!this._elencoDettagli.Remove(dettaglio))
                throw new Exception("Dettaglio non presente nella lista");
        }

    }//NOLEGGIO
}//END