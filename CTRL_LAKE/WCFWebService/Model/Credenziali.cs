using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace WCFWebService.Model
{
    [DataContract]
    public class Credenziali
    {

        private string _username;
        private string _password;
        private string _ruolo;

        [DataMember]
        public virtual string Username { get => _username; set => _username = value; }
        [DataMember]
        public virtual string Password { get => _password; set => _password = value; }
        [DataMember]
        public virtual string Ruolo { get => _ruolo; set => _ruolo = value; }

        public Credenziali()
        {

        }

        public Credenziali(string username, string password, string ruolo)
        {
            _username = username;
            _password = password;
            _ruolo = ruolo;

        }
    }
}