using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
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

        public void OpretStudent(Students students)
        {

            if(students.Id == 0)
            {
               
                context.Students.Add(students);
            }
            context.SaveChanges();
        }

        public void RedigerStudent(Students students)
        {
            Students dbstudent = context.Students.Find(students.Id);
            if(dbstudent != null)
            {
                dbstudent.Navn = students.Navn; 
                dbstudent.Vej = students.Vej;
                dbstudent.By = students.By;
                dbstudent.Nationalitet = students.Nationalitet;
                dbstudent.Modersmål = students.Modersmål;
                dbstudent.Fremmedsprog = students.Fremmedsprog;
                dbstudent.Telefon = students.Telefon;
                dbstudent.Mail = students.Mail;
                dbstudent.Uddannelse = students.Uddannelse;
                dbstudent.UddannelsesSted = students.UddannelsesSted;
                dbstudent.Periode = students.Periode;
                dbstudent.Semester = students.Semester;
                dbstudent.Overbygning = students.Overbygning;
                dbstudent.SemesterProjekt = students.SemesterProjekt;
                dbstudent.Praktik = students.Praktik;
                dbstudent.Hovedopgave = students.Hovedopgave;
                dbstudent.OpgaveType = students.OpgaveType;
                dbstudent.SupplerendeInfo = students.SupplerendeInfo;
                dbstudent.StudieJob = students.StudieJob;
                dbstudent.Transport = students.Transport;
            }
            context.SaveChanges();
        }

        public static void SletAutomatiskStudent()
        {
            //var dato = DateTime.Now.AddMonths(-6);

            
            using (var dbcontext = new EFDbContext())
            {

               dbcontext.Students.SqlQuery("Delete * From Students Where DatoForOprettelse <= dateadd(day, -1, getdate())");
                //var findstudent = dbcontext.Students.SqlQuery("Select * from Students Where DatoForOprettelse <= @date", new SqlParameter("@date", dato));

                //if (findstudent != null)
                //{
                    //var deletestudent = dbcontext.Students.SqlQuery("Delete from Students Where DatoForOprettelse <= @dato", new SqlParameter("@dato", dato));
                    
                //}
            }

           
        }

        public Students SletStudent(int id)
        {
            Students dbEntry = context.Students.Find(id);
            if (dbEntry != null)
            {
                context.Students.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public List<Students> SøgPåStudentSemester(string semester)
        {
            List<Students> studentlist;
            using (var dbcontext = new EFDbContext())
            {
                var søgstudent = dbcontext.Students.SqlQuery("Select * from Students where Semester Like @semester", new SqlParameter("@semester", '%' + semester + '%')).ToList<Students>();
                studentlist = søgstudent;
            }
            return studentlist;
        }

        public List<Students> SøgPåStudentSPHOP(string emne)
        {
            List<Students> studentlist;
            using(var dbcontext = new EFDbContext())
            {
                var søgstudent = dbcontext.Students.SqlQuery("Select * from Students where SemesterProjekt LIKE @emne OR Praktik LIKE @emne OR Hovedopgave LIKE @emne", new SqlParameter("@emne", '%' + emne + '%')).ToList<Students>();
                studentlist = søgstudent;
            }
            return studentlist;
        }

        public List<Students> SøgPåStudentUddannelse(string uddannelse)
        {
            List<Students> studentlist;
            using(var dbcontext = new EFDbContext())
            {
                var søgstudent = dbcontext.Students.SqlQuery("Select * from Students where Uddannelse LIKE @uddannelse", new SqlParameter("@uddannelse", '%' + uddannelse + '%')).ToList<Students>();
                studentlist = søgstudent;
            }
            return studentlist;
        }

        public List<Students> SøgStudentPÅAlt(string navn, string semester, string emne, string uddannelse)
        {
            List<Students> studentlist;
            using(var dbcontext = new EFDbContext())
            {
                string query = "Select * from Students where Navn Like @navn AND Semester Like @semester AND Uddannelse Like @uddannelse AND SemesterProjekt Like @emne OR Praktik Like @emne OR Hovedopgave Like @emne";
                SqlParameter sql1 = new SqlParameter("@navn", '%' + navn + '%');
                SqlParameter sql2 = new SqlParameter("@semester", '%' + semester + '%');
                SqlParameter sql3 = new SqlParameter("@uddannelse", '%' + uddannelse + '%');
                SqlParameter sql4 = new SqlParameter("@emne", '%' + emne + '%');
                object[] parameter = new object[] { sql1, sql2, sql3, sql4 };
                var søgstudent = dbcontext.Students.SqlQuery(query, parameter).ToList<Students>();
                studentlist = søgstudent;
            }
            return studentlist;
        }

        public List<Students> SøgStudentPåNavn(string navn)
        {
            List<Students> studentlist;
            using(var dbcontext = new EFDbContext())
            {
                var søgstudent = dbcontext.Students.SqlQuery("Select * from Students where Navn Like @navn", new SqlParameter("@navn", '%' +  navn + '%')).ToList<Students>();
                studentlist = søgstudent;
            }
            return studentlist;
            
        }

        public List<Students> SøgStudentPåNavnOgSemester(string navn, string semester)
        {
            List<Students> studentlist;
            using (var dbcontext = new EFDbContext())
            {
                string query = "Select * from Students where Navn Like @navn And Semester Like @semester";
                SqlParameter sql1 = new SqlParameter("@navn", '%' + navn + '%');
                SqlParameter sql2 = new SqlParameter("@semester", '%' + semester + '%');
                object[] parameter = new object[] { sql1, sql2 };
                var søgstudent = dbcontext.Students.SqlQuery(query, parameter).ToList<Students>();
                studentlist = søgstudent;
            }
            return studentlist;
        }

        public List<Students> SøgStudentPåNavnOgSPHOP(string navn, string emne)
        {
            List<Students> studentlist;
            using(var dbcontext = new EFDbContext())
            {
                string query = "Select * from Students where Navn Like @navn AND SemesterProjekt Like @emne Or Praktik Like @emne OR Hovedopgave Like @emne";
                SqlParameter sql1 = new SqlParameter("@navn", '%' + navn + '%');
                SqlParameter sql2 = new SqlParameter("@emne", '%' + emne + '%');
                object[] parameter = new object[] { sql1, sql2 };
                var søgstudent = dbcontext.Students.SqlQuery(query, parameter).ToList<Students>();
                studentlist = søgstudent;
            }
            return studentlist;
        }

        public List<Students> SøgStudentPåNavnOgUdannelse(string navn, string uddannelse)
        {
            List<Students> studentlist;
            using(var dbcontext = new EFDbContext())
            {
                string query = "Select * from Students where Navn Like @navn And Uddannelse Like @uddannelse";
                SqlParameter sql1 = new SqlParameter("@navn", '%' + navn + '%');
                SqlParameter sql2 = new SqlParameter("@uddannelse", '%' + uddannelse + '%');
                object[] parameter = new object[] { sql1, sql2 };
                var søgstudent = dbcontext.Students.SqlQuery(query, parameter).ToList<Students>();
                studentlist = søgstudent;
            }
            return studentlist;
        }

        public List<Students> SøgStudentPåSemesterOgSPHOP(string semester, string emne)
        {
            List<Students> studentlist;
            using(var dbcontext = new EFDbContext())
            {
                string query = "Select * from Students where Semester Like @semester AND SemesterProjekt Like @emne Or Praktik Like @emne OR Hovedopgave Like @emne";
                SqlParameter sql1 = new SqlParameter("@semester", '%' + semester + '%');
                SqlParameter sql2 = new SqlParameter("@emne", '%' + emne + '%');
                object[] parameter = new object[] { sql1, sql2 };
                var søgstudent = dbcontext.Students.SqlQuery(query, parameter).ToList<Students>();
                studentlist = søgstudent;
            }
            return studentlist;
        }

        public List<Students> SøgStudentPåUddannelseOgSemester(string uddannelse, string semester)
        {
            List<Students> studentlist;
            using(var dbcontext = new EFDbContext())
            {
                string query = "Select * from Students where Uddannelse Like @uddannelse And Semester Like @semester";
                SqlParameter sql1 = new SqlParameter("@uddannelse", '%' + uddannelse + '%');
                SqlParameter sql2 = new SqlParameter("@semester", '%' + semester + '%');
                object[] parameter = new object[] { sql1, sql2 };
                var søgstudent = dbcontext.Students.SqlQuery(query, parameter).ToList<Students>();
                studentlist = søgstudent;
            }
            return studentlist;
        }

        public List<Students> SøgStudentPåUddannelseOgSemesterOgSPHOP(string uddannelse, string semester, string emne)
        {
            List<Students> studentlist;
            using(var dbcontext = new EFDbContext())
            {
                string query = "Select * from Students Where Uddannelse Like @uddannelse And Semester Like @semester AND SemesterProjekt Like @emne Or Praktik Like @emne Or Hovedopgave Like @emne";
                SqlParameter sql1 = new SqlParameter("@uddannelse", '%' + uddannelse + '%');
                SqlParameter sql2 = new SqlParameter("@semester", '%' + semester + '%');
                SqlParameter sql3 = new SqlParameter("@emne", '%' + emne + '%');
                object[] parameter = new object[] { sql1, sql2, sql3 };
                var søgstudent = dbcontext.Students.SqlQuery(query, parameter).ToList<Students>();
                studentlist = søgstudent;
            }
            return studentlist;
        }

        public List<Students> SøgStudentPåUddannelseOgSPHOP(string uddannelse, string emne)
        {
            List<Students> studentlist;
            using(var dbcontext = new EFDbContext())
            {
                string query = "Select * from Students where Uddannelse Like @uddannelse AND SemesterProjekt Like @emne Or Praktik Like @emne OR Hovedopgave Like @emne";
                SqlParameter sql1 = new SqlParameter("@uddannelse", '%' + uddannelse + '%');
                SqlParameter sql2 = new SqlParameter("@emne", '%' + emne + '%');
                object[] parameter = new object[] { sql1, sql2 };
                var søgstudent = dbcontext.Students.SqlQuery(query, parameter).ToList<Students>();
                studentlist = søgstudent;


            }
            return studentlist;
        }
    }
}