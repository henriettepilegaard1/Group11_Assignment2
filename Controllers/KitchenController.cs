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
        [Authorize("IsAdmin")]
        public IActionResult Kitchen()
        {
            return View();
        }

        
    }
}