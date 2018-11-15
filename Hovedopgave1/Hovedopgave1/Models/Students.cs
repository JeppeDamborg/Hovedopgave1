using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hovedopgave1.Models
{
    public class Students
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Du skal skrive dit navn")]
        public string Navn { get; set; }
        [Required(ErrorMessage = "Du skal skrive din adresse")]
        public string Adresse { get; set; }
        [Required(ErrorMessage = "Du skal skrive din Bopæl")]
        public string Bopæl { get; set; }
        [Required(ErrorMessage = "Du skal skrive din nationalitet")]
        public string Nationalitet { get; set; }
        [Required(ErrorMessage = "Du skal skrive din sprogkundskaber")]
        public string SprogKundskab { get; set; }
        [Required(ErrorMessage = "Du skal skrive dit telefonnummer")]
        public string Telefon { get; set; }
        [Required(ErrorMessage = "Du skal skrive din mail")]
        [EmailAddress(ErrorMessage = "Ugyldigt Email Addresse")]
        public string Mail { get; set; }
        [Required(ErrorMessage = "Du skal skrive din uddannelse")]
        public string Uddannelse { get; set; }
        [Required(ErrorMessage = "Du skal skrive Indtaste din periode")]
        public string Periode { get; set; }
        [Required(ErrorMessage = "Du skal skrive din nuværende semester")]
        public string Semester { get; set; }
        [Required(ErrorMessage = "Du skal skrive din specialisering")]
        public string Specialisering { get; set; }
        public string Overbygning { get; set; }
        public string SemesterProjekt { get; set; }
        public string Praktik { get; set; }
        public string Hovedopgave { get; set; }
        public string OpgaveType { get; set; }
        public string StudieJob { get; set; }


        public bool Transport { get; set; }

        private DateTime _datoforoprettelse = DateTime.Now;

        [DataType(DataType.Date)]
        [Column(TypeName ="datetime2")]
        public DateTime DatoForOprettelse { get { return _datoforoprettelse;  } set { _datoforoprettelse = value; } }
    }
}