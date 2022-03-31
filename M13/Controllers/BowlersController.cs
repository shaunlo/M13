using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using M13.Models;

namespace M13.Controllers
{
    public class BowlersController : Controller
    {
        private readonly BowlersDbContext _context;

        public BowlersController(BowlersDbContext context)
        {
            _context = context;
        }

        // GET: Bowlers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bowlers.ToListAsync());
        }

        // GET: Bowlers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bowler = await _context.Bowlers
                .FirstOrDefaultAsync(m => m.BowlerID == id);
            if (bowler == null)
            {
                return NotFound();
            }

            return View(bowler);
        }

        // GET: Bowlers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bowlers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BowlerID,BowlerLastName,BowlerFirstName,BowlerMiddleInit,BowlerAddress,BowlerCity,BowlerState,BowlerZip,BowlerPhoneNumber,TeamID")] Bowler bowler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bowler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bowler);
        }

        // GET: Bowlers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bowler = await _context.Bowlers.FindAsync(id);
            if (bowler == null)
            {
                return NotFound();
            }
            return View(bowler);
        }

        // POST: Bowlers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BowlerID,BowlerLastName,BowlerFirstName,BowlerMiddleInit,BowlerAddress,BowlerCity,BowlerState,BowlerZip,BowlerPhoneNumber,TeamID")] Bowler bowler)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bowler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    //if (!BowlerExists(bowler.BowlerID))
                    //{
                    //    return NotFound();
                    //}
                    //else
                    //{
                    //    throw;
                    //}
                }
                return RedirectToAction(nameof(Index));
            }
            return View(bowler);
        }

        // GET: Bowlers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bowler = await _context.Bowlers
                .FirstOrDefaultAsync(m => m.BowlerID == id);
            if (bowler == null)
            {
                return NotFound();
            }

            return View(bowler);
        }

        [HttpPost]
        public IActionResult Delete(Bowler b) {
            var bowler = _context.Bowlers
                .FirstOrDefault(m => m.BowlerID == b.BowlerID);
            _context.Remove(bowler);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: Bowlers/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var bowler = await _context.Bowlers.FindAsync(id);
        //    _context.Bowlers.Remove(bowler);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool BowlerExists(int id)
        //{
        //    return _context.Bowlers.Any(e => e.BowlerID == id);
        //}
    }
}
