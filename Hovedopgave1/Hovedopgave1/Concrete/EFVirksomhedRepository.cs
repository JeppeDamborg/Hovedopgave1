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
                dbvirksomhed.Aflønning = virksomhed.Aflønning;

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

        public List<Virksomhed> SøgVirksomhedPåAlt(string navn, string opgave, string profiler, string position)
        {
            List<Virksomhed> virksomhedsliste;
            using (var dbcontext = new EFDbContext())
            {
                string query = "Select * from Virksomheds where Navn Like @navn AND MuligeOpgaver Like @opgave AND Profiler Like @profiler AND Styrkeposition Like @position";
                SqlParameter sql1 = new SqlParameter("@navn", '%' + navn + '%');
                SqlParameter sql2 = new SqlParameter("@opgave", '%' + opgave + '%');
                SqlParameter sql3 = new SqlParameter("@profiler", '%' + profiler + '%');
                SqlParameter sql4 = new SqlParameter("@position", '%' + position + '%');
                object[] parameter = new object[] { sql1, sql2, sql3, sql4 };
                var søgvirksomhed = dbcontext.Virksomhed.SqlQuery(query, parameter).ToList<Virksomhed>();
                virksomhedsliste = søgvirksomhed;



            }
            return virksomhedsliste;
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

        public List<Virksomhed> SøgVirksomhedPåOpgaverOgPosition(string opgave, string position)
        {
            List<Virksomhed> virksomhedsliste;
            using(var dbcontext = new EFDbContext())
            {
                string query = "Select * from Virksomheds where MuligeOpgaver Like @opgave And Styrkeposition Like @position";
                SqlParameter sql1 = new SqlParameter("@opgave", '%' + opgave + '%');
                SqlParameter sql2 = new SqlParameter("@position", '%' + position + '%');
                object[] parameter = new object[] { sql1, sql2 };
                var søgvirksomhed = dbcontext.Virksomhed.SqlQuery(query, parameter).ToList<Virksomhed>();
                virksomhedsliste = søgvirksomhed;
            }
            return virksomhedsliste;
        }

        public List<Virksomhed> SøgVirksomhedPåOpgaverOgProfiler(string opgave, string profiler)
        {
            List<Virksomhed> virksomhedlist;
            using(var dbcontext = new EFDbContext())
            {
                string query = "Select * from Virksomheds Where MuligeOpgaver Like @opgave And Profiler Like @profiler";
                SqlParameter sql1 = new SqlParameter("@opgave", '%' + opgave + '%');
                SqlParameter sql2 = new SqlParameter("@profiler", '%' + profiler + '%');
                object[] parameter = new object[] { sql1, sql2 };
                var søgvirksomhed = dbcontext.Virksomhed.SqlQuery(query, parameter).ToList<Virksomhed>();
                virksomhedlist = søgvirksomhed;
            }
            return virksomhedlist;
        }

        public List<Virksomhed> SøgVirksomhedPåOpgaverOgProfilerOgPosition(string opgave, string profiler, string position)
        {
            List<Virksomhed> virksomhedsliste;
            using(var dbcontext = new EFDbContext())
            {
                string query = "Select * from Virksomheds where MuligeOpgaver Like @opgave And Profiler Like @profiler And Styrkeposition Like @position";
                SqlParameter sql1 = new SqlParameter("@opgave", '%' + opgave + '%');
                SqlParameter sql2 = new SqlParameter("@profiler", '%' + profiler + '%');
                SqlParameter sql3 = new SqlParameter("@position", '%' + position + '%');
                object[] parameter = new object[] { sql1, sql2, sql3 };
                var søgvirksomhed = dbcontext.Virksomhed.SqlQuery(query, parameter).ToList<Virksomhed>();
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

        public List<Virksomhed> SøgVirksomhedPåProfilerOgPosition(string profiler, string position)
        {
            List<Virksomhed> virksomhedsliste;
            using (var dbcontext = new EFDbContext())
            {
                string query = "Select * from Virksomheds where Profiler Like @profiler And Styrkeposition Like @position";
                SqlParameter sql1 = new SqlParameter("@profiler", '%' + profiler + '%');
                SqlParameter sql2 = new SqlParameter("@position", '%' + position + '%');
                object[] parameter = new object[] { sql1, sql2 };
                var søgvirksomhed = dbcontext.Virksomhed.SqlQuery(query, parameter).ToList<Virksomhed>();
                virksomhedsliste = søgvirksomhed;


            }
            return virksomhedsliste;
        }

        public List<Virksomhed> SøgVirksomhedPåStyrkeposition(string position)
        {
            List<Virksomhed> virksomhsliste;
            using (var dbcontext = new EFDbContext())
            {
                var søgvirksomhed = dbcontext.Virksomhed.SqlQuery("Select * from Virksomheds where Styrkeposition Like @position", new SqlParameter("@position", '%' + position + '%')).ToList<Virksomhed>();
                virksomhsliste = søgvirksomhed;
            }
            return virksomhsliste;
        }
    }
}