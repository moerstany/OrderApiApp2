using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderApiApp2.Models;

namespace OrderApiApp2.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationContext _context;
        public ProductController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: ProductController
        public ActionResult Index()
        {
            List<Product> products;
            products = _context.Product.ToList();
            return View(products);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        [HttpGet]
        public IActionResult Create()
        {
            Product product = new Product();

            return View(product);
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            _context.Add(product);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {

            Product product = _context.Product.Find(id);
            return View(product);
        }

        // POST: FacturaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            try
            {
                Product pr = _context.Product.Find(product.IdProduct);
                pr.IdProduct = product.IdProduct;
                pr.ProductName = product.ProductName;
                pr.Articul=product.Articul;
                pr.Cost=product.Cost;
                pr.ProdPic=product.ProdPic;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {

                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            _context.Product.Remove(_context.Product.Find(id));
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // POST: ProductController/Delete/5
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
