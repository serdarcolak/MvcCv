using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class SertifikaController : Controller
    {
        GenericRepository<TblSertifikalarim> repo = new GenericRepository<TblSertifikalarim>();

        // GET: Sertifika
        public ActionResult Index()
        {
            var sertifika = repo.List();
            return View(sertifika);
        }

        [HttpGet]
        public ActionResult YeniSertifika()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSertifika(TblSertifikalarim p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult SertifikaSil(int id)
        {
            TblSertifikalarim t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult SertifikaGuncelle(int id)
        {
            TblSertifikalarim t = repo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult SertifikaGuncelle(TblSertifikalarim p)
        {
            TblSertifikalarim t = repo.Find(x => x.ID == p.ID);
            t.Aciklama = p.Aciklama;
            t.Tarih = p.Tarih;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}