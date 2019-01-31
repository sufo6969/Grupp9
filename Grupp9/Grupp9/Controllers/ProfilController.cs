
using Grupp9.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Grupp9.Controllers
{
    public class ProfilController : Controller
    {
        [HttpPost]
        public ActionResult SparaProfil(ProfilViewModel model)
        {
            using (var db = new InfoDbContext())
            {
                var userId = User.Identity.GetUserId();
                var profile = db.Profiler.SingleOrDefault(x => x.UserId == userId);

                if (profile == null)
                {
                    profile = new Profil();
                    profile.UserId = userId;
                    db.Profiler.Add(profile);
                }

                profile.Förnamn = model.Förnamn;
                profile.Efternamn = model.Efternamn;
                profile.Roll = model.Roll;

                db.SaveChanges();
                ViewBag.StatusMessage = "Dina ändringar är sparade!";
                return View("~/Views/Manage/Index.cshtml", model);

            }
        }
    }
}