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
    public class Booking_DetailController : Controller
    {
        private readonly RK_HotelsDatabaseContext _context;

        public Booking_DetailController(RK_HotelsDatabaseContext context)
        {
            _context = context;
        }

        // GET: Booking_Detail
        public async Task<IActionResult> Index()
        {
            var rK_HotelsDatabaseContext = _context.Booking_Detail.Include(b => b.Customer_Detail).Include(b => b.Hotel_Detail).Include(b => b.Room_Detail).Include(b => b.Service_Detail);
            return View(await rK_HotelsDatabaseContext.ToListAsync());
        }

        // GET: Booking_Detail/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking_Detail = await _context.Booking_Detail
                .Include(b => b.Customer_Detail)
                .Include(b => b.Hotel_Detail)
                .Include(b => b.Room_Detail)
                .Include(b => b.Service_Detail)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (booking_Detail == null)
            {
                return NotFound();
            }

            return View(booking_Detail);
        }

        // GET: Booking_Detail/Create
        public IActionResult Create()
        {
            ViewData["Customer_DetailId"] = new SelectList(_context.Customer_Detail, "Id", "Customer_Name");
            ViewData["Hotel_DetailId"] = new SelectList(_context.Hotel_Detail, "Id", "Branch_Name");
            ViewData["Room_DetailId"] = new SelectList(_context.Room_Detail, "Id", "Room_Type");
            ViewData["Service_DetailId"] = new SelectList(_context.Service_Detail, "Id", "Name");
            return View();
        }

        // POST: Booking_Detail/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Customer_DetailId,Hotel_DetailId,Room_DetailId,Service_DetailId")] Booking_Detail booking_Detail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(booking_Detail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Customer_DetailId"] = new SelectList(_context.Customer_Detail, "Id", "Customer_Name", booking_Detail.Customer_DetailId);
            ViewData["Hotel_DetailId"] = new SelectList(_context.Hotel_Detail, "Id", "Branch_Name", booking_Detail.Hotel_DetailId);
            ViewData["Room_DetailId"] = new SelectList(_context.Room_Detail, "Id", "Room_Type", booking_Detail.Room_DetailId);
            ViewData["Service_DetailId"] = new SelectList(_context.Service_Detail, "Id", "Name", booking_Detail.Service_DetailId);
            return View(booking_Detail);
        }

        // GET: Booking_Detail/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking_Detail = await _context.Booking_Detail.FindAsync(id);
            if (booking_Detail == null)
            {
                return NotFound();
            }
            ViewData["Customer_DetailId"] = new SelectList(_context.Customer_Detail, "Id", "Customer_Name", booking_Detail.Customer_DetailId);
            ViewData["Hotel_DetailId"] = new SelectList(_context.Hotel_Detail, "Id", "Branch_Name", booking_Detail.Hotel_DetailId);
            ViewData["Room_DetailId"] = new SelectList(_context.Room_Detail, "Id", "Room_Type", booking_Detail.Room_DetailId);
            ViewData["Service_DetailId"] = new SelectList(_context.Service_Detail, "Id", "Name", booking_Detail.Service_DetailId);
            return View(booking_Detail);
        }

        // POST: Booking_Detail/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Customer_DetailId,Hotel_DetailId,Room_DetailId,Service_DetailId")] Booking_Detail booking_Detail)
        {
            if (id != booking_Detail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(booking_Detail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Booking_DetailExists(booking_Detail.Id))
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
            ViewData["Customer_DetailId"] = new SelectList(_context.Customer_Detail, "Id", "Customer_Name", booking_Detail.Customer_DetailId);
            ViewData["Hotel_DetailId"] = new SelectList(_context.Hotel_Detail, "Id", "Branch_Name", booking_Detail.Hotel_DetailId);
            ViewData["Room_DetailId"] = new SelectList(_context.Room_Detail, "Id", "Room_Type", booking_Detail.Room_DetailId);
            ViewData["Service_DetailId"] = new SelectList(_context.Service_Detail, "Id", "Name", booking_Detail.Service_DetailId);
            return View(booking_Detail);
        }

        // GET: Booking_Detail/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking_Detail = await _context.Booking_Detail
                .Include(b => b.Customer_Detail)
                .Include(b => b.Hotel_Detail)
                .Include(b => b.Room_Detail)
                .Include(b => b.Service_Detail)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (booking_Detail == null)
            {
                return NotFound();
            }

            return View(booking_Detail);
        }

        // POST: Booking_Detail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var booking_Detail = await _context.Booking_Detail.FindAsync(id);
            _context.Booking_Detail.Remove(booking_Detail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Booking_DetailExists(int id)
        {
            return _context.Booking_Detail.Any(e => e.Id == id);
        }
    }
}
