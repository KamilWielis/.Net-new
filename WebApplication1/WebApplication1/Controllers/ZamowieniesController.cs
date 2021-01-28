using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ZamowieniesController : Controller
    {
        private readonly bazaContext _context;

        public ZamowieniesController(bazaContext context)
        {
            _context = context;
        }

        // GET: Zamowienies
        public async Task<IActionResult> Index()
        {
            var bazaContext = _context.Zamowienie.Include(z => z.Czesc).Include(z => z.Klient);
            return View(await bazaContext.ToListAsync());
        }

        // GET: Zamowienies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zamowienie = await _context.Zamowienie
                .Include(z => z.Czesc)
                .Include(z => z.Klient)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zamowienie == null)
            {
                return NotFound();
            }

            return View(zamowienie);
        }

        // GET: Zamowienies/Create
        public IActionResult Create()
        {
            ViewData["CzescId"] = new SelectList(_context.Czesc, "Id", "Id");
            ViewData["KlientId"] = new SelectList(_context.Klient, "Id", "Id");
            return View();
        }

        // POST: Zamowienies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CzescId,KlientId,Data")] Zamowienie zamowienie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zamowienie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CzescId"] = new SelectList(_context.Czesc, "Id", "Id", zamowienie.CzescId);
            ViewData["KlientId"] = new SelectList(_context.Klient, "Id", "Id", zamowienie.KlientId);
            return View(zamowienie);
        }

        // GET: Zamowienies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zamowienie = await _context.Zamowienie.FindAsync(id);
            if (zamowienie == null)
            {
                return NotFound();
            }
            ViewData["CzescId"] = new SelectList(_context.Czesc, "Id", "Id", zamowienie.CzescId);
            ViewData["KlientId"] = new SelectList(_context.Klient, "Id", "Id", zamowienie.KlientId);
            return View(zamowienie);
        }

        // POST: Zamowienies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CzescId,KlientId,Data")] Zamowienie zamowienie)
        {
            if (id != zamowienie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zamowienie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZamowienieExists(zamowienie.Id))
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
            ViewData["CzescId"] = new SelectList(_context.Czesc, "Id", "Id", zamowienie.CzescId);
            ViewData["KlientId"] = new SelectList(_context.Klient, "Id", "Id", zamowienie.KlientId);
            return View(zamowienie);
        }

        // GET: Zamowienies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zamowienie = await _context.Zamowienie
                .Include(z => z.Czesc)
                .Include(z => z.Klient)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zamowienie == null)
            {
                return NotFound();
            }

            return View(zamowienie);
        }

        // POST: Zamowienies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zamowienie = await _context.Zamowienie.FindAsync(id);
            _context.Zamowienie.Remove(zamowienie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZamowienieExists(int id)
        {
            return _context.Zamowienie.Any(e => e.Id == id);
        }
    }
}
