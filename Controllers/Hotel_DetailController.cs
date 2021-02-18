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
    public class Hotel_DetailController : Controller
    {
        private readonly RK_HotelsDatabaseContext _context;

        public Hotel_DetailController(RK_HotelsDatabaseContext context)
        {
            _context = context;
        }

        // GET: Hotel_Detail
        public async Task<IActionResult> Index()
        {
            return View(await _context.Hotel_Detail.ToListAsync());
        }

        // GET: Hotel_Detail/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotel_Detail = await _context.Hotel_Detail
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hotel_Detail == null)
            {
                return NotFound();
            }

            return View(hotel_Detail);
        }

        // GET: Hotel_Detail/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hotel_Detail/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Branch_Name,Email,Phone_Number,Address")] Hotel_Detail hotel_Detail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hotel_Detail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hotel_Detail);
        }

        // GET: Hotel_Detail/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotel_Detail = await _context.Hotel_Detail.FindAsync(id);
            if (hotel_Detail == null)
            {
                return NotFound();
            }
            return View(hotel_Detail);
        }

        // POST: Hotel_Detail/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Branch_Name,Email,Phone_Number,Address")] Hotel_Detail hotel_Detail)
        {
            if (id != hotel_Detail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hotel_Detail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Hotel_DetailExists(hotel_Detail.Id))
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
            return View(hotel_Detail);
        }

        // GET: Hotel_Detail/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotel_Detail = await _context.Hotel_Detail
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hotel_Detail == null)
            {
                return NotFound();
            }

            return View(hotel_Detail);
        }

        // POST: Hotel_Detail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hotel_Detail = await _context.Hotel_Detail.FindAsync(id);
            _context.Hotel_Detail.Remove(hotel_Detail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Hotel_DetailExists(int id)
        {
            return _context.Hotel_Detail.Any(e => e.Id == id);
        }
    }
}
