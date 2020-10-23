using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentalKendaraan_122.Models;

namespace RentalKendaraan_122.Controllers
{
    public class CustemersController : Controller
    {
        private readonly Rental_KendaraanContext _context;

        public CustemersController(Rental_KendaraanContext context)
        {
            _context = context;
        }

        // GET: Custemers
        public async Task<IActionResult> Index()
        {
            var rental_KendaraanContext = _context.Custemer.Include(c => c.IdGenderNavigation);
            return View(await rental_KendaraanContext.ToListAsync());
        }

        // GET: Custemers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var custemer = await _context.Custemer
                .Include(c => c.IdGenderNavigation)
                .FirstOrDefaultAsync(m => m.IdCustemer == id);
            if (custemer == null)
            {
                return NotFound();
            }

            return View(custemer);
        }

        // GET: Custemers/Create
        public IActionResult Create()
        {
            ViewData["IdGender"] = new SelectList(_context.Gender, "IdGender", "IdGender");
            return View();
        }

        // POST: Custemers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCustemer,NamaCustemer,Nik,Alamat,NoHp,IdGender")] Custemer custemer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(custemer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdGender"] = new SelectList(_context.Gender, "IdGender", "IdGender", custemer.IdGender);
            return View(custemer);
        }

        // GET: Custemers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var custemer = await _context.Custemer.FindAsync(id);
            if (custemer == null)
            {
                return NotFound();
            }
            ViewData["IdGender"] = new SelectList(_context.Gender, "IdGender", "IdGender", custemer.IdGender);
            return View(custemer);
        }

        // POST: Custemers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCustemer,NamaCustemer,Nik,Alamat,NoHp,IdGender")] Custemer custemer)
        {
            if (id != custemer.IdCustemer)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(custemer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustemerExists(custemer.IdCustemer))
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
            ViewData["IdGender"] = new SelectList(_context.Gender, "IdGender", "IdGender", custemer.IdGender);
            return View(custemer);
        }

        // GET: Custemers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var custemer = await _context.Custemer
                .Include(c => c.IdGenderNavigation)
                .FirstOrDefaultAsync(m => m.IdCustemer == id);
            if (custemer == null)
            {
                return NotFound();
            }

            return View(custemer);
        }

        // POST: Custemers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var custemer = await _context.Custemer.FindAsync(id);
            _context.Custemer.Remove(custemer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustemerExists(int id)
        {
            return _context.Custemer.Any(e => e.IdCustemer == id);
        }
    }
}
