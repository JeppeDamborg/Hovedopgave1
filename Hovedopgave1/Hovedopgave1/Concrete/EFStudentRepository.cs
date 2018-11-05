using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hovedopgave1.Abstract;
using Hovedopgave1.Models;

namespace Hovedopgave1.Concrete
{
    public class EFStudentRepository : IStudentRepository
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<Students> Students  {

            get { return context.Students; }
        }
    }
}