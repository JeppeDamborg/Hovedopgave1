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

    }
}