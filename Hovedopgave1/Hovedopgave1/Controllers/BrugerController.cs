using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hovedopgave1.Abstract;
using Hovedopgave1.Models;

namespace Hovedopgave1.Controllers
{
    public class BrugerController : Controller
    {
        IAuthProvider authProvider;

        public BrugerController(IAuthProvider auth)
        {
            authProvider = auth;
        }


        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(Bruger bruger, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if(authProvider.Authenticate(bruger.Brugernavn, bruger.Password))
                {
                    return Redirect(returnUrl ?? Url.Action("Forside", "Home"));
                }
                else
                {
                    ModelState.AddModelError("", "Forkert brugernavn eller password");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
    }
}