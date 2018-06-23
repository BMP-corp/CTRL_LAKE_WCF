using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WCFWebService.Interfaces
{
    interface IGestionePrenotazioniController
    {
        HashSet<Cliente> getDbClienti(DbConnection conn);
        HashSet<Attrezzatura> getDbAttrezzatura(DbConnection conn);
        HashSet<Istruttore> getDbIstruttori(DbConnection conn);

    }
}
