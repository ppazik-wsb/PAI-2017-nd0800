using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoApp.Models;

namespace DemoApp.Controllers
{
    public class PlaceOrderController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PlaceOrder
        public ActionResult Index(int? OrderId)
        {
            if (OrderId != null)
            {
                return View("Details", db.Orders.SingleOrDefault(m => m.OrderId == OrderId));
            }

            return View("Create");
        }

        // GET: PlaceOrder/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PlaceOrder/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlaceOrder/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
