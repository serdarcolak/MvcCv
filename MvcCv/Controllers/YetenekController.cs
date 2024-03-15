using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class YetenekController : Controller
    {
        // GET: Yetenek
        GenericRepository<TblYeteneklerim> repo = new GenericRepository<TblYeteneklerim>();
        public ActionResult Index()
        {
            var yetenekler = repo.List();
            return View(yetenekler);
        }
        [HttpGet]
        public ActionResult YeniYetenek()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniYetenek(TblYeteneklerim p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult YetenekSil(int id)
        {
            TblYeteneklerim t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult YetenekGuncelle(int id)
        {
            TblYeteneklerim t = repo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult YetenekGuncelle(TblYeteneklerim p)
        {
            TblYeteneklerim t = repo.Find(x => x.ID == p.ID);
            t.Yetenek = p.Yetenek;
            t.Oran = p.Oran;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}