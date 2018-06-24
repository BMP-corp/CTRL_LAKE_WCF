using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace WCFWebService.Model
{
    [DataContract]
    public class UserAccount
    {
        //qui vengono inserite le proprietà dell' utente
        /*
         * [Attributi] 
         * [key]
         * [Required] -> identifica campo obbligatorio con possibilità di inserire messaggio d'errore.
         * [RegularExpression] -> per verifica dei campi
         */

        [DataMember]
        [Key]
        [Required(ErrorMessage = "Username Obbligatorio")]
        public string Username { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Nome Obbligatorio")]
        public string Nome { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Cognome Obbligatorio")]
        public string Cognome { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Mail Obbligatoria")]
        //[RegularExpression("*.@*")] da implementare MM$
        public string Email { get; set; }

        [DataMember]
        //[Required(ErrorMessage = "Telefono Obbligatorio")]
        public string Telefono { get; set; }

        [DataMember]
        public string AccountRole { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Password Obbligatoria")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //[DataMember]
        //[Compare("Password",ErrorMessage = "Please Confirm your password.")]
        //[DataType(DataType.Password)]
        //public string ConfirmPassword { get; set; }
    }
}