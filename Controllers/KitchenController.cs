using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment2.Models;
using Assignment2.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Assignment2.Controllers
{
    public class KitchenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KitchenController(ApplicationDbContext context)
        {
            _context = context;
        }


        public ActionResult Kitchen(DateTime givenDate)
        {
            //DateTime date = DateTime.Today;
            if (givenDate.Year == 1)
            {
                givenDate = DateTime.Today;
            }



            var viewModel = new AllBookings
            {
                CheckedIn = _context.CheckIns.ToList()
                //.Include(i => i.Adult)
                //.Include(i => i.Children)
                //.OrderBy(i => i.Date)
                ,
                Booked = _context.Bookings.ToList()
                //.Include(i => i.Children)
                //.Include(i => i.Children)
                //.OrderBy(i=> i.Date)
            };

            viewModel.Date = givenDate;


            viewModel.CheckedIn = viewModel.CheckedIn.Where
                (i => i.Date.Day == givenDate.Day).ToList();
            viewModel.CheckedInAdults = 0;
            viewModel.CheckedInKids = 0;
            viewModel.TotalCheckedIn = 0;
            foreach (var guest in viewModel.CheckedIn)
            {
                viewModel.CheckedInAdults += guest.Adults;
                viewModel.CheckedInKids += guest.Kids;
                viewModel.TotalCheckedIn = guest.Kids + guest.Adults;
            }

            //viewModel.CheckedInGuests = viewModel.CheckedInGuests.Where
            //    (i => i.Date == date).ToList().

            viewModel.Booked = viewModel.Booked.Where
                (i => i.Date.Day == givenDate.Day).ToList();
            viewModel.BookedAdults = 0;
            viewModel.BookedKids = 0;
            viewModel.TotalBooked = 0;
            foreach (var guest in viewModel.Booked)
            {
                viewModel.BookedAdults += guest.Adults;
                viewModel.BookedKids += guest.Kids;
                viewModel.TotalBooked = guest.Kids + guest.Adults;
            }



            return View(viewModel);
            //return View();
        }

    }
}