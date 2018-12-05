using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hovedopgave1.Models
{
    public class Bruger
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Du skal skrive brugernavnet")]
        public string Brugernavn { get; set; }
        [Required(ErrorMessage = "Du skal skrive et password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Du skal skrive hvilken rettighed brugeren har")]
        public string Rettighed { get; set; }

    }
}