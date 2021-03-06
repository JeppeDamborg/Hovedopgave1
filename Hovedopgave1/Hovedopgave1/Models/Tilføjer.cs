﻿using System;
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

        [Required(ErrorMessage = "Du skal skrive dit navn")]
        public string Navn { get; set; }
        [Required(ErrorMessage = "Du skal skrive din vejadresse")]
        public string Vej { get; set; }
        public string By { get; set; }
        [Required(ErrorMessage = "Du skal skrive dit telefonnummer")]
        public string Telefon { get; set; }
        [Required(ErrorMessage = "Du skal skrive din mail")]
        [EmailAddress(ErrorMessage = "Ugyldigt Email Addresse")]
        public string Mail { get; set; }
        [Required(ErrorMessage = "Du skal skrive din primære uddannelse")]
        public string PrimærUddannelse { get; set; }
        public string SekundærUddannelse { get; set; }
        [Required(ErrorMessage = "Du skal skrive dine erhvervserfaringer")]
        public string Erhvervserfaring { get; set; }
        [Required(ErrorMessage = "Du skal skrive dit job ønske")]
        public string JobØnske { get; set; }
        [Required(ErrorMessage = "Du skal skrive dine faglige kompetencer")]
        public string FagligeKompetencer { get; set; }
        [Required(ErrorMessage = "Du skal skrive dine personlige kompetencer")]
        public string PersonligeKompetencer { get; set; }

        public string GenereltInfo { get; set; }
        [Required(ErrorMessage = "Du skal skrive din uddannelse")]
        public bool ØnskerAtFlytte { get; set; }


        [DataType(DataType.Date)]
        [Column(TypeName ="datetime2")]
        public DateTime DatoForOprettelse { get; set; }

        public string CVTitel { get; set; }

        public byte[] CV { get; set; }


    }
}