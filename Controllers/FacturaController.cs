using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderApiApp2.Models;

namespace OrderApiApp2.Controllers
{
    public class FacturaController : Controller
    {
        private readonly ApplicationContext _context;
        public FacturaController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: FacturaController
        public ActionResult Index()
        {
            List<Factura> facturas;
            facturas = _context.Factura.ToList();
            return View(facturas);
        }

        // GET: FacturaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FacturaController/Create
        [HttpGet]
        public IActionResult Create()
        {
            Factura factura = new Factura();

            return View(factura);
        }

        // POST: FacturaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Factura factura)
        {
            _context.Add(factura);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        // GET: FacturaController/Edit/5
        public ActionResult Edit(int id)
        {

            Factura factura = _context.Factura.Find(id);
            return View(factura);
        }

        // POST: FacturaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Factura factura)
        {
            try
            {
                Factura fac = _context.Factura.Find(factura.IdFactura);
                fac.IdFactura = factura.IdFactura;
                fac.ProductName = factura.ProductName;
                fac.Articul=factura.Articul;
                fac.Qantity = factura.Qantity;
                fac.IdClient= factura.IdClient;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {

                return View();
            }
        }

        // GET: FacturaController/Delete/5
        public ActionResult Delete(int id)
        {
            _context.Factura.Remove(_context.Factura.Find(id));
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // POST: FacturaController/Delete/5
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
