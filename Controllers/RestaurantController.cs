using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment2.Data;
using Assignment2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assignment2.Controllers
{
    //[Authorize("IsResturantStaff")]
    public class RestaurantController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RestaurantController(ApplicationDbContext context)
        {
            _context = context;
        }



        public async Task<IActionResult> Restaurant()
        {
            var Bookings = await _context.Bookings.Where(x => x.Date.Day == DateTime.Today.Day).ToListAsync();

            return View(Bookings);
        }

        public async Task<IActionResult> Index()
        {
            var Bookings = await _context.Bookings.Where(x => x.Date.Day == DateTime.Today.Day).ToListAsync();

            return View(Bookings);
        }

        public async Task<IActionResult> Submit([Bind("roomno,NoAdults,noKids")] CheckIns checkIns)
        {
            if (ModelState.IsValid)
            {
                _context.Add(checkIns);
                await _context.SaveChangesAsync();
                var msg1 = new Message
                {
                    msg = "Success"
                };
                return RedirectToAction(nameof(Index), routeValues: msg1);
            }
            var msg2 = new Message
            {
                msg = "Error"
            };
            return RedirectToAction(nameof(Index), routeValues: msg2);
        }

        // POST: CheckIns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Date,RoomNumber,Adults,Kids")] CheckIns checkIns)
        {
            if (ModelState.IsValid)
            {
                _context.Add(checkIns);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(checkIns);
        }
    }
}