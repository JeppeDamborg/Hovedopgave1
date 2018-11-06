using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hovedopgave1.Models
{
    public class Bruger
    {
        public int Id { get; set; }

        public string Brugernavn { get; set; }

        public string Password { get; set; }

        public string Rettighed { get; set; }

    }
}