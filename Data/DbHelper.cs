using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace Assignment2.Data
{
    public class DbHelper
    {
        public static void SeedData(ApplicationDbContext db, UserManager<Staff> userManager, ILogger log)
        {
            SeedUsers(userManager, log);
            SeedBookings(db, log);
            SeedCheckIns(db, log);
        }

        private static void SeedUsers(UserManager<Staff> userManager, ILogger log)
        {
            const string adminEmailOne = "Lucas@localhost";
            const string adminPasswordOne = "1234";

            const string adminEmailTwo = "Caroline@localhost";
            const string adminPasswordTwo = "1234";

            const string adminEmailThree = "Henriette@localhost";
            const string adminPasswordThree = "1234";

            if (userManager.FindByNameAsync(adminEmailOne).Result == null)
            {
                log.LogWarning("Seeding admin user");
                var user = new Staff
                {
                    UserName = adminEmailOne,
                    Email = adminEmailOne,
                    Name = "Lucas",
                };
                IdentityResult result = userManager.CreateAsync
                    (user, adminPasswordOne).Result;
                if (result.Succeeded)
                {
                    var adminClaim = new Claim("Reception", "Yes");
                    userManager.AddClaimAsync(user, adminClaim);
                }
            }


            if (userManager.FindByNameAsync(adminEmailTwo).Result == null)
            {
                log.LogWarning("Seeding admin user");
                var user = new Staff
                {
                    UserName = adminEmailTwo,
                    Email = adminEmailTwo,
                    Name = "Caroline",
                };
                IdentityResult result = userManager.CreateAsync
                    (user, adminPasswordTwo).Result;
                if (result.Succeeded)
                {
                    var adminClaim = new Claim("Resturant", "Yes");
                    userManager.AddClaimAsync(user, adminClaim);
                }
            }

            if (userManager.FindByNameAsync(adminEmailThree).Result == null)
            {
                log.LogWarning("Seeding admin user");
                var user = new Staff
                {
                    UserName = adminEmailThree,
                    Email = adminEmailThree,
                    Name = "Henriette",
                };
                IdentityResult result = userManager.CreateAsync
                    (user, adminPasswordThree).Result;
                if (result.Succeeded)
                {
                    var adminClaim = new Claim("Reception", "Yes");
                    userManager.AddClaimAsync(user, adminClaim);
                }
            }
        }

        private static void SeedBookings(ApplicationDbContext db, ILogger log)
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
                db.SaveChangesAsync();
            }
        }


        private static void SeedCheckIns(ApplicationDbContext db, ILogger log)
        {
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
