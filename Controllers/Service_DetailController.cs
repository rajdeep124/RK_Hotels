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
    public class Service_DetailController : Controller
    {
        private readonly RK_HotelsDatabaseContext _context;

        public Service_DetailController(RK_HotelsDatabaseContext context)
        {
            _context = context;
        }

        // GET: Service_Detail
        public async Task<IActionResult> Index()
        {
            return View(await _context.Service_Detail.ToListAsync());
        }

        // GET: Service_Detail/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service_Detail = await _context.Service_Detail
                .FirstOrDefaultAsync(m => m.Id == id);
            if (service_Detail == null)
            {
                return NotFound();
            }

            return View(service_Detail);
        }

        // GET: Service_Detail/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Service_Detail/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Availablity,Price,Opening_Hours")] Service_Detail service_Detail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(service_Detail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(service_Detail);
        }

        // GET: Service_Detail/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service_Detail = await _context.Service_Detail.FindAsync(id);
            if (service_Detail == null)
            {
                return NotFound();
            }
            return View(service_Detail);
        }

        // POST: Service_Detail/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Availablity,Price,Opening_Hours")] Service_Detail service_Detail)
        {
            if (id != service_Detail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(service_Detail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Service_DetailExists(service_Detail.Id))
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
            return View(service_Detail);
        }

        // GET: Service_Detail/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service_Detail = await _context.Service_Detail
                .FirstOrDefaultAsync(m => m.Id == id);
            if (service_Detail == null)
            {
                return NotFound();
            }

            return View(service_Detail);
        }

        // POST: Service_Detail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var service_Detail = await _context.Service_Detail.FindAsync(id);
            _context.Service_Detail.Remove(service_Detail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Service_DetailExists(int id)
        {
            return _context.Service_Detail.Any(e => e.Id == id);
        }
    }
}
