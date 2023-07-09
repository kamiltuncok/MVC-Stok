using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Stok.Models.Entity;

namespace MVC_Stok.Controllers
{
    public class SaleController : Controller
    {
        // GET: Sale
        public ActionResult Index()
        {
            return View();
        }

        MvcDbStokEntities db = new MvcDbStokEntities();

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(TBLSATISLAR sale)
        {
            db.TBLSATISLAR.Add(sale);
            db.SaveChanges();
            return View("Index");
        }
    }
}