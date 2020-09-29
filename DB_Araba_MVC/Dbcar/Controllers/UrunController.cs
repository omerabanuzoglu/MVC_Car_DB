using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dbcar.Models.Entity;
using PagedList;

namespace Dbcar.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        DbcarEntities db = new DbcarEntities();
        public ActionResult Index(int sayfa = 1)
        {
            var degerler = db.TblUrun.ToList().ToPagedList(sayfa, 6);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKayit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKayit(TblUrun a1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniKayit");
            }
            db.TblUrun.Add(a1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var b = db.TblUrun.Find(id);
            db.TblUrun.Remove(b);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Getir(int id)
        {
            var deger = db.TblUrun.Find(id);
            return View("Getir", deger);
        }
        public ActionResult Guncelle(TblUrun a1)
        {
            var deger = db.TblUrun.Find(a1.UrunId);
            deger.UrunId = a1.UrunId;
            deger.UrunAd = a1.UrunAd;
            deger.UrunKategori = a1.UrunKategori;
            deger.Fiyat = a1.Fiyat;
            deger.Stok = a1.Stok;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}