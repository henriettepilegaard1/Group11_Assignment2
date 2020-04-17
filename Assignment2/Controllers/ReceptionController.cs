using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Assignment2.Controllers
{
    [Authorize("IsAdmin")]
    public class ReceptionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}