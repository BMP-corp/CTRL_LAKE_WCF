﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerRichieste
{
    public interface IDettaglioPagamento
    {
        double CalcolaCosto();
        string ToString();
        int GetId();

    }
}
