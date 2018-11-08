using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Hovedopgave1.Models
{
    public class Virksomhed
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Du skal skrive navnet på virksomheden")]
        public string Navn { get; set; }
        [Required(ErrorMessage = "Du skal skrive navnet på kontaktpersonen")]
        public string KontaktPerson { get; set; }
        [Required(ErrorMessage = "Du skal skrive telefonnummeret ned")]
        public string Telefon { get; set; }
        [Required(ErrorMessage = "Du skal have email med")]
        public string Mail { get; set; }

        public string VirksomhedsInfo { get; set; }
        [Required(ErrorMessage = "Du skal skrive mulige opgaver")]
        public string MuligeOpgaver { get; set; }
        [Required(ErrorMessage = "Du skal have profiler med")]
        public string Profiler { get; set; }


        public string OpgaveLøsning { get; set; }
        [Required(ErrorMessage = "Du skal have styrkeposition med")]
        public string Styrkeposition { get; set; }
    }
}