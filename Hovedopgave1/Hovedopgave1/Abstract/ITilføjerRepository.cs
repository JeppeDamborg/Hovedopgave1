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

        List<Tilføjer> SøgTilføjerPåNavn(string navn);

        List<Tilføjer> SøgTilføjerPåUddannelse(string uddannelse);

        List<Tilføjer> SøgTilføjerPåJobØnske(string jobØnske);

        List<Tilføjer> SøgTilføjerPåFagligeKompetencer(string kompetence);

        List<Tilføjer> SøgTilføjerPåØnskeOmTilflytning(int? flytning);

        List<Tilføjer> SøgTilføjerPåUddannelseOgTilflytning(string uddannelse, int? flytning);

        List<Tilføjer> SøgTilføjerPåJobØnskeOgTilflytning(string jobønske, int? flytning);

        List<Tilføjer> SøgTilføjerPåKompetenceOgTilflytning(string kompetence, int? flytning);

        List<Tilføjer> SøgTilføjerPåSekundærUddannelseOgJobØnske(string sekundærUddannelse, string jobØnske);
    }
}
