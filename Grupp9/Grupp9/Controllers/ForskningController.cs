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
    public class ForskningController : Controller
    {
        // GET: Forskning
        [Authorize]
        public ActionResult Index()
        {
            var entities = new InfoDbContext();
            var currentUser = User.Identity.GetUserId();

            return View(entities.FormellaInläggen.Where(i => i.TypAvInlägg == "Forskning").ToList());
        }

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
                    Text = model.text,
                    TypAvInlägg = "Forskning"
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

        public string Namn(string userid)
        {
            var entities = new InfoDbContext();
            var profil = entities.Profiler.SingleOrDefault(x => x.UserId == userid);
            return (profil.Förnamn + " " + profil.Efternamn);
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

        public ActionResult LäsKommentar(ListaKommenterare model)
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
                        bloggId = x.BloggId,
                        kommentarID = x.Id,
                        userID = x.UserId

                    });
                }
            }
            //FullLista = new ListaKommenterare
            //{
            //    listan = lista.ToList()
            //};

            model.listan = lista.ToList();


            return View(model);
        }
    }
}