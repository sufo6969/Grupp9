
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

        [Authorize]
        public ActionResult Index()
        {
            var entities = new InfoDbContext();

            return View(entities.FormellaInläggen.ToList());
        }

        //[HttpPost]
        [Authorize]
        public ActionResult Skriv(FormellaInläggViewModell model, HttpPostedFileBase[] files)
        {
            if (model.text != null && model.titel != null)
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
                    foreach (HttpPostedFileBase file in files)
                    {
                        if (file != null)
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
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult SkrivKommentar(SkrivKommentarViewModel model)
        {
            if (model.kommentarText != null)
            {
                var db = new InfoDbContext();
                var currentUser = User.Identity.GetUserId();
                db.Kommentarer.Add(new Kommentar
                {
                    UserId = currentUser,
                    Text = model.kommentarText,
                    BloggId = model.bloggId
                });
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult LäsKommentar(LäsaKommenterarViewModel model)
        {
            var db = new InfoDbContext();

            var FullLista = new ListaKommenterare();
            var lista = new List<LäsaKommenterarViewModel>();

            foreach (var x in db.Kommentarer)
            {
                if (x.BloggId == model.bloggId)
                {
                    lista.Add(new LäsaKommenterarViewModel
                    {
                        kommentarText = x.Text,
                        bloggId = x.BloggId
                    });

                }
            }
            FullLista = new ListaKommenterare
            {
                listan = lista.ToList()
            };

            return View();
        }


    }
}