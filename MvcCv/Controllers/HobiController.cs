using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Repositories;
using MvcCv.Models.Entity;

namespace MvcCv.Controllers
{
    public class HobiController : Controller
    {

        GenericRepository<TblHobilerim> repo = new GenericRepository<TblHobilerim>();
        // GET: Hobi
        public ActionResult Index()
        {
            var hobiler = repo.List();
            return View(hobiler);
        }
        [HttpGet]
        public ActionResult HobiGuncelle(int id)
        {
            TblHobilerim t = repo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult HobiGuncelle(TblHobilerim p)
        {
            TblHobilerim t = repo.Find(x => x.ID == p.ID);
            t.Aciklama1 = p.Aciklama1;
            t.Aciklama2 = p.Aciklama2;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}