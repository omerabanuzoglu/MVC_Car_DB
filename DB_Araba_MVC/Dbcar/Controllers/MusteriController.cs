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
    public class MusteriController : Controller
    {
        // GET: Musteri
        DbcarEntities db = new DbcarEntities();

        public ActionResult Index(int sayfa = 1)
        {
            var degerler = db.TblMusteriler.ToList().ToPagedList(sayfa, 6);
            return View(degerler);
        }

        [HttpGet]

        public ActionResult YeniKayit()
        {
            return View();
        }

        [HttpPost]

        public ActionResult YeniKayit(TblMusteriler a1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniKayit");
            }
            db.TblMusteriler.Add(a1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var a = db.TblMusteriler.Find(id);
            db.TblMusteriler.Remove(a);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Getir(int id)
        {
            var deger = db.TblMusteriler.Find(id);
            return View("Getir", deger);
        }

        public ActionResult Guncelle(TblMusteriler a1)
        {
            var mstr = db.TblMusteriler.Find(a1.MusteriId);
            mstr.MusteriId = a1.MusteriId;
            mstr.MusteriAd = a1.MusteriAd;
            mstr.MusteriSoyad = a1.MusteriSoyad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}