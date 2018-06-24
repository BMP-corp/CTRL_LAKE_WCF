﻿using System;
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
        string Register(Cliente c, string pw);

        [OperationContract]
        string DeleteUser(UserAccount user);
        [OperationContract]
        Cliente getCliente();
        [OperationContract]
        string CancellaPrenotazione(int daEliminare);
        [OperationContract]
        List<Noleggio> GetPrenotazioni(string username);
    }
}
