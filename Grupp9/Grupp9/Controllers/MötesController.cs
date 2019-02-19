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

        public ActionResult Datum()
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
               
                
            };

            db.Möte.Add(nyttMöte);
            db.SaveChanges();
            var nyttid = nyttMöte.MöteId;

            var nyttDatum = new Datum
            {
                FörslagDatum = model.MötesTid.Value,
                ValtDatum = model.MötesTid.Value,
                MöteId = nyttid
            };
            db.Datumen.Add(nyttDatum);

            
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Mötes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Mötes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Mötes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Mötes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public string VisaDatum (int Mötesid)
        {
            var db = new InfoDbContext();
            var datum = db.Datumen.FirstOrDefault(x => x.MöteId == Mötesid);

            return datum.ValtDatum.ToString();
        }

        
    }
}
