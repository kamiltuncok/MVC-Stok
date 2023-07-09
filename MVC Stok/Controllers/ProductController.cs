using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Stok.Models.Entity;

namespace MVC_Stok.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLURUNLER.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult Add()
        {
            List<SelectListItem> degerler = (from i in db.TBLKATEGORILER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }

        [HttpPost]
        public ActionResult Add(TBLURUNLER product)
        {
            var ktg = db.TBLKATEGORILER.Where(m => m.KATEGORIID == product.TBLKATEGORILER.KATEGORIID).FirstOrDefault();
            product.TBLKATEGORILER = ktg;
            db.TBLURUNLER.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var urun = db.TBLURUNLER.Find(id);
            db.TBLURUNLER.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetProductById(int id)
        {
            var product = db.TBLURUNLER.Find(id);
            List<SelectListItem> degerler = (from i in db.TBLKATEGORILER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View("GetProductById", product);
        }

        public ActionResult Update(TBLURUNLER product)
        {
            var urun = db.TBLURUNLER.Find(product.URUNID);
            urun.URUNAD = product.URUNAD;
            urun.MARKA = product.MARKA;
            urun.STOK = product.STOK;
            urun.FIYAT = product.FIYAT;
            var ktg = db.TBLKATEGORILER.Where(m => m.KATEGORIID == product.TBLKATEGORILER.KATEGORIID).FirstOrDefault();
            urun.URUNKATEGORI = ktg.KATEGORIID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}