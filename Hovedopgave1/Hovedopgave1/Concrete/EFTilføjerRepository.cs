using Hovedopgave1.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hovedopgave1.Models;
using System.Data.SqlClient;

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

        public void RedigerTilføjer(Tilføjer tilføjer)
        {
            Tilføjer dbtilføjer = context.Tilføjer.Find(tilføjer.Id);
            if(dbtilføjer != null)
            {
                dbtilføjer.Navn = tilføjer.Navn;
                dbtilføjer.Adresse = tilføjer.Adresse;
                dbtilføjer.Telefon = tilføjer.Telefon;
                dbtilføjer.Mail = tilføjer.Mail;
                dbtilføjer.Uddannelse = tilføjer.Uddannelse;
                dbtilføjer.Erhvervserfaring = tilføjer.Erhvervserfaring;
                dbtilføjer.JobØnske = tilføjer.JobØnske;
                dbtilføjer.FagligeKompetencer = tilføjer.FagligeKompetencer;
                dbtilføjer.PersonligeKompetencer = tilføjer.PersonligeKompetencer;
                dbtilføjer.GenereltInfo = tilføjer.GenereltInfo;
                dbtilføjer.ØnskerAtFlytte = tilføjer.ØnskerAtFlytte;
            }
            context.SaveChanges();
        }

        public Tilføjer SletTilføjer(int id)
        {
            Tilføjer dbEntry = context.Tilføjer.Find(id);
            if(dbEntry != null)
            {
                context.Tilføjer.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public List<Tilføjer> SøgTilføjerPåJobØnske(string jobØnske)
        {
            List<Tilføjer> tilføjerlist;
            using (var dbcontext = new EFDbContext())
            {
                var søgtilføjer = dbcontext.Tilføjer.SqlQuery("Select * from Tilføjer where JobØnske Like @jobØnske", new SqlParameter("@jobØnske", '%' + jobØnske + '%')).ToList<Tilføjer>();
                tilføjerlist = søgtilføjer;
            }
            return tilføjerlist;
        }

        public List<Tilføjer> SøgTilføjerPåUddannelse(string uddannelse)
        {
            List<Tilføjer> tilføjerlist;
            using (var dbcontext = new EFDbContext())
            {
                var søgtilføjer = dbcontext.Tilføjer.SqlQuery("Select * from Tilføjer where Uddannelse Like @uddannelse", new SqlParameter("@uddannelse", '%' + uddannelse + '%')).ToList<Tilføjer>();
                tilføjerlist = søgtilføjer;
            }
            return tilføjerlist;
        }
    }
}