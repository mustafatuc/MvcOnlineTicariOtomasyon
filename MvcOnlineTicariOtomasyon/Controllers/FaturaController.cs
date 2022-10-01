using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class FaturaController : Controller
    {
        // GET: Fatura
        Context c=new Context();
        public ActionResult Index()
        {
            var liste = c.Faturalars.ToList();
            return View(liste);
        }

        [HttpGet]
        public ActionResult FaturaEkle()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult FaturaEkle(Faturalar f)
        {
            c.Faturalars.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult FaturaGetir(int id)
        {
            //List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
            //                               select new SelectListItem
            //                               {
            //                                   Text = x.KategoriAd,
            //                                   Value = x.KategoriID.ToString()
            //                               }).ToList();

            //ViewBag.dgr1 = deger1;


            var fatura = c.Faturalars.Find(id);
            return View("FaturaGetir", fatura);

        }

        public ActionResult FaturaGuncelle(Faturalar f)
        {
            var fatura = c.Faturalars.Find(f.Faturaid);
            fatura.FaturaSerino = f.FaturaSerino;
            fatura.FaturaSirano = f.FaturaSirano;
            fatura.VergiDairesi = f.VergiDairesi;
            fatura.Tarih = f.Tarih;
            fatura.Saat = f.Saat;
            fatura.TeslimAlan = f.TeslimAlan;
            fatura.TeslimEden = f.TeslimEden;
           // fat.Toplam = f.Toplam;
            
         //   c.Faturalars.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult FaturaDetay(int id)
        {
            var degerler = c.FaturaKalems.Where(x => x.Faturaid == id).ToList();
            
            return View(degerler);
        }
        public ActionResult YeniKalem()
        {
            //List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
            //                               select new SelectListItem
            //                               {
            //                                   Text = x.KategoriAd,
            //                                   Value = x.KategoriID.ToString()
            //                               }).ToList();

            //ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult YeniKalem(FaturaKalem p)
        {
            c.FaturaKalems.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}