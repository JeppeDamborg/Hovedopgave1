using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hovedopgave1.Models;
using System.Data.Entity;

namespace Hovedopgave1.Concrete
{
    public class EFDbContext: DbContext
    {
        public DbSet<Students> Students { get; set; }
        public DbSet<Virksomhed> Virksomhed { get; set; }
        public DbSet<Bruger> Bruger { get; set; }
    }
}