using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WCFWebService.Model
{
    public interface IDettaglioPagamento
    {
        double CalcolaCosto();
        string ToString();
        int GetId();

    }
}
