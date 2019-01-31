
using Grupp9.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Grupp9.Controllers
{
    public class FormellaInläggController : Controller
    {
        // GET: FormellaInlägg
        
        [Authorize]
        public ActionResult Index()
        {
            var entities = new InfoDbContext();

            return View(entities.FormellaInläggen.ToList());
        }

        //[HttpPost]
        [Authorize]
        public ActionResult Skriv(FormellaInläggViewModell model)
        {
            if (ModelState.IsValid)
            {
                var db = new InfoDbContext();
                var currentUser = User.Identity.GetUserId();

                db.FormellaInläggen.Add(new FormellaInlägg
                {
                    UserId = currentUser,
                    Titel = model.titel,
                    Text = model.text
                });

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);


        }
    }
}