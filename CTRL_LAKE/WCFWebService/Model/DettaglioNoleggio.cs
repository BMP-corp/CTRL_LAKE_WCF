using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using WCFWebService;

namespace WCFWebService.Model
{
    [DataContract]
    public class DettaglioNoleggio : IDettaglioPagamento
    {
        private int _id;
        private int _utilizzatori;
        private double _costo;
        private Attrezzatura _attrezzatura;
        private int _idAttrezzatura;
        private string _username;
        private DateTime _inizio;
        private DateTime _fine;

        [DataMember]
        public virtual int Id { get => _id; set => _id = value; }
        [DataMember]
        public virtual int Utilizzatori { get => _utilizzatori; set => _utilizzatori = value; }
        [DataMember]
        public virtual double Costo { get => _costo; set => _costo = value; }
        [DataMember]
        public virtual Attrezzatura Attrezzatura { get => _attrezzatura; set => _attrezzatura = value; }
        [DataMember]
        public virtual int IdAttrezzatura { get => _idAttrezzatura; set => _idAttrezzatura = value; }
        [DataMember]
        public virtual string Username { get => _username; set => _username = value; }
        [DataMember]
        public virtual DateTime Fine { get => _fine; set => _fine = value; }
        [DataMember]
        public virtual DateTime Inizio { get => _inizio; set => _inizio = value; }

        public DettaglioNoleggio(int id, int utilizzatori, Attrezzatura attrezzatura, double costo, DateTime inizio, DateTime fine, string usernameCliente)
        {

            if (attrezzatura == null)
                throw new Exception("Impossibile creare dettaglio noleggio: campo attrezzatura nullo");
            if (costo <= 0)
                throw new Exception("Impossibile creare dettaglio noleggio: costo non valido");

            _id = id;
            _attrezzatura = attrezzatura;
            try
            {
                _attrezzatura.Riserva(inizio, fine, utilizzatori);
            } catch (Exception e)
            {
                throw e;
            }
            _utilizzatori = utilizzatori;
            _costo = costo;
            _idAttrezzatura = attrezzatura.IdAttrezzatura;
            _username = usernameCliente;
            

        }


        public DettaglioNoleggio() {
        }

        public override bool Equals(Object dettaglio)
        {
            DettaglioNoleggio dt = (DettaglioNoleggio)dettaglio;
            if (IdAttrezzatura == dt.IdAttrezzatura && Id == dt.Id)
                return true;
            else return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


        public virtual double CalcolaCosto()
        {
            return _costo;
        }

        public virtual int GetId()
        {
            return _id;
        }


        public virtual string ToString()
        {
            string result;
            result = "ID " + _id + ": " + _attrezzatura + ", " + _utilizzatori + " persone, " + this._costo + "€";
            return result;
        }

        public virtual void Elimina(DateTime inizio, DateTime fine)
        {
            try
            {
                _attrezzatura.Libera(inizio, fine);
            } catch (Exception e)
            {
                throw e;
            }
        }
        
    }
}