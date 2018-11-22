using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Hovedopgave1.Models;

namespace Hovedopgave1.Abstract
{
    public interface IStudentRepository
    {
        IEnumerable<Students> Students { get; }

        void OpretStudent(Students students);

        Students SletStudent(int studentid);

        void RedigerStudent(Students students);

        List<Students> SøgStudentPåNavn(string navn);

        List<Students> SøgPåStudentUddannelse(string uddannelse);

        List<Students> SøgStudentPåNavnOgUdannelse(string navn, string uddannelse);

        List<Students> SøgPåStudentSemester(string semester);

        List<Students> SøgStudentPåUddannelseOgSemester(string uddannelse, string semester);

        List<Students> SøgPåStudentSPHOP(string emne);

        List<Students> SøgStudentPåNavnOgSemester(string navn, string semester);

        List<Students> SøgStudentPåNavnOgSPHOP(string navn, string emne);

        List<Students> SøgStudentPåUddannelseOgSPHOP(string uddannelse, string emne);

        List<Students> SøgStudentPåSemesterOgSPHOP(string semester, string emne);

        List<Students> SøgStudentPåUddannelseOgSemesterOgSPHOP(string uddannelse, string semester, string emne);

        List<Students> SøgStudentPÅAlt(string navn, string semester, string emne, string uddannelse);
    }
}
