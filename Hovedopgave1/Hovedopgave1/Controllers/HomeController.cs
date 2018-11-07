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

        [HttpPost]
        public ActionResult OpretStudent(Students students)
        {
            if (ModelState.IsValid)
            {
                srepository.OpretStudent(students);
                TempData["message"] = string.Format("{0} has been created", students.Id);
                return RedirectToAction("StudentOprettet");
            }
            else
            {
                return View(students);
            }
        }
        
        public ActionResult StudentListe()
        {
            var studentliste = new List<Students>
            {
                new Students(){Navn="Tom Hansen", Adresse="Kongevej 3", Bopæl="Skjern", Nationalitet="Dansk", SprogKundskab="Dansk og Engelsk", Telefon="30582749", Mail="Tom25@gmail.com", Uddannelse="Finans", Periode="14.august 2017 - 22.januar 2020", Semester="3.semester aug-dec", Specialisering="Bolig Økonomi", Overbygning="Ingen", SemesterProjekt="Ingen", Praktik="Ingen", Hovedopgave="Ingen", OpgaveType="Ingen", StudieJob="Ingen", Transport=true, DatoForOprettelse=DateTime.Now  }
            };

            return View(srepository.Students);
        }
        [HttpPost]

        public ActionResult StudentListe(int id)
        {
            Students students = srepository.SletStudent(id);
            if(students != null)
            {
                TempData["message"] = string.Format("{0} was deleted", students.Id);
                
            }
            return RedirectToAction("Forside");
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
        [HttpGet]
        public ActionResult RedigerStudent(int id)
        {
            var st1 = srepository.Students.Where(s => s.Id == id).FirstOrDefault();
            return View(st1);
        }

        [HttpPost]
        public ActionResult RedigerStudent(Students students)
        {
            if (ModelState.IsValid)
            {
                srepository.RedigerStudent(students);
                TempData["message"] = string.Format("{0} has been updated", students.Id);
                return RedirectToAction("StudentRedigeret");
            }
            else
            {
                return View(students);
            }
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