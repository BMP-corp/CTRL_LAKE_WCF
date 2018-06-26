using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFWebService.Model;

namespace WCFWebService
{    //un bel commento
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServices" in both code and config file together.
    [ServiceContract]
    public interface IServices
    {
        [OperationContract]
        Credenziali Login(string username, string password);

        [OperationContract]
        UserAccount GetUser(String username);

        [OperationContract]
        Attrezzatura[] GetAttrezzatura();

        [OperationContract]
        bool AggiornaAttrezzatura(Attrezzatura a, int quantita);

        [OperationContract]
        string Register(Cliente c, string pw);

        [OperationContract]
        int[][] DisponibilitaAttrezzatura(DateTime date);

        [OperationContract]
        string CreaNoleggio(string user, DateTime inizio, DateTime fine, string[] attr, int[] pers);

        [OperationContract]
        string CancellaPrenotazione(int daEliminare);

        [OperationContract]
        List<Noleggio> GetPrenotazioni(string username);

        [OperationContract]
        List<string[]> GetLezioni(string username);
        [OperationContract]
        List<Lezione> GetListLezioni(string username);

        [OperationContract]
        List<string>[] DisponibilitaIstruttori(DateTime date, string attivita);

        [OperationContract]
        Cliente GetCliente(string username);

        [OperationContract]
        string CreaLezione(string username, DateTime inizio, DateTime fine, string istr, int persone, string attivita);

        //////////////
        [OperationContract]
        string DeleteUser(UserAccount user);
        [OperationContract]
        string GetString();





    }
}
