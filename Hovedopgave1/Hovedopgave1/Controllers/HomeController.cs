using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hovedopgave1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Forside()
        {
            return View();
        }
      

        public ActionResult OpretStudent()
        {
            

            return View();
        }

        public ActionResult StudentListe()
        {
            return View();
        }

        public ActionResult OpretVirksomhed()
        {
            return View();
        }
        public ActionResult VirksomhedListe()
        {
            return View();
        }

        public ActionResult OpretTilføjer()
        {
            return View();
        }

        public ActionResult TilføjerListe()
        {
            return View();
        }

        public ActionResult OpretBruger()
        {
            return View();
        }

        public ActionResult BrugerListe()
        {
            return View();
        }

        public ActionResult UdløbetStudentListe()
        {
            return View();
        }

    }
}