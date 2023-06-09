﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderApiApp2.Models;

namespace OrderApiApp2.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationContext _context;
        public OrderController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: OrderController
        public ActionResult Index()
        {
            List<Orders> orders;
            orders = _context.Orders.ToList();
            return View(orders);
        }

        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrderController/Create
        [HttpGet]
        public IActionResult Create()
        {
            Orders orders = new Orders();

            return View(orders);
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Orders orders)
        {
            _context.Add(orders);
            _context.SaveChanges();
            return RedirectToAction("index");
        }


        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {

            Orders orders = _context.Orders.Find(id);
            return View(orders);
        }

        // POST: FacturaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Orders orders)
        {
            try
            {
                Orders or = _context.Orders.Find(orders.IdOrder);
                
                or.Description = orders.Description;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {

                return View();
            }
        }

        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
            _context.Orders.Remove(_context.Orders.Find(id));
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // POST: OrderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
