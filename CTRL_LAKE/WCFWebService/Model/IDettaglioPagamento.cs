using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using WCFWebService;
using System.ServiceModel;

namespace WCFWebService.Model
{
    [ServiceContract]
    public interface IDettaglioPagamento
    {
        [OperationContract]
        double CalcolaCosto();
        
        [OperationContract]
        string ToString();
        
        [OperationContract]
        int GetId();

    }
}
