using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class HakkimdaController : Controller
    {

        GenericRepository<TblHakkimda> repo = new GenericRepository<TblHakkimda>();

        // GET: Hakkimda
        public ActionResult Index()
        {
            var hakkimda = repo.List();
            return View(hakkimda);
        }

        [HttpGet]
        public ActionResult HakkimdaGuncelle(int id)
        {
            TblHakkimda t = repo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult HakkimdaGuncelle(TblHakkimda p)
        {
            TblHakkimda t = repo.Find(x => x.ID == p.ID);
            t.Ad = p.Ad;
            t.Soyad = p.Soyad;
            t.Adres = p.Adres;
            t.Telefon = p.Telefon;
            t.Mail = p.Mail;
            t.Aciklama = p.Aciklama;
            t.Resim = p.Resim;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}