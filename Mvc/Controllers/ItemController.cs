using Microsoft.AspNetCore.Mvc;
using Mvc.Data;
using Mvc.Models;

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
        public IActionResult Index(string? filter)
        {
            if (String.IsNullOrEmpty(filter))
            {
                return View(_context.Items.ToList().Take(50));
            }
            return View(_context.Items.Where(p => p.ItemName.Contains(filter)).ToList().Reverse<Item>().Take(10));
        }

        // GET: ItemController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ItemController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id","ItemCode", "ItemName", "UNITPRICE", "Category1", "Category2", "Category3", "Category4", "Brand")] Item item)
        {
            try
            {
                _context.Items.Add(item);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch(Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        // GET: ItemController/Edit/5
        public IActionResult Edit(int id)
        {
            return View(_context.Items.Find(id));
        }

        // POST: ItemController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id", "ItemCode", "ItemName", "UNITPRICE", "Category1", "Category2", "Category3", "Category4", "Brand")] Item item)
        {
            try
            {
                _context.Items.Update(item);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        // GET: ItemController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            return View(await _context.Items.FindAsync(id));
        }

        // GET: ItemController/Delete/5
        public IActionResult Delete(int id)
        {
            return View();
        }

        // POST: ItemController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, [Bind("Id", "ItemCode", "ItemName", "UNITPRICE", "Category1", "Category2", "Category3", "Category4", "Brand")] Item item)
        {
            try
            {
                _context.Items.Remove(item);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}
