using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hovedopgave1.Abstract;
using Hovedopgave1.Concrete;
using Hovedopgave1.Models;

namespace Hovedopgave1.Controllers
{
    public class HomeController : Controller
    {
        private IStudentRepository srepository;
        private EFDbContext context = new EFDbContext();

        public HomeController(IStudentRepository studentRepository)
        {
            this.srepository = studentRepository;
        }

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
            return View(srepository.Student);
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

        public ActionResult RedigerStudent()
        {
            return View();
        }

        public ActionResult RedigerVirksomhed()
        {
            return View();
        }

        public ActionResult RedigerTilføjer()
        {
            return View();
        }

        public ActionResult RedigerBruger()
        {
            return View();
        }

        public ActionResult StudentOprettet()
        {
            return View();
        }
        public ActionResult StudentRedigeret()
        {
            return View();
        }

        public ActionResult VirksomhedOprettet()
        {
            return View();
        }

        public ActionResult VirksomhedRedigeret()
        {
            return View();
        }



    }
}