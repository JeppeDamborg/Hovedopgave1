using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hovedopgave1.Abstract;
using Hovedopgave1.Models;

namespace Hovedopgave1.Concrete
{
    public class EFVirksomhedRepository : IStudentRepository
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<Virksomhed> Virksomhed
        {

            get { return context.Virksomhed; }
        }
    }
}