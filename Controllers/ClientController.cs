using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderApiApp2.Migrations;
using OrderApiApp2.Models;

namespace OrderApiApp2.Controllers
{
    public class ClientController : Controller
    {
        private readonly ApplicationContext _context;
        public ClientController (ApplicationContext context)
        {
            _context = context;
        }    

        // GET: ClientController
        public ActionResult Index()
        {
            List<Client> clients;
            clients=_context.Client.ToList();
            return View(clients);
        }

        // GET: ClientController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClientController/Create
        [HttpGet]
        public IActionResult Create()
        {
            Client client = new Client();  
            
            return View(client);
        }

        // POST: ClientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Client client)
        {
                _context.Add(client);
                _context.SaveChanges();
                 return RedirectToAction("index");
        }

        // GET: ClientController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: ClientController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClientController/Delete/5
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
