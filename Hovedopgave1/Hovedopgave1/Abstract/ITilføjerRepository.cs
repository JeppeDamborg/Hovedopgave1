using Hovedopgave1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hovedopgave1.Abstract
{
   public interface ITilføjerRepository
    {
        IEnumerable<Tilføjer> Tilføjer { get; }


        void OpretTilføjer(Tilføjer tilføjer);

        Tilføjer SletTilføjer(int id);

        void RedigerTilføjer(Tilføjer tilføjer);

        List<Tilføjer> SøgTilføjerPåUddannelse(string uddannelse);
    }
}
