using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dbcar.Models.Entity;
using PagedList;

namespace Dbcar.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        DbcarEntities db = new DbcarEntities();
        public ActionResult Index(int sayfa = 1)
        {
            var degerler = db.TblSatislar.ToList().ToPagedList(sayfa, 6);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKayit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKayit(TblSatislar a1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniKayit");
            }
            db.TblSatislar.Add(a1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var a = db.TblSatislar.Find(id);
            db.TblSatislar.Remove(a);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Getir(int id)
        {
            var deger = db.TblSatislar.Find(id);
            return View("Getir", deger);
        }

        public ActionResult Guncelle(TblSatislar a1)
        {
            var deger = db.TblSatislar.Find(a1.SatisId);
            deger.SatisId = a1.SatisId;
            deger.Urun = a1.Urun;
            deger.Musteri = a1.Musteri;
            deger.Adet = a1.Adet;
            deger.Fiyat = a1.Fiyat;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}