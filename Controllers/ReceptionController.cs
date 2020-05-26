using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assignment2.Data;
using Assignment2.Models;

namespace Assignment2.Controllers
{
    [Authorize("IsReceptionStaff")] 
    public class ReceptionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReceptionController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Reception()
        {
            var checkIns = await _context.CheckIns.Where(x => x.Date.Day == DateTime.Today.Day).ToListAsync();

            return View(checkIns);
        }

        public async Task<IActionResult> Index(DateTime date)
        {
            if (date.Year == 1)
            {
                date = DateTime.Today;
            }

            var checkedIn = (await _context.CheckIns.ToListAsync()).Where(x => x.Date.Day == date.Day);
            return View(checkedIn);
        }
    }
}