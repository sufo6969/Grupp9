
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


        
        //[HttpPost]
        [Authorize]
        public ActionResult Skriv(FormellaInläggViewModell model)
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

            return View();


        }
    }
}