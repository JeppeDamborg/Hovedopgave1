using Hovedopgave1.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hovedopgave1.Models;

namespace Hovedopgave1.Concrete
{
    public class EFTilføjerRepository: ITilføjerRepository
    {
        private EFDbContext context = new EFDbContext();


        public IEnumerable<Tilføjer> Tilføjer
        {
            get { return context.Tilføjer; }
        }

        public void OpretTilføjer(Tilføjer tilføjer)
        {
            if (tilføjer.Id == 0)
            {
                context.Tilføjer.Add(tilføjer);
            }
            context.SaveChanges();
        }
    }
}