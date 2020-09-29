using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dbcar.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace Dbcar.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        DbcarEntities db = new DbcarEntities();
        public ActionResult Index(int sayfa = 1)
        {
            var degerler = db.TblKategoriler.ToList().ToPagedList(sayfa, 6);
            return View(degerler);
        }

        [HttpGet]

        public ActionResult YeniKayit()
        {
            return View();
        }

        [HttpPost]

        public ActionResult YeniKayit(TblKategoriler a1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniKayit");
            }
            db.TblKategoriler.Add(a1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var a = db.TblKategoriler.Find(id);
            db.TblKategoriler.Remove(a);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Getir(int id)
        {
            var deger = db.TblKategoriler.Find(id);
            return View("Getir", deger);
        }

        public ActionResult Guncelle(TblKategoriler a1)
        {
            var ktg = db.TblKategoriler.Find(a1.KategoriId);
            ktg.KategoriAd = a1.KategoriAd;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}