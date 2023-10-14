using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Doorforyou.Data;
using Doorforyou.Models;

namespace Doorforyou.Controllers
{
    public class DoorsController : Controller
    {
        private readonly DoorforyouContext _context;

        public DoorsController(DoorforyouContext context)
        {
            _context = context;
        }

        // GET: Doors
        public async Task<IActionResult> Index(string DoorType, string searchString)
        {
            IQueryable<string> genreQuery = from m in _context.Door
                                            orderby m.Type
                                            select m.Type;

            var movies = from m in _context.Door
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.MaterialType.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(DoorType))
            {
                movies = movies.Where(x => x.Type == DoorType);
            }

            var movieGenreVM = new DoorTypeViewModel
            {
                Type = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Door = await movies.ToListAsync()
            };

            return View(movieGenreVM);
        }

        // GET: Door/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Door = await _context.Door
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Door == null)
            {
                return NotFound();
            }

            return View(Door);
        }

        // GET: Door/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Door/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MaterialType,Type,Edition,Make,Price")] Door door)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Door);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Door);
        }

        // GET: door/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Door = await _context.Door.FindAsync(id);
            if (Door == null)
            {
                return NotFound();
            }
            return View(door);
        }

        // POST: Door/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MaterialType,Type,Edition,Make,Price")] Door door)
        {
            if (id != Door.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(door);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoorExistsExists(door.Id))
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
            return View(door);
        }

        // GET: Door/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Door = await _context.Door
                .FirstOrDefaultAsync(m => m.Id == id);
            if (door == null)
            {
                return NotFound();
            }

            return View(door);
        }

        // POST: Door/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var door = await _context.Door.FindAsync(id);
            _context.Door.Remove(door);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoorExists(int id)
        {
            return _context.Door.Any(e => e.Id == id);
        }
    }
}
