using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hovedopgave1.Models
{
    public class Tilføjer
    {
        [Key]
        public int Id { get; set; }

        public string Navn { get; set; }

        public string Adresse { get; set; }

        public string Telefon { get; set; }

        public string Mail { get; set; }

        public string Uddannelse { get; set; }

        public string Erhvervserfaring { get; set; }

        public string JobØnske { get; set; }

        public string FagligeKompetencer { get; set; }

        public string PersonligeKompetencer { get; set; }

        public string GenereltInfo { get; set; }

        public bool ØnskerAtFlytte { get; set; }


    }
}