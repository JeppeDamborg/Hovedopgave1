using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hovedopgave1.Models;

namespace Hovedopgave1.Abstract
{
    public interface IStudentRepository
    {
        IEnumerable<Students> Students { get; }
    }
}
