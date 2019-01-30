using Datalager;
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
        public ActionResult Index()
        {
            

            return View();
        }

        [HttpPost]
        public ActionResult Skriv(FormellaInläggViewModell model)
        {
            var db = new InfoDbContext();
            var currentUser = "testtext";

            db.FormellaInläggen.Add(new Datalager.Models.FormellaInlägg
            {
                UserId = currentUser,
                Titel = model.titel,
                Text = model.text




            });

            db.SaveChanges();

            return View(model);


        }
    }
}