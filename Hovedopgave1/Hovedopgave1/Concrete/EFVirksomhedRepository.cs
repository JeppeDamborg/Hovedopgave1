using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hovedopgave1.Abstract;
using Hovedopgave1.Models;

namespace Hovedopgave1.Concrete
{
    public class EFVirksomhedRepository : IVirksomhedRepository
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<Virksomhed> Virksomhed
        {

            get { return context.Virksomhed; }
        }

        public void OpretVirksomhed(Virksomhed virksomhed)
        {
           if (virksomhed.Id == 0)
            {
                context.Virksomhed.Add(virksomhed);
            }
            context.SaveChanges();
        }

        public Virksomhed SletVirksomhed(int id)
        {
            Virksomhed dbvirksomhed = context.Virksomhed.Find(id);
            if(dbvirksomhed != null)
            {
                context.Virksomhed.Remove(dbvirksomhed);
                context.SaveChanges();
            }
            return dbvirksomhed;
        }
    }
}