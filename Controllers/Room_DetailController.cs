using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RK_Hotels.Data;
using RK_Hotels.Models;

namespace RK_Hotels.Controllers
{
    public class Room_DetailController : Controller
    {
        private readonly RK_HotelsDatabaseContext _context;

        public Room_DetailController(RK_HotelsDatabaseContext context)
        {
            _context = context;
        }

        // GET: Room_Detail
        public async Task<IActionResult> Index()
        {
            return View(await _context.Room_Detail.ToListAsync());
        }

        // GET: Room_Detail/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room_Detail = await _context.Room_Detail
                .FirstOrDefaultAsync(m => m.Id == id);
            if (room_Detail == null)
            {
                return NotFound();
            }

            return View(room_Detail);
        }

        // GET: Room_Detail/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Room_Detail/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Room_Type,Room_Description,Price_Per_Night")] Room_Detail room_Detail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(room_Detail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(room_Detail);
        }

        // GET: Room_Detail/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room_Detail = await _context.Room_Detail.FindAsync(id);
            if (room_Detail == null)
            {
                return NotFound();
            }
            return View(room_Detail);
        }

        // POST: Room_Detail/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Room_Type,Room_Description,Price_Per_Night")] Room_Detail room_Detail)
        {
            if (id != room_Detail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(room_Detail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Room_DetailExists(room_Detail.Id))
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
            return View(room_Detail);
        }

        // GET: Room_Detail/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room_Detail = await _context.Room_Detail
                .FirstOrDefaultAsync(m => m.Id == id);
            if (room_Detail == null)
            {
                return NotFound();
            }

            return View(room_Detail);
        }

        // POST: Room_Detail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var room_Detail = await _context.Room_Detail.FindAsync(id);
            _context.Room_Detail.Remove(room_Detail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Room_DetailExists(int id)
        {
            return _context.Room_Detail.Any(e => e.Id == id);
        }
    }
}
