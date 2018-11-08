using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hovedopgave1.Models;

namespace Hovedopgave1.Abstract
{
    public interface IVirksomhedRepository
    {
        IEnumerable<Virksomhed> Virksomhed { get; }

        void OpretVirksomhed(Virksomhed virksomhed);

        Virksomhed SletVirksomhed(int id);
    }
}