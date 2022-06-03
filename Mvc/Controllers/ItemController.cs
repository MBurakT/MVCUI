using Microsoft.AspNetCore.Mvc;
using Mvc.Data;

namespace Mvc.Controllers
{
    public class ItemController : Controller
    {
        private readonly EtradeContext _context;

        public ItemController(EtradeContext context)
        {
            _context = context;
        }

        // GET: ItemController
        public ActionResult Index(string? filter)
        {
            if(filter == null)
            {
                return View(_context.Items.ToList().Take(30));
            }
            return View(_context.Items.ToList().Take(5).Where(p=>p.ItemName.Contains(filter)));
        }

        // GET: ItemController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            return View(await _context.Items.FindAsync(id));
        }

        // GET: ItemController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ItemController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: ItemController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ItemController/Edit/5
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

        // GET: ItemController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ItemController/Delete/5
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
