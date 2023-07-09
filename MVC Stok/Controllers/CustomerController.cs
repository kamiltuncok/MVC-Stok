using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Stok.Models.Entity;

namespace MVC_Stok.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index(string p)
        {
            var degerler = from d in db.TBLMUSTERILER select d;
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.MUSTERIAD.Contains(p));
            }
            return View(degerler.ToList());
            //var degerler = db.TBLMUSTERILER.ToList();
            //return View(degerler);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(TBLMUSTERILER customer)
        {
            if (!ModelState.IsValid)
            {
                return View("Add");
            }
            db.TBLMUSTERILER.Add(customer);
            db.SaveChanges();
            return View();
        }

        public ActionResult Delete(int id)
        {
            var musteri = db.TBLMUSTERILER.Find(id);
            db.TBLMUSTERILER.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetCustomerById(int id)
        {
            var customer = db.TBLMUSTERILER.Find(id);
            return View("GetCustomerById", customer);
        }

        public ActionResult Update(TBLMUSTERILER customer)
        {
            var musteri = db.TBLMUSTERILER.Find(customer.MUSTERIID);
            musteri.MUSTERIAD = customer.MUSTERIAD;
            musteri.MUSTERISOYAD = customer.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}