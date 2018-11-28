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

        List<Tilføjer> SøgTilføjerPåAlt(string navn, string uddannelse, string sekundærUddannelse, string jobØnske, string kompetence, int? flytning);

        List<Tilføjer> SøgTilføjerPåSekundærUddannelseOgFlytning(string sekundærUddannelse, int? flytning);

        List<Tilføjer> SøgTilføjerPåUddannelseOgJobØnske(string uddannelse, string jobØnske);

        List<Tilføjer> SøgTilføjerPåUddannelseOgKompetence(string uddannelse, string kompetence);

        List<Tilføjer> SøgTilføjerPåUddannelseOgSekundærUddannelse(string uddannelse, string sekundærUddannelse);

        List<Tilføjer> SøgTilføjerPåJobØnskeOgKompetence(string jobØnske, string kompetence);

        List<Tilføjer> SøgTilføjerPåKompetenceOgSekundærUddannelse(string kompetence, string sekundærUddannelse);

        List<Tilføjer> SøgTilføjerPåUddannelseOgJobØnskeOgKompetence(string uddannelse, string jobØnske, string kompetence);

        List<Tilføjer> SøgTilføjerPåUddannelseOgSekundærUddannelseOgJobØnske(string uddannelse, string sekundærUddannelse, string jobØnske);

        List<Tilføjer> SøgTilføjerPåUddannelseOgFlytningOgJobØnske(string uddannelse, int? flytning, string jobØnske);

        List<Tilføjer> SøgTilføjerPåUddannelseOgFlytningOgKompetence(string uddannelse, int? flytning, string kompetence);

        List<Tilføjer> SøgTilføjerPåUddannelseOgFlytningOgSekundærUddannelse(string uddannelse, int? flytning, string sekundærUddannelse);

        List<Tilføjer> SøgTilføjerPåUddannelseOgSekundærUddannelseOgKompetence(string uddannelse, string sekundærUddannelse, string kompetence);

        List<Tilføjer> SøgTilføjerPåSekundærUddannelseOgKompetencerOgJobØnske(string sekundærUddannelse, string kompetence, string jobØnske);

        List<Tilføjer> SøgTilføjerPåFlytningOgJobØnskeOgKompetence(int? flytning, string jobØnske, string kompetence);

        List<Tilføjer> SøgTilføjerPåFlytningOgJobØnskeOgSekundærUddannelse(int? flytning, string jobØnske, string sekundærUddannelse);

        List<Tilføjer> SøgTilføjerPåFlytningOgKompetenceOgSekundærUddannelse(int? flytning, string kompetence, string sekundærUddannelse);
    }
}
