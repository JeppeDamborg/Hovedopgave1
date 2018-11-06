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
        private IVirksomhedRepository vrespository;
        private IBrugerRepository brepository;
        private EFDbContext context = new EFDbContext();

        public HomeController(IStudentRepository studentRepository, IVirksomhedRepository virksomhedRepository, IBrugerRepository brugerRepository)
        {
            this.srepository = studentRepository;
            this.vrespository = virksomhedRepository;
            this.brepository = brugerRepository;
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
            var studentliste = new List<Students>
            {
                new Students(){Navn="Tom Hansen", Adresse="Kongevej 3", Bopæl="Skjern", Nationalitet="Dansk", SprogKundskab="Dansk og Engelsk", Telefon="30582749", Mail="Tom25@gmail.com", Uddannelse="Finans", Periode="14.august 2017 - 22.januar 2020", Semester="3.semester aug-dec", Specialisering="Bolig Økonomi", Overbygning="Ingen", SemesterProjekt="Ingen", Praktik="Ingen", Hovedopgave="Ingen", OpgaveType="Ingen", StudieJob="Ingen", Transport=true, DatoForOprettelse=DateTime.Now  }
            };

            return View(srepository.Students);
        }

        public ActionResult OpretVirksomhed()
        {
            return View();
        }
        public ActionResult VirksomhedListe()
        {
            return View(vrespository.Virksomhed);
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
            return View(brepository.Bruger);
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