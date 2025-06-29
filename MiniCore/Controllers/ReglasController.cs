using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MiniCore.Models;

namespace MiniCore.Controllers
{
    public class ReglasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReglasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Reglas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Reglas.ToListAsync());
        }

        // GET: Reglas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regla = await _context.Reglas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (regla == null)
            {
                return NotFound();
            }

            return View(regla);
        }

        // GET: Reglas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reglas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Minimo,Maximo,Porcentaje")] Regla regla)
        {
            if (ModelState.IsValid)
            {
                _context.Add(regla);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(regla);
        }

        // GET: Reglas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regla = await _context.Reglas.FindAsync(id);
            if (regla == null)
            {
                return NotFound();
            }
            return View(regla);
        }

        // POST: Reglas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Minimo,Maximo,Porcentaje")] Regla regla)
        {
            if (id != regla.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(regla);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReglaExists(regla.Id))
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
            return View(regla);
        }

        // GET: Reglas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regla = await _context.Reglas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (regla == null)
            {
                return NotFound();
            }

            return View(regla);
        }

        // POST: Reglas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var regla = await _context.Reglas.FindAsync(id);
            if (regla != null)
            {
                _context.Reglas.Remove(regla);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReglaExists(int id)
        {
            return _context.Reglas.Any(e => e.Id == id);
        }
    }
}
