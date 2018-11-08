using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hovedopgave1.Abstract;
using Hovedopgave1.Models;

namespace Hovedopgave1.Concrete
{
    public class EFBrugerRepository: IBrugerRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Bruger> Bruger
        {
            get { return context.Bruger; }
        }

        public void OpretBruger(Bruger bruger)
        {
            if (bruger.Id == 0)
            {
                context.Bruger.Add(bruger);
            }
            context.SaveChanges();
        }
    }
}