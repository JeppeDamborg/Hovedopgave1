using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hovedopgave1.Models
{
    public class Students
    {
        public int Id { get; set; }
        public string Navn { get; set; }
        public string Adresse { get; set; }
        public string Bopæl { get; set; }
        public string Nationalitet { get; set; }
        public string SprogKundskab { get; set; }
        public string Telefon { get; set; }
        public string Mail { get; set; }
        public string Uddannelse { get; set; }
        public string Periode { get; set; }
        public string Semester { get; set; }
        public string Specialisering { get; set; }
        public string Overbygning { get; set; }
        public string SemesterProjekt { get; set; }
        public string Praktik { get; set; }
        public string Hovedopgave { get; set; }
        public string OpgaveType { get; set; }
        public string StudieJob { get; set; }
        public bool Transport { get; set; }
        public DateTime DatoForOprettelse { get; set; }
    }
}