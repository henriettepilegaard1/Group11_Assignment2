using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Assignment2.Controllers
{
    public class KitchenController : Controller
    {
        public IActionResult Kitchen()
        {
            return View();
        }

        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var music = await _context.Musics
        //        .FirstOrDefaultAsync(m => m.MusicId == id);
        //    if (music == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(music);
        //}


    }
}