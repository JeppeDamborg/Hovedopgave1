using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        public void RedigerVirksomhed(Virksomhed virksomhed)
        {
            Virksomhed dbvirksomhed = context.Virksomhed.Find(virksomhed.Id);
            if(dbvirksomhed != null)
            {
                dbvirksomhed.Navn = virksomhed.Navn;
                dbvirksomhed.KontaktPerson = virksomhed.KontaktPerson;
                dbvirksomhed.Telefon = virksomhed.Telefon;
                dbvirksomhed.Mail = virksomhed.Mail;
                dbvirksomhed.VirksomhedsInfo = virksomhed.VirksomhedsInfo;
                dbvirksomhed.MuligeOpgaver = virksomhed.MuligeOpgaver;
                dbvirksomhed.Profiler = virksomhed.Profiler;
                dbvirksomhed.OpgaveLøsning = virksomhed.OpgaveLøsning;
                dbvirksomhed.Styrkeposition = virksomhed.Styrkeposition;

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

        public List<Virksomhed> SøgVirksomhedPåMuligeOpgaver(string opgave)
        {
            List<Virksomhed> virksomhedsliste;
            using(var dbcontext = new EFDbContext())
            {
                var søgvirksomhed = dbcontext.Virksomhed.SqlQuery("Select * from Virksomheds where MuligeOpgaver LIKE @opgave", new SqlParameter("@opgave", '%' + opgave + '%')).ToList<Virksomhed>();
                virksomhedsliste = søgvirksomhed;
            }
            return virksomhedsliste;
        }

        public List<Virksomhed> SøgVirksomhedPåNavn(string navn)
        {
            List<Virksomhed> virksomhedsliste;
            using(var dbcontext = new EFDbContext())
            {
                var søgvirksomhed = dbcontext.Virksomhed.SqlQuery("Select * from Virksomheds where Navn LIKE @navn", new SqlParameter("@navn", '%' + navn + '%')).ToList<Virksomhed>();
                virksomhedsliste = søgvirksomhed;
            }
            return virksomhedsliste;
        }

        public List<Virksomhed> SøgVirksomhedPåProfiler(string profiler)
        {
            List<Virksomhed> virksomhsliste;
            using(var dbcontext = new EFDbContext())
            {
                var søgvirksomhed = dbcontext.Virksomhed.SqlQuery("Select * from Virksomheds where Profiler Like @profiler", new SqlParameter("@profiler", '%' + profiler + '%')).ToList<Virksomhed>();
                virksomhsliste = søgvirksomhed;
            }
            return virksomhsliste;
        }
    }
}