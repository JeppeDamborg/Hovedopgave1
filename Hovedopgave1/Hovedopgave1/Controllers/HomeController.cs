using System;
using System.Collections.Generic;
using System.IO;
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


        [Authorize]
        public ActionResult Forside()
        {
            return View();
        }

        [Authorize]
        public ActionResult BrugerForside()
        {
            return View();
        }
        [Authorize]
        public ActionResult MedarbejderForside()
        {
            return View();
        }


        public ActionResult OpretStudent()
        {
            

            return View();
        }

        [HttpPost]
        public ActionResult OpretStudent([Bind(Exclude = "CV, CVTitel")]Students students,HttpPostedFileBase CV)
        {

            if(CV != null)
            {
                if(CV.ContentLength > 0)
                {
                    var filename = Path.GetFileName(CV.FileName);
                    byte[] cvbinarydata = new byte[CV.ContentLength];
                    int readresult = CV.InputStream.Read(cvbinarydata, 0, CV.ContentLength);
                    students.CVTitel = filename;
                    students.CV = cvbinarydata;
                }
            }


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
        [Authorize]
        public ActionResult StudentListe()
        {
           

            return View(srepository.Students);
        }
        [Authorize]
        public ActionResult StudentListeMedarbejder()
        {


            return View(srepository.Students);
        }

        [HttpPost]
        public ActionResult StudentListeMedarbejder(string navn, string uddannelse, string semester, string emne)
        {
            List<Students> studentlist = new List<Students>();
            if (ModelState.IsValid)
            {

                if (navn != "")
                {
                    studentlist = srepository.SøgStudentPåNavn(navn);
                }
                if (uddannelse != "")
                {
                    studentlist = srepository.SøgPåStudentUddannelse(uddannelse);
                }
                if (semester != "")
                {
                    studentlist = srepository.SøgPåStudentSemester(semester);
                }
                if (emne != "")
                {
                    studentlist = srepository.SøgPåStudentSPHOP(emne);
                }

                if (navn != "" && uddannelse != "")
                {
                    studentlist = srepository.SøgStudentPåNavnOgUdannelse(navn, uddannelse);
                }
                if (navn != "" && semester != "")
                {
                    studentlist = srepository.SøgStudentPåNavnOgSemester(navn, semester);
                }

                if (uddannelse != "" && semester != "")
                {
                    studentlist = srepository.SøgStudentPåUddannelseOgSemester(uddannelse, semester);
                    
                }
               
                if (navn != "" && emne != "")
                {
                    studentlist = srepository.SøgStudentPåNavnOgSPHOP(navn, emne);
                }
                if (uddannelse != "" && emne != "")
                {
                    studentlist = srepository.SøgStudentPåUddannelseOgSPHOP(uddannelse, emne);
                }
                if (semester != "" && emne != "")
                {
                    studentlist = srepository.SøgStudentPåSemesterOgSPHOP(semester, emne);
                }
                if (uddannelse != "" && semester != "" && emne != "")
                {
                    studentlist = srepository.SøgStudentPåUddannelseOgSemesterOgSPHOP(uddannelse, semester, emne);
                }
                if (navn != "" && semester != "" && uddannelse != "" && emne != "")
                {
                    studentlist = srepository.SøgStudentPÅAlt(navn, semester, emne, uddannelse);
                }

                return View(studentlist);
            }
            else
            {
                return View();
            }
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
                if(uddannelse != "" && semester != "" && emne != "")
                {
                    studentlist = srepository.SøgStudentPåUddannelseOgSemesterOgSPHOP(uddannelse, semester, emne);
                }
                if (navn != "" && semester != "" && uddannelse !="" && emne != "")
                {
                    studentlist = srepository.SøgStudentPÅAlt(navn, semester, emne, uddannelse);
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
        [Authorize]
        public ActionResult VirksomhedListe()
        {
            return View(vrespository.Virksomhed);
        }
        [Authorize]
        public ActionResult VirksomhedListeMedarbejder()
        {
            return View(vrespository.Virksomhed);
        }

        [HttpPost]
        public ActionResult VirksomhedListeMedarbejder(string navn, string opgave, string profiler, string position)
        {
            List<Virksomhed> virksomhedslist = new List<Virksomhed>();
            if (ModelState.IsValid)
            {

                if (navn != "")
                {
                    virksomhedslist = vrespository.SøgVirksomhedPåNavn(navn);
                }
                if (opgave != "")
                {
                    virksomhedslist = vrespository.SøgVirksomhedPåMuligeOpgaver(opgave);
                }
                if (profiler != "")
                {
                    virksomhedslist = vrespository.SøgVirksomhedPåProfiler(profiler);
                }

                if (position != "")
                {
                    virksomhedslist = vrespository.SøgVirksomhedPåStyrkeposition(position);
                }
                if (opgave != "" && position != "")
                {
                    virksomhedslist = vrespository.SøgVirksomhedPåOpgaverOgPosition(opgave, position);
                }
                if (position != "" && profiler != "")
                {
                    virksomhedslist = vrespository.SøgVirksomhedPåProfilerOgPosition(profiler, position);
                }
                if (opgave != "" && profiler != "")
                {
                    virksomhedslist = vrespository.SøgVirksomhedPåOpgaverOgProfiler(opgave, profiler);
                }
                if (opgave != "" && profiler != "" && position != "")
                {
                    virksomhedslist = vrespository.SøgVirksomhedPåOpgaverOgProfilerOgPosition(opgave, profiler, position);
                }
                if (navn != "" && opgave != "" && profiler != "" && position != "")
                {
                    virksomhedslist = vrespository.SøgVirksomhedPåAlt(navn, opgave, profiler, position);
                }


                return View(virksomhedslist);
            }
            else
            {
                return View();
            }
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
                if(opgave != "" && profiler != "")
                {
                    virksomhedslist = vrespository.SøgVirksomhedPåOpgaverOgProfiler(opgave, profiler);
                }
                if(opgave != "" && profiler != "" && position != "")
                {
                    virksomhedslist = vrespository.SøgVirksomhedPåOpgaverOgProfilerOgPosition(opgave, profiler, position);
                }
                if(navn !="" && opgave !="" && profiler !="" && position != "")
                {
                    virksomhedslist = vrespository.SøgVirksomhedPåAlt(navn, opgave, profiler, position);
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
        public ActionResult OpretTilføjer([Bind(Exclude = "CV, CVTitel")]Tilføjer tilføjer, HttpPostedFileBase CV)
        {


            if (CV != null)
            {
                if (CV.ContentLength > 0)
                {
                    var filename = Path.GetFileName(CV.FileName);
                    byte[] cvbinarydata = new byte[CV.ContentLength];
                    int readresult = CV.InputStream.Read(cvbinarydata, 0, CV.ContentLength);
                    tilføjer.CVTitel = filename;
                    tilføjer.CV = cvbinarydata;
                }
            }

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
        [Authorize]
        public ActionResult TilføjerListe()
        {
            return View(trepository.Tilføjer);
        }

        [Authorize]
        public ActionResult TilføjerListeMedarbejder()
        {
            return View(trepository.Tilføjer);
        }

        [HttpPost]
        public ActionResult TilføjerListeMedarbejder(string navn, string uddannelse, string jobØnske, string kompetence, int? flytning, string sekundærUddannelse)
        {
            List<Tilføjer> tilføjerlist = new List<Tilføjer>();
            if (ModelState.IsValid)
            {

                if (uddannelse != "")
                {
                    tilføjerlist = trepository.SøgTilføjerPåUddannelse(uddannelse);
                }
                if (navn != "")
                {
                    tilføjerlist = trepository.SøgTilføjerPåNavn(navn);
                }
                if (jobØnske != "")
                {
                    tilføjerlist = trepository.SøgTilføjerPåJobØnske(jobØnske);
                }
                if (kompetence != "")
                {
                    tilføjerlist = trepository.SøgTilføjerPåFagligeKompetencer(kompetence);
                }
                if (flytning == 1)
                {
                    tilføjerlist = trepository.SøgTilføjerPåØnskeOmTilflytning(flytning);
                }
                if (uddannelse != "" && flytning == 1)
                {
                    tilføjerlist = trepository.SøgTilføjerPåUddannelseOgTilflytning(uddannelse, flytning);
                }
                if (jobØnske != "" && flytning == 1)
                {
                    tilføjerlist = trepository.SøgTilføjerPåJobØnskeOgTilflytning(jobØnske, flytning);
                }
                if (kompetence != "" && flytning == 1)
                {
                    tilføjerlist = trepository.SøgTilføjerPåKompetenceOgTilflytning(kompetence, flytning);
                }
                if (sekundærUddannelse != "" && jobØnske != "")
                {
                    tilføjerlist = trepository.SøgTilføjerPåSekundærUddannelseOgJobØnske(sekundærUddannelse, jobØnske);
                }
                if (navn != "" && uddannelse != "" && sekundærUddannelse != "" && jobØnske != "" && kompetence != "" && flytning == 1)
                {
                    tilføjerlist = trepository.SøgTilføjerPåAlt(navn, uddannelse, sekundærUddannelse, jobØnske, kompetence, flytning);
                }
                if (sekundærUddannelse != "" && flytning == 1)
                {
                    tilføjerlist = trepository.SøgTilføjerPåSekundærUddannelseOgFlytning(sekundærUddannelse, flytning);
                }
                if (uddannelse != "" && jobØnske != "")
                {
                    tilføjerlist = trepository.SøgTilføjerPåUddannelseOgJobØnske(uddannelse, jobØnske);
                }
                if (uddannelse != "" && kompetence != "")
                {
                    tilføjerlist = trepository.SøgTilføjerPåUddannelseOgKompetence(uddannelse, kompetence);
                }
                if (uddannelse != "" && sekundærUddannelse != "")
                {
                    tilføjerlist = trepository.SøgTilføjerPåUddannelseOgSekundærUddannelse(uddannelse, sekundærUddannelse);
                }
                if (jobØnske != "" && kompetence != "")
                {
                    tilføjerlist = trepository.SøgTilføjerPåJobØnskeOgKompetence(jobØnske, kompetence);
                }
                if (kompetence != "" && sekundærUddannelse != "")
                {
                    tilføjerlist = trepository.SøgTilføjerPåKompetenceOgSekundærUddannelse(kompetence, sekundærUddannelse);
                }
                if (uddannelse != "" && jobØnske != "" && kompetence != "")
                {
                    tilføjerlist = trepository.SøgTilføjerPåUddannelseOgJobØnskeOgKompetence(uddannelse, jobØnske, kompetence);
                }
                if (uddannelse != "" && sekundærUddannelse != "" && jobØnske != "")
                {
                    tilføjerlist = trepository.SøgTilføjerPåUddannelseOgSekundærUddannelseOgJobØnske(uddannelse, sekundærUddannelse, jobØnske);
                }
                if (uddannelse != "" && flytning == 1 && jobØnske != "")
                {
                    tilføjerlist = trepository.SøgTilføjerPåUddannelseOgFlytningOgJobØnske(uddannelse, flytning, jobØnske);
                }
                if (uddannelse != "" && flytning == 1 && kompetence != "")
                {
                    tilføjerlist = trepository.SøgTilføjerPåUddannelseOgFlytningOgKompetence(uddannelse, flytning, kompetence);
                }
                if (uddannelse != "" && flytning == 1 && sekundærUddannelse != "")
                {
                    tilføjerlist = trepository.SøgTilføjerPåUddannelseOgFlytningOgSekundærUddannelse(uddannelse, flytning, sekundærUddannelse);
                }
                if (uddannelse != "" && sekundærUddannelse != "" && kompetence != "")
                {
                    tilføjerlist = trepository.SøgTilføjerPåUddannelseOgSekundærUddannelseOgKompetence(uddannelse, sekundærUddannelse, kompetence);
                }
                if (sekundærUddannelse != "" && kompetence != "" && jobØnske != "")
                {
                    tilføjerlist = trepository.SøgTilføjerPåSekundærUddannelseOgKompetencerOgJobØnske(sekundærUddannelse, kompetence, jobØnske);
                }
                if (flytning == 1 && jobØnske != "" && kompetence != "")
                {
                    tilføjerlist = trepository.SøgTilføjerPåFlytningOgJobØnskeOgKompetence(flytning, jobØnske, kompetence);
                }
                if (flytning == 1 && jobØnske != "" && sekundærUddannelse != "")
                {
                    tilføjerlist = trepository.SøgTilføjerPåFlytningOgJobØnskeOgKompetence(flytning, jobØnske, kompetence);
                }
                if (flytning == 1 && kompetence != "" && sekundærUddannelse != "")
                {
                    tilføjerlist = trepository.SøgTilføjerPåFlytningOgKompetenceOgSekundærUddannelse(flytning, kompetence, sekundærUddannelse);
                }
                if (uddannelse != "" && jobØnske != "" && kompetence != "" && flytning == 1)
                {
                    tilføjerlist = trepository.SøgTilføjerPåUddannelseOgJobØnskeOgKompetenceOgFlytning(uddannelse, jobØnske, kompetence, flytning);
                }
                if (uddannelse != "" && jobØnske != "" && kompetence != "" && sekundærUddannelse != "")
                {
                    tilføjerlist = trepository.SøgTilføjerPåUddannelseOgJobØnskeOgKompetenceOgSekundærUddannelse(uddannelse, jobØnske, kompetence, sekundærUddannelse);
                }
                if (uddannelse != "" && jobØnske != "" && sekundærUddannelse != "" && flytning == 1)
                {
                    tilføjerlist = trepository.SøgTilføjerPåUddannelseOgJobØnskeOgSekundærUddannelseOgFlytning(uddannelse, jobØnske, sekundærUddannelse, flytning);
                }
                if (uddannelse != "" && kompetence != "" && sekundærUddannelse != "" && flytning == 1)
                {
                    tilføjerlist = trepository.SøgTilføjerPåUddannelseOgKompetenceOgSekundærUddannelseOgFlytning(uddannelse, kompetence, sekundærUddannelse, flytning);
                }
                if (jobØnske != "" && kompetence != "" && sekundærUddannelse != "" && flytning == 1)
                {
                    tilføjerlist = trepository.SøgTilføjerPåJobØnskeOgKompetenceOgSekundærUddannelseOgFlytning(jobØnske, kompetence, sekundærUddannelse, flytning);
                }

                if (kompetence != "" && uddannelse != "" && jobØnske != "" && sekundærUddannelse != "" && flytning == 1)
                {
                    tilføjerlist = trepository.SøgTilføjerPåKompetenceOgUddannelseOgJobØnskeOgSekundærUddannelseOgFlytning(kompetence, uddannelse, jobØnske, sekundærUddannelse, flytning);
                }



                return View(tilføjerlist);
            }
            else
            {
                return View();
            }
        }

        [Authorize]
        public ActionResult TilføjerListeBruger()
        {
            return View(trepository.Tilføjer);
        }

        [HttpPost]
        public ActionResult TilføjerListeBruger(string navn, string uddannelse, string jobØnske, string kompetence, int? flytning, string sekundærUddannelse)
        {
            List<Tilføjer> tilføjerlist = new List<Tilføjer>();
            if (ModelState.IsValid)
            {

                if (uddannelse != "")
                {
                    tilføjerlist = trepository.SøgTilføjerPåUddannelse(uddannelse);
                }
                if (navn != "")
                {
                    tilføjerlist = trepository.SøgTilføjerPåNavn(navn);
                }
                if (jobØnske != "")
                {
                    tilføjerlist = trepository.SøgTilføjerPåJobØnske(jobØnske);
                }
                if (kompetence != "")
                {
                    tilføjerlist = trepository.SøgTilføjerPåFagligeKompetencer(kompetence);
                }
                if (flytning == 1)
                {
                    tilføjerlist = trepository.SøgTilføjerPåØnskeOmTilflytning(flytning);
                }
                if (uddannelse != "" && flytning == 1)
                {
                    tilføjerlist = trepository.SøgTilføjerPåUddannelseOgTilflytning(uddannelse, flytning);
                }
                if (jobØnske != "" && flytning == 1)
                {
                    tilføjerlist = trepository.SøgTilføjerPåJobØnskeOgTilflytning(jobØnske, flytning);
                }
                if (kompetence != "" && flytning == 1)
                {
                    tilføjerlist = trepository.SøgTilføjerPåKompetenceOgTilflytning(kompetence, flytning);
                }
                if (sekundærUddannelse != "" && jobØnske != "")
                {
                    tilføjerlist = trepository.SøgTilføjerPåSekundærUddannelseOgJobØnske(sekundærUddannelse, jobØnske);
                }
                if (navn != "" && uddannelse != "" && sekundærUddannelse != "" && jobØnske != "" && kompetence != "" && flytning == 1)
                {
                    tilføjerlist = trepository.SøgTilføjerPåAlt(navn, uddannelse, sekundærUddannelse, jobØnske, kompetence, flytning);
                }
                if (sekundærUddannelse != "" && flytning == 1)
                {
                    tilføjerlist = trepository.SøgTilføjerPåSekundærUddannelseOgFlytning(sekundærUddannelse, flytning);
                }
                if (uddannelse != "" && jobØnske != "")
                {
                    tilføjerlist = trepository.SøgTilføjerPåUddannelseOgJobØnske(uddannelse, jobØnske);
                }
                if (uddannelse != "" && kompetence != "")
                {
                    tilføjerlist = trepository.SøgTilføjerPåUddannelseOgKompetence(uddannelse, kompetence);
                }
                if (uddannelse != "" && sekundærUddannelse != "")
                {
                    tilføjerlist = trepository.SøgTilføjerPåUddannelseOgSekundærUddannelse(uddannelse, sekundærUddannelse);
                }
                if (jobØnske != "" && kompetence != "")
                {
                    tilføjerlist = trepository.SøgTilføjerPåJobØnskeOgKompetence(jobØnske, kompetence);
                }
                if (kompetence != "" && sekundærUddannelse != "")
                {
                    tilføjerlist = trepository.SøgTilføjerPåKompetenceOgSekundærUddannelse(kompetence, sekundærUddannelse);
                }
                if (uddannelse != "" && jobØnske != "" && kompetence != "")
                {
                    tilføjerlist = trepository.SøgTilføjerPåUddannelseOgJobØnskeOgKompetence(uddannelse, jobØnske, kompetence);
                }
                if (uddannelse != "" && sekundærUddannelse != "" && jobØnske != "")
                {
                    tilføjerlist = trepository.SøgTilføjerPåUddannelseOgSekundærUddannelseOgJobØnske(uddannelse, sekundærUddannelse, jobØnske);
                }
                if (uddannelse != "" && flytning == 1 && jobØnske != "")
                {
                    tilføjerlist = trepository.SøgTilføjerPåUddannelseOgFlytningOgJobØnske(uddannelse, flytning, jobØnske);
                }
                if (uddannelse != "" && flytning == 1 && kompetence != "")
                {
                    tilføjerlist = trepository.SøgTilføjerPåUddannelseOgFlytningOgKompetence(uddannelse, flytning, kompetence);
                }
                if (uddannelse != "" && flytning == 1 && sekundærUddannelse != "")
                {
                    tilføjerlist = trepository.SøgTilføjerPåUddannelseOgFlytningOgSekundærUddannelse(uddannelse, flytning, sekundærUddannelse);
                }
                if (uddannelse != "" && sekundærUddannelse != "" && kompetence != "")
                {
                    tilføjerlist = trepository.SøgTilføjerPåUddannelseOgSekundærUddannelseOgKompetence(uddannelse, sekundærUddannelse, kompetence);
                }
                if (sekundærUddannelse != "" && kompetence != "" && jobØnske != "")
                {
                    tilføjerlist = trepository.SøgTilføjerPåSekundærUddannelseOgKompetencerOgJobØnske(sekundærUddannelse, kompetence, jobØnske);
                }
                if (flytning == 1 && jobØnske != "" && kompetence != "")
                {
                    tilføjerlist = trepository.SøgTilføjerPåFlytningOgJobØnskeOgKompetence(flytning, jobØnske, kompetence);
                }
                if (flytning == 1 && jobØnske != "" && sekundærUddannelse != "")
                {
                    tilføjerlist = trepository.SøgTilføjerPåFlytningOgJobØnskeOgKompetence(flytning, jobØnske, kompetence);
                }
                if (flytning == 1 && kompetence != "" && sekundærUddannelse != "")
                {
                    tilføjerlist = trepository.SøgTilføjerPåFlytningOgKompetenceOgSekundærUddannelse(flytning, kompetence, sekundærUddannelse);
                }
                if (uddannelse != "" && jobØnske != "" && kompetence != "" && flytning == 1)
                {
                    tilføjerlist = trepository.SøgTilføjerPåUddannelseOgJobØnskeOgKompetenceOgFlytning(uddannelse, jobØnske, kompetence, flytning);
                }
                if (uddannelse != "" && jobØnske != "" && kompetence != "" && sekundærUddannelse != "")
                {
                    tilføjerlist = trepository.SøgTilføjerPåUddannelseOgJobØnskeOgKompetenceOgSekundærUddannelse(uddannelse, jobØnske, kompetence, sekundærUddannelse);
                }
                if (uddannelse != "" && jobØnske != "" && sekundærUddannelse != "" && flytning == 1)
                {
                    tilføjerlist = trepository.SøgTilføjerPåUddannelseOgJobØnskeOgSekundærUddannelseOgFlytning(uddannelse, jobØnske, sekundærUddannelse, flytning);
                }
                if (uddannelse != "" && kompetence != "" && sekundærUddannelse != "" && flytning == 1)
                {
                    tilføjerlist = trepository.SøgTilføjerPåUddannelseOgKompetenceOgSekundærUddannelseOgFlytning(uddannelse, kompetence, sekundærUddannelse, flytning);
                }
                if (jobØnske != "" && kompetence != "" && sekundærUddannelse != "" && flytning == 1)
                {
                    tilføjerlist = trepository.SøgTilføjerPåJobØnskeOgKompetenceOgSekundærUddannelseOgFlytning(jobØnske, kompetence, sekundærUddannelse, flytning);
                }

                if (kompetence != "" && uddannelse != "" && jobØnske != "" && sekundærUddannelse != "" && flytning == 1)
                {
                    tilføjerlist = trepository.SøgTilføjerPåKompetenceOgUddannelseOgJobØnskeOgSekundærUddannelseOgFlytning(kompetence, uddannelse, jobØnske, sekundærUddannelse, flytning);
                }



                return View(tilføjerlist);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult TilføjerListe(string navn ,string uddannelse, string jobØnske, string kompetence, int? flytning, string sekundærUddannelse)
        {
            List<Tilføjer> tilføjerlist = new List<Tilføjer>();
            if (ModelState.IsValid)
            {

                if (uddannelse != "")
                {
                    tilføjerlist = trepository.SøgTilføjerPåUddannelse(uddannelse);
                }
                if(navn != "")
                {
                    tilføjerlist = trepository.SøgTilføjerPåNavn(navn);
                }
                if (jobØnske != "")
                {
                    tilføjerlist = trepository.SøgTilføjerPåJobØnske(jobØnske);
                }
                if(kompetence != "")
                {
                    tilføjerlist = trepository.SøgTilføjerPåFagligeKompetencer(kompetence);
                }
                if(flytning == 1)
                {
                    tilføjerlist = trepository.SøgTilføjerPåØnskeOmTilflytning(flytning);
                }
                if(uddannelse != "" && flytning == 1)
                {
                    tilføjerlist = trepository.SøgTilføjerPåUddannelseOgTilflytning(uddannelse, flytning);
                }
                if(jobØnske != "" && flytning == 1)
                {
                    tilføjerlist = trepository.SøgTilføjerPåJobØnskeOgTilflytning(jobØnske, flytning);
                }
                if(kompetence != "" && flytning == 1)
                {
                    tilføjerlist = trepository.SøgTilføjerPåKompetenceOgTilflytning(kompetence, flytning);
                }
                if(sekundærUddannelse != "" && jobØnske != "")
                {
                    tilføjerlist = trepository.SøgTilføjerPåSekundærUddannelseOgJobØnske(sekundærUddannelse, jobØnske);
                }
                if(navn != "" && uddannelse != "" && sekundærUddannelse != "" && jobØnske != "" && kompetence != "" && flytning == 1)
                {
                    tilføjerlist = trepository.SøgTilføjerPåAlt(navn, uddannelse, sekundærUddannelse, jobØnske, kompetence, flytning);
                }
                if(sekundærUddannelse !="" && flytning == 1)
                {
                    tilføjerlist = trepository.SøgTilføjerPåSekundærUddannelseOgFlytning(sekundærUddannelse, flytning);
                }
                if(uddannelse !="" && jobØnske != "")
                {
                    tilføjerlist = trepository.SøgTilføjerPåUddannelseOgJobØnske(uddannelse, jobØnske);
                }
                if (uddannelse != "" && kompetence != "")
                {
                    tilføjerlist = trepository.SøgTilføjerPåUddannelseOgKompetence(uddannelse, kompetence);
                }
                if(uddannelse != "" && sekundærUddannelse != "")
                {
                    tilføjerlist = trepository.SøgTilføjerPåUddannelseOgSekundærUddannelse(uddannelse, sekundærUddannelse);
                }
                if(jobØnske != "" && kompetence != "")
                {
                    tilføjerlist = trepository.SøgTilføjerPåJobØnskeOgKompetence(jobØnske, kompetence);
                }
                if(kompetence != "" && sekundærUddannelse != "")
                {
                    tilføjerlist = trepository.SøgTilføjerPåKompetenceOgSekundærUddannelse(kompetence, sekundærUddannelse);
                }
                if(uddannelse !="" && jobØnske !="" && kompetence != "")
                {
                    tilføjerlist = trepository.SøgTilføjerPåUddannelseOgJobØnskeOgKompetence(uddannelse, jobØnske, kompetence);
                }
                if(uddannelse !="" && sekundærUddannelse !="" && jobØnske != "")
                {
                    tilføjerlist = trepository.SøgTilføjerPåUddannelseOgSekundærUddannelseOgJobØnske(uddannelse, sekundærUddannelse, jobØnske);
                }
                if(uddannelse !="" && flytning == 1 && jobØnske != "")
                {
                    tilføjerlist = trepository.SøgTilføjerPåUddannelseOgFlytningOgJobØnske(uddannelse, flytning, jobØnske);
                }
                if(uddannelse != "" && flytning == 1 && kompetence!= "")
                {
                    tilføjerlist = trepository.SøgTilføjerPåUddannelseOgFlytningOgKompetence(uddannelse, flytning, kompetence);
                }
                if(uddannelse != "" && flytning == 1 && sekundærUddannelse != "")
                {
                    tilføjerlist = trepository.SøgTilføjerPåUddannelseOgFlytningOgSekundærUddannelse(uddannelse, flytning, sekundærUddannelse);
                }
                if(uddannelse != "" && sekundærUddannelse !="" && kompetence != "")
                {
                    tilføjerlist = trepository.SøgTilføjerPåUddannelseOgSekundærUddannelseOgKompetence(uddannelse, sekundærUddannelse, kompetence);
                }
                if(sekundærUddannelse !="" && kompetence !="" && jobØnske != "")
                {
                    tilføjerlist = trepository.SøgTilføjerPåSekundærUddannelseOgKompetencerOgJobØnske(sekundærUddannelse, kompetence, jobØnske);
                }
                if(flytning == 1 && jobØnske != "" && kompetence != "")
                {
                    tilføjerlist = trepository.SøgTilføjerPåFlytningOgJobØnskeOgKompetence(flytning, jobØnske, kompetence);
                }
                if(flytning == 1 && jobØnske != "" && sekundærUddannelse != "")
                {
                    tilføjerlist = trepository.SøgTilføjerPåFlytningOgJobØnskeOgKompetence(flytning, jobØnske, kompetence);
                }
                if(flytning == 1 && kompetence != "" && sekundærUddannelse != "")
                {
                    tilføjerlist = trepository.SøgTilføjerPåFlytningOgKompetenceOgSekundærUddannelse(flytning, kompetence, sekundærUddannelse);
                }
                if(uddannelse !="" && jobØnske !="" && kompetence !="" && flytning == 1)
                {
                    tilføjerlist = trepository.SøgTilføjerPåUddannelseOgJobØnskeOgKompetenceOgFlytning(uddannelse, jobØnske, kompetence, flytning);
                }
                if(uddannelse != "" && jobØnske != "" && kompetence != "" && sekundærUddannelse != "") {
                    tilføjerlist = trepository.SøgTilføjerPåUddannelseOgJobØnskeOgKompetenceOgSekundærUddannelse(uddannelse, jobØnske, kompetence, sekundærUddannelse);
                }
                if(uddannelse != "" && jobØnske !="" && sekundærUddannelse !="" && flytning == 1)
                {
                    tilføjerlist = trepository.SøgTilføjerPåUddannelseOgJobØnskeOgSekundærUddannelseOgFlytning(uddannelse, jobØnske, sekundærUddannelse, flytning);
                }
                if(uddannelse != "" && kompetence != "" && sekundærUddannelse != "" && flytning == 1)
                {
                    tilføjerlist = trepository.SøgTilføjerPåUddannelseOgKompetenceOgSekundærUddannelseOgFlytning(uddannelse, kompetence, sekundærUddannelse, flytning);
                }
                if(jobØnske != "" && kompetence != "" && sekundærUddannelse != "" && flytning == 1)
                {
                    tilføjerlist = trepository.SøgTilføjerPåJobØnskeOgKompetenceOgSekundærUddannelseOgFlytning(jobØnske, kompetence, sekundærUddannelse, flytning);
                }

                if(kompetence != "" && uddannelse != "" && jobØnske != "" && sekundærUddannelse != "" && flytning == 1)
                {
                    tilføjerlist = trepository.SøgTilføjerPåKompetenceOgUddannelseOgJobØnskeOgSekundærUddannelseOgFlytning(kompetence, uddannelse, jobØnske, sekundærUddannelse, flytning);
                }

               

                return View(tilføjerlist);
            }
            else
            {
                return View();
            }
 
            
        }

        public ActionResult TilføjerDelete(int id)
        {
            Tilføjer tilføjer = trepository.SletTilføjer(id);
            if(tilføjer != null)
            {
                TempData["message"] = string.Format("{0} has been deleted", tilføjer.Id);
            }
            return RedirectToAction("Forside");
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
        [Authorize]
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
        [HttpGet]
        public ActionResult RedigerTilføjer(int id)
        {
            var t1 = trepository.Tilføjer.Where(s => s.Id == id).FirstOrDefault();
            return View(t1);
        }
        [HttpPost]
        public ActionResult RedigerTilføjer(Tilføjer tilføjer)
        {
            if (ModelState.IsValid) {
                trepository.RedigerTilføjer(tilføjer);
                TempData["message"] = string.Format("{0} has been updated", tilføjer.Id);
                return RedirectToAction("TilføjerRedigeret");
                     }
            else {
                return View(tilføjer);
            }
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
        public ActionResult TilføjerRedigeret()
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

        public FileContentResult DownloadStudentCV(int id, string cvtitel)
        {
            if(id == 0) { return null; }
            Students students = new Students();
            students = context.Students.Where(s => s.Id == id).SingleOrDefault();
            Response.AppendHeader("content-disposition", "inline; filename=" + cvtitel);
            return File(students.CV, "application/pdf");
        }

        public FileContentResult DownloadTilføjerCV(int id, string cvtitel)
        {
            if(id == 0) { return null; }
            Tilføjer tilføjer = new Tilføjer();
            tilføjer = context.Tilføjer.Where(s => s.Id == id).SingleOrDefault();
            Response.AppendHeader("content-disposition", "inline; filename=" + cvtitel);
            return File(tilføjer.CV, "application/pdf");
        }
      





    }
}