using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment2.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assignment2.Controllers
{
    public class RestaurantController : Controller
    {
        //private readonly ApplicationDbContext _context;

        public IActionResult Restaurant()
        {
            return View();
        }
    }
}