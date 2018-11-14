﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
                dbstudent.Adresse = students.Adresse;
                dbstudent.Bopæl = students.Bopæl;
                dbstudent.Nationalitet = students.Nationalitet;
                dbstudent.SprogKundskab = students.SprogKundskab;
                dbstudent.Telefon = students.Telefon;
                dbstudent.Mail = students.Mail;
                dbstudent.Uddannelse = students.Uddannelse;
                dbstudent.Periode = students.Periode;
                dbstudent.Semester = students.Semester;
                dbstudent.Overbygning = students.Overbygning;
                dbstudent.SemesterProjekt = students.SemesterProjekt;
                dbstudent.Praktik = students.Praktik;
                dbstudent.Hovedopgave = students.Hovedopgave;
                dbstudent.OpgaveType = students.OpgaveType;
                dbstudent.StudieJob = students.StudieJob;
                dbstudent.Transport = students.Transport;
            }
            context.SaveChanges();
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
                string query = "Select * from Students where Navn Like @navn Or Semester Like @semester";
                SqlParameter sql1 = new SqlParameter("@navn", '%' + navn + '%');
                SqlParameter sql2 = new SqlParameter("@semester", '%' + semester + '%');
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
                string query = "Select * from Students where Navn Like @navn Or Uddannelse Like @uddannelse";
                SqlParameter sql1 = new SqlParameter("@navn", '%' + navn + '%');
                SqlParameter sql2 = new SqlParameter("@uddannelse", '%' + uddannelse + '%');
                object[] parameter = new object[] { sql1, sql2 };
                var søgstudent = dbcontext.Students.SqlQuery(query, parameter).ToList<Students>();
                studentlist = søgstudent;
            }
            return studentlist;
        }
    }
}