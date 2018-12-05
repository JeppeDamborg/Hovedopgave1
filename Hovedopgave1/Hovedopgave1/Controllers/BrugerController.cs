﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hovedopgave1.Abstract;
using Hovedopgave1.Concrete;
using Hovedopgave1.Models;
using System.Web.Security;

namespace Hovedopgave1.Controllers
{
    public class BrugerController : Controller
    {
        IAuthProvider authProvider;
        

        public BrugerController(IAuthProvider auth)
        {
            authProvider = auth;
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(Bruger bruger)
        {
            //if (bruger.Brugernavn != null)
            //{



                 if(ModelState.IsValid)
                {
                    EFDbContext context = new EFDbContext();
                    var login = context.Bruger.FirstOrDefault(a => a.Brugernavn == bruger.Brugernavn && a.Password == bruger.Password);
                    if (login != null)
                    {
                        FormsAuthentication.SetAuthCookie(bruger.Brugernavn, false);
                        return RedirectToAction("Forside", "Home");
                    }
                    else
                    {
                    ModelState.AddModelError("", "Forkert brugernavn eller password");


                
                    }
                return View(bruger);
                }
            return View();
                //return RedirectToAction("Forside", "Home");
            //}
            //else
            //{
                //ModelState.AddModelError("", "Forkert brugernavn eller password");
               // return View();
            //}
        }
    }
}