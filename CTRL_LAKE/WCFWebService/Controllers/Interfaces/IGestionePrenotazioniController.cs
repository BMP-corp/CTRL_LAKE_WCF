using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFWebService.Model;


namespace WCFWebService.Controllers.Interfaces
{
    interface IGestionePrenotazioniController
    {
        HashSet<Cliente> getDbClienti(DbConnection conn);
        HashSet<Attrezzatura> getDbAttrezzatura(DbConnection conn);
        HashSet<Istruttore> getDbIstruttori(DbConnection conn);

    }
}
