using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ServerRichieste
{
    [DataContract]
    public class Istruttore
    {
        private string _nome;
        private string _cognome;
        private string _username;
        private DateTime _dataNascita;
        private string _email;
        private string _telefono;
        private string _iban;
        private string _attivita;
        private CalendarioImpegni _impegni;

        [DataMember]
        public string Nome { get => _nome; set => _nome = value; }
        [DataMember]
        public string Cognome { get => _cognome; set => _cognome = value; }
        [DataMember]
        public string Username { get => _username; set => _username = value; }
        [DataMember]
        public DateTime DataNascita { get => _dataNascita; set => _dataNascita = value; }
        [DataMember]
        public string Email { get => _email; set => _email = value; }
        [DataMember]
        public string Telefono { get => _telefono; set => _telefono = value; }
        [DataMember]
        public string Iban { get => _iban; set => _iban = value; }
        [DataMember]
        public string Attivita { get => _attivita; set => _attivita = value; }

        public Istruttore(string nome, string cognome, string username, DateTime dataNascita,
            string email, string telefono, string iban, string attivita)
        {
            Nome = nome;
            Cognome = cognome;
            Username = username;
            DataNascita = dataNascita;
            Email = email;
            Telefono = telefono;
            Iban = iban;
            Attivita = attivita;
            _impegni = new CalendarioImpegni();
        }

        public Istruttore ()
        {
            _impegni = new CalendarioImpegni();
        }

        public List<Impegno> elencaImpegni()
        {
            return this._impegni.Impegni;
        }

        public bool IsLibero(DateTime inizio, DateTime fine)
        {
            bool result = true;
            Impegno richiesto = null;
            try
            {
                richiesto = new Impegno(inizio, fine);
            }
            catch (Exception e) { throw e; }
            foreach (Impegno i in this.elencaImpegni())
                if (i.Inizio.Day == inizio.Day)
                    if (i.OverlapsWith(richiesto))
                    {
                        result = false;
                        break;
                    }
            return result;
        }

        public void Riserva(DateTime inizio, DateTime fine)
        {
            try
            {
                this._impegni.Aggiungi(inizio, fine);
            }
            catch (Exception e) { throw e; }
        }

        public void Libera(DateTime inizio, DateTime fine)
        {
            try
            {
                this._impegni.Rimuovi(inizio, fine);
            }
            catch (Exception e) { throw e; }
        }

    }
}
