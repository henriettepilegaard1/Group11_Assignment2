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
    [Authorize("IsResturantStaff")]
    public class RestaurantController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RestaurantController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(Message? msg)
        {
            return View(msg);}

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
    }
}