using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Threading.Tasks;
using WCFWebService;

namespace WCFWebService.Model
{
    [DataContract]
    public class Lezione : IDettaglioPagamento
    {
        private int _id;
        private Istruttore _istruttore;
        private DateTime _inizio;
        private DateTime _fine;
        private int _partecipanti;
        private Cliente _cliente;
        private double _costo;
        private string _usernameIstruttore;
        private string _usernameCliente;
        

        [DataMember]
        public virtual int Id { get => _id; set => _id = value; }

        [DataMember]
        public virtual Istruttore Istruttore { get => _istruttore; set => _istruttore = value; }

        [DataMember]
        public virtual DateTime Inizio { get => _inizio; set => _inizio = value; }

        [DataMember]
        public virtual DateTime Fine { get => _fine; set => _fine = value; }

        [DataMember]
        public virtual int Partecipanti { get => _partecipanti; set => _partecipanti = value; }

        [DataMember]
        public virtual Cliente Cliente { get => _cliente; set => _cliente = value; }

        [DataMember]
        public virtual double Costo { get => _costo; set => _costo = value; }

        public Lezione(int id, Istruttore istruttore, DateTime inizio, DateTime fine, int partecipanti, Cliente cliente, double costo)
        {

            if (inizio.CompareTo(fine) >= 0)
                throw new Exception("Impossibile creare lezione: intervallo non valido");
            if (inizio.TimeOfDay.CompareTo(new TimeSpan(9, 0, 0)) < 0
                || fine.TimeOfDay.CompareTo(new TimeSpan(19, 0, 0)) > 0)
                throw new Exception("Impossibile creare lezione: orari non possibili");
            if (!inizio.Date.Equals(fine.Date))
                throw new Exception("Impossibile creare lezione: non ammessi inizio e fine in due giorni distinti");
            if (partecipanti <= 0 || partecipanti > 5)
                throw new Exception("Impossibile creare lezione: numero partecipanti non valido");
            if (costo <= 0)
                throw new Exception("Impossibile creare lezione: costo non valido");
            
            Id = id;
            Istruttore = istruttore;
            try
            {
                Istruttore.Riserva(inizio, fine);
            }
            catch (Exception e) { throw e; }
            _inizio = inizio;
            _fine = fine;
            _partecipanti = partecipanti;
            _cliente = cliente;
            _costo = costo;
            _usernameCliente = cliente.Username;
            _usernameIstruttore = istruttore.Username;
        }

        public Lezione(int id, Istruttore istruttore, DateTime inizio, DateTime fine, int partecipanti, Cliente cliente)
        {

            if (inizio.CompareTo(fine) >= 0)
                throw new Exception("Impossibile creare lezione: intervallo non valido");
            if (inizio.TimeOfDay.CompareTo(new TimeSpan(9, 0, 0)) < 0
                || fine.TimeOfDay.CompareTo(new TimeSpan(19, 0, 0)) > 0)
                throw new Exception("Impossibile creare lezione: orari non possibili");
            if (!inizio.Date.Equals(fine.Date))
                throw new Exception("Impossibile creare lezione: non ammessi inizio e fine in due giorni distinti");
            if (partecipanti <= 0 || partecipanti > 5)
                throw new Exception("Impossibile creare lezione: numero partecipanti non valido");

            Id = id;
            Istruttore = istruttore;
            try
            {
                Istruttore.Riserva(inizio, fine);
            } catch (Exception e) { throw e; }
            _inizio = inizio;
            _fine = fine;
            _partecipanti = partecipanti;
            _cliente = cliente;
            _usernameCliente = cliente.Username;
            _usernameIstruttore = istruttore.Username;
        }
        
        public virtual int GetId()
        {
            return Id;
        }
        
        public virtual double CalcolaCosto()
        {
           return Costo;
        }

        public override string ToString()
        {
            string result;
            result = "ID: " + Id + " ISTRUTTORE: " + Istruttore + " CLIENTE: " + Cliente;
            return result;
        }
    }
}