using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CheeseMVC.Data;
using CheeseMVC.Models;

namespace CheeseMVC.Controllers
{
    public class CheeseCategoriesController : Controller
    {
        private readonly CheeseDbContext _context;

        public CheeseCategoriesController(CheeseDbContext context)
        {
            _context = context;
        }

        // GET: CheeseCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.Categories.ToListAsync());
        }

        // GET: CheeseCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cheeseCategory = await _context.Categories
                .SingleOrDefaultAsync(m => m.ID == id);
            if (cheeseCategory == null)
            {
                return NotFound();
            }

            return View(cheeseCategory);
        }

        // GET: CheeseCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CheeseCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] CheeseCategory cheeseCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cheeseCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cheeseCategory);
        }

        // GET: CheeseCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cheeseCategory = await _context.Categories.SingleOrDefaultAsync(m => m.ID == id);
            if (cheeseCategory == null)
            {
                return NotFound();
            }
            return View(cheeseCategory);
        }

        // POST: CheeseCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] CheeseCategory cheeseCategory)
        {
            if (id != cheeseCategory.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cheeseCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CheeseCategoryExists(cheeseCategory.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cheeseCategory);
        }

        // GET: CheeseCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cheeseCategory = await _context.Categories
                .SingleOrDefaultAsync(m => m.ID == id);
            if (cheeseCategory == null)
            {
                return NotFound();
            }

            return View(cheeseCategory);
        }

        // POST: CheeseCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cheeseCategory = await _context.Categories.SingleOrDefaultAsync(m => m.ID == id);
            _context.Categories.Remove(cheeseCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CheeseCategoryExists(int id)
        {
            return _context.Categories.Any(e => e.ID == id);
        }
    }
}
