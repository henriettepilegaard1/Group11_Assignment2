using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment2.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Assignment2.Data
{
    public class DbHelper
    {
        public static void SeedData(ApplicationDbContext db, UserManager<IdentityUser> userManager, ILogger log)
        {
            SeedUsers(userManager, log);
            SeedData(db, log);
        }

        private static void SeedUsers(UserManager<IdentityUser> userManager, ILogger log)
        {

            //Adding Lucas

            const string LucasEmail = "lucas@mail.dk";
            const string LucasPassword = "Password1.";

            log.LogInformation("Seeding Staff entries");

                var sr = new IdentityUser()
                {
                    UserName = LucasEmail,
                    Email = LucasEmail
                };
                IdentityResult result1 = userManager.CreateAsync(sr, LucasPassword).Result;
                if (result1.Succeeded)
                {
                    var lucasClaim = new Claim("Restaurant", "Yes");
                    userManager.AddClaimAsync(sr, lucasClaim).Wait();
                    var lucasClaim2 = new Claim("Reception", "Yes");
                    userManager.AddClaimAsync(sr, lucasClaim2).Wait();
                }
                else
                {
                    log.LogInformation("CreateAsync Failed!");
                }

            //adding Caroline

            const string CaroEmail = "caro@mail.dk";
            const string CaroPassword = "Password2.";

            log.LogInformation("Seeding Staff entries");

            var sr2 = new IdentityUser()
            {
                UserName = CaroEmail,
                Email = CaroEmail
            };
            IdentityResult result2 = userManager.CreateAsync(sr2, CaroPassword).Result;
            if (result2.Succeeded)
            {
                var caroClaim = new Claim("Restaurant", "Yes");
                userManager.AddClaimAsync(sr2, caroClaim).Wait();
            }
            else
            {
                log.LogInformation("CreateAsync Failed!");
            }

            //Adding henritette

            const string HennyEmail = "henny@mail.dk";
            const string HennyPassword = "Password3.";

            log.LogInformation("Seeding Staff entries");

            var sr3 = new IdentityUser()
            {
                UserName = HennyEmail,
                Email = HennyEmail
            };
            IdentityResult result3 = userManager.CreateAsync(sr3, HennyPassword).Result;
            if (result3.Succeeded)
            {
                var hennyClaim = new Claim("Reception", "Yes");
                userManager.AddClaimAsync(sr3, hennyClaim).Wait();
            }
            else
            {
                log.LogInformation("CreateAsync Failed!");
            }
        }

        private static void SeedData(ApplicationDbContext db, ILogger log)
        {
            var b = db.Bookings.FirstOrDefault();
            if (b == null)
            {
                log.LogInformation("Seeding Booking entries");
                var bookings = new List<Bookings>();
                b = new Bookings()
                {
                    ID = 1,
                    Date = new DateTime(2020, 4, 17, 12, 0, 0), //Date: 4-17-2020 (US format) 12:00 o' clock
                    RoomNumber = 206,
                    Adults = 2,
                    Kids = 3

                };
                bookings.Add(b);

                b = new Bookings()
                {
                    ID = 2,
                    Date = new DateTime(2020, 4, 17, 12, 0, 0), //Date: 4-17-2020 (US format) 12:00 o' clock
                    RoomNumber = 102,
                    Adults = 2,
                    Kids = 0
                };
                bookings.Add(b);

                b = new Bookings()
                {
                    ID = 3,
                    Date = new DateTime(2020, 4, 17, 12, 0, 0), //Date: 4-17-2020 (US format) 12:00 o' clock
                    RoomNumber = 201,
                    Adults = 2,
                    Kids = 1
                };
                bookings.Add(b);

                db.Bookings.AddRange(bookings);
                //db.SaveChangesAsync();

                var c = db.CheckIns.FirstOrDefault();
                if (c == null)
                {
                    log.LogInformation("Seeding checkIn entries");
                    var checkIns = new List<CheckIns>();
                    c = new CheckIns()
                    {
                        ID = 1,
                        Date = new DateTime(2020, 4, 17, 12, 0, 0), //Date: 4-17-2020 (US format) 12:00 o' clock
                        RoomNumber = 206,
                        Adults = 1,
                        Kids = 1,
                    };
                    checkIns.Add(c);

                    c = new CheckIns()
                    {
                        ID = 2,
                        Date = new DateTime(2020, 4, 17, 12, 0, 0), //Date: 4-17-2020 (US format) 12:00 o' clock
                        RoomNumber = 102,
                        Adults = 2,
                        Kids = 0
                    };
                    checkIns.Add(c);

                    c = new CheckIns()
                    {
                        ID = 3,
                        Date = new DateTime(2020, 4, 17, 12, 0, 0), //Date: 4-17-2020 (US format) 12:00 o' clock
                        RoomNumber = 201,
                        Adults = 2,
                        Kids = 0
                    };
                    checkIns.Add(c);


                    db.CheckIns.AddRange(checkIns);
                    db.SaveChangesAsync();
                }
            }
        }

    }
}
