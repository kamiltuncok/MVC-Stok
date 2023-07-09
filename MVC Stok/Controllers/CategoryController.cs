using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Stok.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MVC_Stok.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index(int page=1)
        {
            //var degerler = db.TBLKATEGORILER.ToList();
            var degerler = db.TBLKATEGORILER.ToList().ToPagedList(page,4);
            return View(degerler);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(TBLKATEGORILER category)
        {
            if (!ModelState.IsValid)
            {
                return View("Add");
            }
            db.TBLKATEGORILER.Add(category);
            db.SaveChanges();
            return View();
        }


        public ActionResult Delete(int id)
        {
            var category = db.TBLKATEGORILER.Find(id);
            db.TBLKATEGORILER.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetCategoryById(int id)
        {
            var ktgr = db.TBLKATEGORILER.Find(id);
            return View("GetCategoryById", ktgr);
        }

        
        public ActionResult Update(TBLKATEGORILER category)
        {
            var ktgr = db.TBLKATEGORILER.Find(category.KATEGORIID);
            ktgr.KATEGORIAD = category.KATEGORIAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}