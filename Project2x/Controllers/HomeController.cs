using DataLayer;
using DataObjects;
using Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project2x.Controllers
{
    public class HomeController : Controller
    {
        Middlelayer AccessPoint = new Middlelayer();
        public ActionResult Products()
        { 
            IEnumerable<Product> products = AccessPoint.GetAllActiveProducts();
            return View(products);
        }

        public ActionResult ShowProduct()
        {
            Product p = AccessPoint.GetActiveProductByCode("PS-202");

            return View(p);
        }

        public ActionResult AddProductQuantity()
        {
            Int32 res = AccessPoint.AddProductQuantity(11, 5);
            return View("Index");
        }

        public ActionResult Index()
        {
            IEnumerable<Product> products = AccessPoint.GetAllActiveProducts();
            return View(products);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}