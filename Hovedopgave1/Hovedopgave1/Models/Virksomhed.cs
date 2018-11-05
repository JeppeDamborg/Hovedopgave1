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
        public string Navn { get; set; }

        public string KontaktPerson { get; set; }

        public string Telefon { get; set; }

        public string Mail { get; set; }

        public string VirksomhedsInfo { get; set; }

        public string MuligeOpgaver { get; set; }

        public string Profiler { get; set; }

        public string OpgaveLøsning { get; set; }

        public string Styrkeposition { get; set; }
    }
}