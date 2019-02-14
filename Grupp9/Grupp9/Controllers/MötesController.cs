using Grupp9.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Grupp9.Controllers
{
    public class MötesController : Controller
    {
        // GET: Mötes
        public ActionResult Index()
        {
            var db = new InfoDbContext();
            var currentUser = User.Identity.GetUserId();

            return View(db.Möte.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mötes/Create
        [HttpPost]
        public ActionResult Create(MötenViewModel model)
        {
            var db = new InfoDbContext();
            var currentUser = User.Identity.GetUserId();

            var nyttMöte = new Möten
            {
                UserId = currentUser,
                MötesBeskrivning = model.Beskrivning,
                MöteId = model.MöteId,
                InbjudenEmail = model.InbjudenEmail
            };

            db.Möte.Add(nyttMöte);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Mötes/Edit/5
        //public ActionResult BjudIn(MötenViewModel model)
        //{
        //    var db = new InfoDbContext();
         

        //    var nyInbjudan = new Möten
        //    {
                
        //        InbjudenEmail = model.InbjudenEmail

        //    };

        //    db.Möte.Add(nyInbjudan);
        //    db.SaveChanges();

        //    return View();
        //}

        
    }
}
