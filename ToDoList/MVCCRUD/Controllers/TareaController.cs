﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCCRUD.Models;

namespace MVCCRUD.Controllers
{
    public class TareaController : Controller
    {
        private readonly MVCCRUDContext _context;

        public TareaController(MVCCRUDContext context)
        {
            _context = context;
        }

        // GET: Tarea
        public async Task<IActionResult> Index()
        {
              return _context.Tarea != null ? 
                          View(await _context.Tarea.ToListAsync()) :
                          Problem("Entity set 'MVCCRUDContext.Tarea'  is null.");
        }

        // GET: Tarea/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tarea == null)
            {
                return NotFound();
            }

            var tarea = await _context.Tarea
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tarea == null)
            {
                return NotFound();
            }

            return View(tarea);
        }

        // GET: Tarea/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tarea/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Fecha,Clave")] Tarea tarea)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tarea);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tarea);
        }

        // GET: Tarea/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tarea == null)
            {
                return NotFound();
            }

            var tarea = await _context.Tarea.FindAsync(id);
            if (tarea == null)
            {
                return NotFound();
            }
            return View(tarea);
        }

        // POST: Tarea/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Fecha,Clave")] Tarea tarea)
        {
            if (id != tarea.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tarea);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tareaExists(tarea.Id))
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
            return View(tarea);
        }

        // GET: Tarea/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tarea == null)
            {
                return NotFound();
            }

            var tarea = await _context.Tarea
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tarea == null)
            {
                return NotFound();
            }

            return View(tarea);
        }

        // POST: Tarea/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tarea == null)
            {
                return Problem("Entity set 'MVCCRUDContext.Tarea'  is null.");
            }
            var tarea = await _context.Tarea.FindAsync(id);
            if (tarea != null)
            {
                _context.Tarea.Remove(tarea);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tareaExists(int id)
        {
          return (_context.Tarea?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
