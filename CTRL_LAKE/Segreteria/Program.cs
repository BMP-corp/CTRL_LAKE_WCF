using Segreteria.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Segreteria
{
    class Program
    {
        static void Main(string[] args)
        {
            //file binding
            Service1Client server = new Service1Client("BasicHttpBinding_IService1");
            IService1 intf = server;
            Noleggio nolo = intf.GetNoleggio();

            Console.WriteLine(nolo.Id + nolo.Cliente.Nome + nolo.Inizio.ToString() + nolo.fine.ToString());
            Console.ReadLine();

        
        }
    }
}
