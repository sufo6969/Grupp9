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

        [Authorize]
        public ActionResult Index()
        {
            var entities = new InfoDbContext();
            var currentUser = User.Identity.GetUserId();

            return View(entities.FormellaInläggen.ToList());
        }

        public string Namn(string userid) {
            var entities = new InfoDbContext();
            var profil = entities.Profiler.SingleOrDefault(x => x.UserId == userid);
            return (profil.Förnamn + " " + profil.Efternamn); 
        }

        //[HttpPost]
        [Authorize]
        public ActionResult Skriv(FormellaInläggViewModell model, HttpPostedFileBase[] files)
        {
            var db = new InfoDbContext();
            var list = db.Kategori.ToList();
            model.AllaKategorier = new SelectList(db.Kategori, "Id", "Namn", 1);

            if (model.text != null && model.titel != null)
            {
                
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

                db.BlogginläggsKategorier.Add( new BlogginläggsKategori{
                    BloggId = bloggId,
                    KategoriId = model.ValdKategori
                });

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public string Kategorinamn (int Bloggid)
        {
            var db = new InfoDbContext();
            var sak = db.BlogginläggsKategorier.FirstOrDefault(i => i.BloggId == Bloggid);
            var klar = " ";
            if(sak!= null)
            {
                var katId = sak.KategoriId;
                var kat = db.Kategori.FirstOrDefault(i => i.Id == katId);
                klar = kat.Namn;
            }
            
            return (klar);
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
                        bloggId = x.BloggId
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


        public ActionResult FilLista(ListaFilerViewModel model)
        {
            var lista = new List<FilerViewModel>();
            var db = new InfoDbContext();

            foreach (var fil in db.Filer)
            {
                if(fil.BloggInläggId == model.BloggInläggId)
                {
                    lista.Add(new FilerViewModel
                    {
                        filNamn = fil.FilUrl
                    });
                }
            }
            model.listanAvFiler = lista.ToList();

            return View(model);
        }

        public ActionResult LäggTillKategori (LäggTillKategorierViewModel model)
        {
            if (model.KategoriNamn != null)
            {

                var db = new InfoDbContext();
                var currentUser = User.Identity.GetUserId();
                db.Kategori.Add(new Kategorier
                {
                    //UserId = currentUser,
                    Namn = model.KategoriNamn,
                    Id = model.KategoriId,
                   
                });
               
                db.SaveChanges();
               
            }
            return View();


        }

        public ActionResult VisaKategori()
        {
            var db = new InfoDbContext();
            var list = db.Kategori.ToList();
            var model = new ListaKategorierViewModel { AllaKategorier = list };

            return View(model);
        }




    }
}