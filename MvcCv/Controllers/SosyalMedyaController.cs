﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;


namespace MvcCv.Controllers
{
    public class SosyalMedyaController : Controller
    {
        GenericRepository<TblSosyalMedya> repo = new GenericRepository<TblSosyalMedya>();

        // GET: SosyalMedya
        public ActionResult Index()
        {
            var data = repo.List();

            return View(data);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(TblSosyalMedya p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult SayfaGetir(int id)
        {
            var hesap = repo.Find(x => x.ID == id);

            return View(hesap);
        }
        [HttpPost]
        public ActionResult SayfaGetir(TblSosyalMedya p)
        {
            var hesap = repo.Find(x => x.ID == p.ID);
            hesap.Ad = p.Ad;
            hesap.Durum = true;
            hesap.Link = p.Link;
            hesap.ikon = p.ikon;
            repo.TUpdate(hesap);
            return RedirectToAction("Index");
        }

        public ActionResult Sil (int id)
        {
            var hesap = repo.Find(x => x.ID == id);
            if (hesap.Durum == true)
            {
                hesap.Durum = false;
            }
            else
            {
                hesap.Durum = true;
                
            }

            repo.TUpdate(hesap);
            return RedirectToAction("Index");
        }
    }
}