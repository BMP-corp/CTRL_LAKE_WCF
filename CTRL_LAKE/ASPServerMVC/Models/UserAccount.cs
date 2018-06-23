#if ASPUNIQUE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebMVCTempl.Models
{
    public class UserAccount
    {
        //qui vengono inserite le proprietà dell' utente
        /*
         * [Attributi] 
         * [key]
         * [Required] -> identifica campo obbligatorio con possibilità di inserire messaggio d'errore.
         * [RegularExpression] -> per verifica dei campi
         */


        [Key]
        [Required(ErrorMessage = "Username Obbligatorio")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Nome Obbligatorio")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Cognome Obbligatorio")]
        public string Cognome { get; set; }

        [Required(ErrorMessage = "Mail Obbligatoria")]
        //[RegularExpression("*.@*")] da implementare MM$
        public string Email { get; set; }

        //[Required(ErrorMessage = "Telefono Obbligatorio")]
        public string Telefono { get; set; }

        //[Required(ErrorMessage = "Il Tipo di Account deve essere definito")]
        //public string AccountType { get; set; }

        [Required(ErrorMessage = "Password Obbligatoria")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password",ErrorMessage = "Please Confirm your password.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
#endif