﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using WCFWebService;
using System.Text;
using System.Threading.Tasks;

namespace WCFWebService.Model
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
        private string _orario;

        [DataMember]
        public virtual string Nome { get => _nome; set => _nome = value; }

        [DataMember]
        public virtual string Cognome { get => _cognome; set => _cognome = value; }

        [DataMember]
        public virtual string Username { get => _username; set => _username = value;  }

        [DataMember]
        public virtual DateTime DataNascita { get => _dataNascita; set => _dataNascita = value; }

        [DataMember]
        public virtual string Email { get => _email; set => _email = value; }

        [DataMember]
        public virtual string Telefono { get => _telefono; set => _telefono = value; }

        [DataMember]
        public virtual string Iban { get => _iban; set => _iban = value; }

        [DataMember]
        public virtual string Attivita { get => _attivita; set => _attivita = value; }

        [DataMember]
        public virtual string Orario { get => _orario; set => _orario = value; }

        [DataMember]
        public virtual CalendarioImpegni Impegni { get => _impegni; set => _impegni = value; }

        public Istruttore()
        {
            Impegni = new CalendarioImpegni(Username);
        }

        public Istruttore(string nome, string cognome, string username, DateTime dataNascita,
            string email, string telefono, string iban, string attivita, string orario)
        {
            Nome = nome;
            Cognome = cognome;
            Username = username;
            DataNascita = dataNascita;
            Email = email;
            Telefono = telefono;
            Iban = iban;
            Attivita = attivita;
            _impegni = new CalendarioImpegni(Username);
            if (!orario.Equals("mattina") && !orario.Equals("pomeriggio"))
            {
                throw new Exception("tipo di orari istruttore non corretto");
            }
            _orario = orario;
        }

 

        public virtual List<Impegno> elencaImpegni()
        {
            return this.Impegni.Impegni;
        }

        public virtual bool IsLibero(DateTime inizio, DateTime fine)
        {
            bool result = true;
            Impegno richiesto = null;
            if (Orario.Equals("mattina")
                && fine.TimeOfDay.CompareTo(new TimeSpan(14, 0, 0)) > 0)
                return false;
            if (Orario.Equals("pomeriggio")
                && inizio.TimeOfDay.CompareTo(new TimeSpan(14, 0, 0)) < 0)
                return false;
            try
            {
                richiesto = new Impegno(inizio, fine, Username);
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

        public virtual void Riserva(DateTime inizio, DateTime fine)
        {
            try
            {
                if(this.Impegni.Impegni != null)
                {
                    this.Impegni.Aggiungi(inizio, fine);
                }
                else
                {
                    this.Impegni = new CalendarioImpegni(this.Username);
                    this.Impegni.Aggiungi(inizio, fine);
                }
                
            }
            catch (Exception e) { throw e; }
        }

        public virtual void Libera(DateTime inizio, DateTime fine)
        {
            try
            {
                this.Impegni.Rimuovi(inizio, fine);
            }
            catch (Exception e) {
                throw e;
            }
        }

        public virtual void SetUsername(string username)
        {
            Username = username;
            Impegni.Id_user = username;
        }

    }
}
