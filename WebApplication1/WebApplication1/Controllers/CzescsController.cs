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
    public class CzescsController : Controller
    {
        private readonly bazaContext _context;

        public CzescsController(bazaContext context)
        {
            _context = context;
        }

        // GET: Czescs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Czesc.ToListAsync());
        }

        // GET: Czescs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var czesc = await _context.Czesc
                .FirstOrDefaultAsync(m => m.Id == id);
            if (czesc == null)
            {
                return NotFound();
            }

            return View(czesc);
        }

        // GET: Czescs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Czescs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nazwa,Rodzaj,Producent,Cena")] Czesc czesc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(czesc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(czesc);
        }

        // GET: Czescs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var czesc = await _context.Czesc.FindAsync(id);
            if (czesc == null)
            {
                return NotFound();
            }
            return View(czesc);
        }

        // POST: Czescs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nazwa,Rodzaj,Producent,Cena")] Czesc czesc)
        {
            if (id != czesc.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(czesc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CzescExists(czesc.Id))
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
            return View(czesc);
        }

        // GET: Czescs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var czesc = await _context.Czesc
                .FirstOrDefaultAsync(m => m.Id == id);
            if (czesc == null)
            {
                return NotFound();
            }

            return View(czesc);
        }

        // POST: Czescs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var czesc = await _context.Czesc.FindAsync(id);
            _context.Czesc.Remove(czesc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CzescExists(int id)
        {
            return _context.Czesc.Any(e => e.Id == id);
        }
    }
}
