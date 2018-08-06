using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Marcos.Prestamos.Models;

namespace Marcos.Prestamos.Controllers
{
    public class ComPersonaController : Controller
    {
        private readonly PrestamosContext _context;

        public ComPersonaController(PrestamosContext context)
        {
            _context = context;
        }

        // GET: ComPersona
        public async Task<IActionResult> Index()
        {
            return View(await _context.ComPersona.ToListAsync());
        }

        // GET: ComPersona/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comPersona = await _context.ComPersona
                .SingleOrDefaultAsync(m => m.ID == id);
            if (comPersona == null)
            {
                return NotFound();
            }

            return View(comPersona);
        }

        // GET: ComPersona/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ComPersona/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nombre,APaterno,AMaterno,Curp,FechaNac,FKComCatGenero")] ComPersona comPersona)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comPersona);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(comPersona);
        }

        // GET: ComPersona/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comPersona = await _context.ComPersona.SingleOrDefaultAsync(m => m.ID == id);
            if (comPersona == null)
            {
                return NotFound();
            }
            return View(comPersona);
        }

        // POST: ComPersona/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nombre,APaterno,AMaterno,Curp,FechaNac,FKComCatGenero")] ComPersona comPersona)
        {
            if (id != comPersona.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comPersona);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComPersonaExists(comPersona.ID))
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
            return View(comPersona);
        }

        // GET: ComPersona/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comPersona = await _context.ComPersona
                .SingleOrDefaultAsync(m => m.ID == id);
            if (comPersona == null)
            {
                return NotFound();
            }

            return View(comPersona);
        }

        // POST: ComPersona/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comPersona = await _context.ComPersona.SingleOrDefaultAsync(m => m.ID == id);
            _context.ComPersona.Remove(comPersona);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComPersonaExists(int id)
        {
            return _context.ComPersona.Any(e => e.ID == id);
        }
    }
}
