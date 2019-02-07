
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


        public ActionResult Delete(int IDet)
        {
            var db = new InfoDbContext();
            var kommentaren = db.Kommentarer.FirstOrDefault(k => k.Id == IDet);


            db.Kommentarer.Remove(kommentaren);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public bool Vemsomskrivit(string userID)
        {
            var db = new InfoDbContext();
            var inloggad = User.Identity.GetUserId();

            if (userID == inloggad) { return true; }
            else
            {
                return false;
            }
        }

        public string NamnFrånUserId(string userId)
        {
            var db = new InfoDbContext();
           
            var profilen = db.Profiler.FirstOrDefault(p => p.UserId == userId);
            var förnamn = profilen.Förnamn;
            var efternamn = profilen.Efternamn;

            return förnamn + " " + efternamn;
        }
    }
}