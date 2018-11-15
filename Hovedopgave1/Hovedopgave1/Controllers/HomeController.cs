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
        private ITilføjerRepository trepository;
        
        private EFDbContext context = new EFDbContext();

        public HomeController(IStudentRepository studentRepository, IVirksomhedRepository virksomhedRepository, IBrugerRepository brugerRepository, ITilføjerRepository tilføjerRepository)
        {
            this.srepository = studentRepository;
            this.vrespository = virksomhedRepository;
            this.brepository = brugerRepository;
            this.trepository = tilføjerRepository;
            
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
           

            return View(srepository.Students);
        }
        [HttpPost]

        public ActionResult StudentListe(string navn, string uddannelse, string semester, string emne)
        {
            List<Students> studentlist = new List<Students>();
            if (ModelState.IsValid)
            {
               
                if (navn != "")
                {
                    studentlist = srepository.SøgStudentPåNavn(navn);
                }
                if(uddannelse != "") {
                    studentlist = srepository.SøgPåStudentUddannelse(uddannelse);
                }
                if(navn != "" && uddannelse != "")
                {
                    studentlist = srepository.SøgStudentPåNavnOgUdannelse(navn, uddannelse);
                }
                if(navn != "" && semester != "")
                {
                    studentlist = srepository.SøgStudentPåNavnOgSemester(navn, semester);
                }

                if(uddannelse !="" && semester != "")
                {
                    studentlist = srepository.SøgStudentPåUddannelseOgSemester(uddannelse, semester);
                }

                if(semester != "")
                {
                    studentlist = srepository.SøgPåStudentSemester(semester);
                }
                if(emne != "")
                {
                    studentlist = srepository.SøgPåStudentSPHOP(emne);
                }
                if(navn != "" && emne != "")
                {
                    studentlist = srepository.SøgStudentPåNavnOgSPHOP(navn, emne);
                }
                if(uddannelse != "" && emne != "")
                {
                    studentlist = srepository.SøgStudentPåUddannelseOgSPHOP(uddannelse, emne);
                }
                if(semester != "" && emne != "")
                {
                    studentlist = srepository.SøgStudentPåSemesterOgSPHOP(semester, emne);
                }
              
                return View(studentlist);
            }
            else
            {
                return View();
            }
        }
        public ActionResult StudentDelete(int id)
        {
            Students students = srepository.SletStudent(id);
            if (students != null)
            {
                TempData["message"] = string.Format("{0} was deleted", students.Id);

            }
            return RedirectToAction("Forside");
        }


        public ActionResult OpretVirksomhed()
        {
            return View();
        }
        [HttpPost]
        public ActionResult OpretVirksomhed(Virksomhed virksomhed)
        {
            if (ModelState.IsValid)
            {
                vrespository.OpretVirksomhed(virksomhed);
                TempData["message"] = string.Format("{0} has been created", virksomhed.Id);
                return RedirectToAction("VirksomhedOprettet");
            }
            else
            {
                return View(virksomhed);
            }
            
        }

        public ActionResult VirksomhedListe()
        {
            return View(vrespository.Virksomhed);
        }

        [HttpPost]
        public ActionResult VirksomhedListe(string navn, string opgave, string profiler, string position)
        {
            List<Virksomhed> virksomhedslist = new List<Virksomhed>();
            if (ModelState.IsValid)
            {
                
                if(navn != "")
                {
                    virksomhedslist = vrespository.SøgVirksomhedPåNavn(navn);
                }
                if(opgave != "")
                {
                    virksomhedslist = vrespository.SøgVirksomhedPåMuligeOpgaver(opgave);
                }    
                if(profiler != "")
                {
                    virksomhedslist = vrespository.SøgVirksomhedPåProfiler(profiler);
                }

                if (position != "")
                {
                    virksomhedslist = vrespository.SøgVirksomhedPåStyrkeposition(position);
                }
                if(opgave != "" && position != "")
                {
                    virksomhedslist = vrespository.SøgVirksomhedPåOpgaverOgPosition(opgave, position);
                }
                if(position !="" && profiler != "")
                {
                    virksomhedslist = vrespository.SøgVirksomhedPåProfilerOgPosition(profiler, position);
                }
                if(opgave != "" && profiler != "" && position != "")
                {
                    virksomhedslist = vrespository.SøgVirksomhedPåOpgaverOgProfilerOgPosition(opgave, profiler, position);
                }
                

                return View(virksomhedslist);
            }
            else
            {
                return View();
            }

        }

        public ActionResult VirksomhedDelete (int id)
        {
            Virksomhed virksomhed = vrespository.SletVirksomhed(id);
            if (virksomhed != null)
            {
                TempData["message"] = string.Format("{0} has been deleted", virksomhed.Id);
            }
            return RedirectToAction("Forside");
        }
        public ActionResult OpretTilføjer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult OpretTilføjer(Tilføjer tilføjer)
        {
            if (ModelState.IsValid)
            {
                trepository.OpretTilføjer(tilføjer);
                TempData["message"] = string.Format("{0} has been created", tilføjer.Id);
                return RedirectToAction("TilføjerOprettet");
            }
            else
            {
                return View(tilføjer);
            }
        }

        public ActionResult TilføjerListe()
        {
            return View(trepository.Tilføjer);
        }

        public ActionResult OpretBruger()
        {
            return View();
        }
        [HttpPost]
        public ActionResult OpretBruger(Bruger bruger)
        {
            if (ModelState.IsValid)
            {
                brepository.OpretBruger(bruger);
                TempData["message"] = string.Format("{0} has been created", bruger.Id);
                return RedirectToAction("BrugerOprettet");
            }
            else
            {
                return View (bruger);
            }
        }

        public ActionResult BrugerListe()
        {
            return View(brepository.Bruger);
        }
        [HttpPost]
        public ActionResult BrugerListe(int id)
        {
            Bruger bruger = brepository.SletBruger(id);
            if (bruger != null)
            {
                TempData["message"] = string.Format("{0} has been deleted", bruger.Id);
            }
            return RedirectToAction("Forside");
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
        [HttpGet]
        public ActionResult RedigerVirksomhed(int id)
        {
            var st2 = vrespository.Virksomhed.Where(s => s.Id == id).FirstOrDefault();
            return View(st2);
        }
        [HttpPost]
        public ActionResult RedigerVirksomhed(Virksomhed virksomhed)
        {
            if (ModelState.IsValid)
            {
                vrespository.RedigerVirksomhed(virksomhed);
                TempData["message"] = string.Format("{0} has been updated", virksomhed.Id);
                return RedirectToAction("VirksomhedRedigeret");
            }
            else
            {
                return View(virksomhed);
            }
        }

        public ActionResult RedigerTilføjer()
        {
            return View();
        }
        [HttpGet]
        public ActionResult RedigerBruger(int id)
        {
            var b1 = brepository.Bruger.Where(s => s.Id == id).FirstOrDefault();
            return View(b1);
        }

        [HttpPost]
        public ActionResult RedigerBruger(Bruger bruger)
        {
            if (ModelState.IsValid)
            {
                brepository.RedigerBruger(bruger);
                TempData["message"] = string.Format("{0} has been updated", bruger.Id);
                return RedirectToAction("BrugerRedigeret");
            }
            else
            {
                return View(bruger);
            }
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
        public ActionResult TilføjerOprettet()
        {
            return View();
        }
        public ActionResult BrugerOprettet()
        {
            return View();
        }
        public ActionResult BrugerRedigeret()
        {
            return View();
        }
      





    }
}