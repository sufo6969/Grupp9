﻿
using Grupp9.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
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
        public ActionResult Skriv(FormellaInläggViewModell model, HttpPostedFileBase[] files)
        {
            var db = new InfoDbContext();
            var currentUser = User.Identity.GetUserId();
            var nyttInlägg = new FormellaInlägg
            {
                UserId = currentUser,
                Titel = model.titel,
                Text = model.text
            };
            db.FormellaInläggen.Add(nyttInlägg);
            db.SaveChanges();
            var bloggId = nyttInlägg.Id;

            if (files != null)
            {
                foreach(HttpPostedFileBase file in files)
                {
                    if(file != null)
                    {
                        var FilNamn = Path.GetFileName(file.FileName);
                        string path = Path.Combine(Server.MapPath("~/Filer"), FilNamn);
                        file.SaveAs(path);
                        string FilenSparadSom = "/Filer/" + FilNamn;
                        db.Filer.Add(new Fil
                        {
                            BloggInläggId = bloggId,
                            FilUrl = FilenSparadSom
                        });
                    }
                }
            }

            db.SaveChanges();

            return View();


        }
    }
}