using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DemoApp.Models;

namespace DemoApp.Controllers
{
    [Authorize]
    public class PlaceOrderController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PlaceOrder
        [AllowAnonymous]
        public ActionResult Index(int? OrderId)
        {
            if (OrderId != null)
            {
                return View("Details", db.Orders.SingleOrDefault(m => m.OrderId == OrderId));
            }

            return View("Create");
        }

        // GET: PlaceOrder/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }

            return View(order);
        }

        // GET: PlaceOrder/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlaceOrder/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Item1,Item2")]PlaceOrderViewModel collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Details", new {id = 1});
            }
            catch
            {
                return View();
            }
        }
    }
}
