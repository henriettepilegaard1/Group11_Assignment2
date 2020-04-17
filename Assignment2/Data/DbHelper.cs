using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

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
            log.LogInformation("Seeding Staff entries");
                var sr = new Staff()
                {
                    Name = "Lucas"

                };
                IdentityResult result1 = userManager.CreateAsync(sr, "hejhejhej").Result;
                if (result1.Succeeded)
                {
                    IdentityResult resultAdd1 = userManager.AddToRoleAsync(sr, StaffRoles.Reception).Result;
                    if(!resultAdd1.Succeeded)
                    {
                        log.LogInformation("AddToRoleAsync Failed!");
                    }
                }
                else
                {
                    log.LogInformation("CreateAsync Failed!");
                }
                
            log.LogInformation("Seeding Staff entries");
                var sr2 = new Staff()
                {
                    Name = "Caroline"

                };
                IdentityResult result2 = userManager.CreateAsync(sr2, "cavseline").Result;
                if (result2.Succeeded)
                {
                    IdentityResult resultAdd2 = userManager.AddToRoleAsync(sr2, StaffRoles.Kitchen).Result;
                    if(!resultAdd2.Succeeded)
                    {
                        log.LogInformation("AddToRoleAsync Failed!");
                    }
                }   
                else
                {
                    log.LogInformation("CreateAsync Failed!");
                } 

                log.LogInformation("Seeding Staff entries");
                var sr3 = new Staff() 
                {
                    Name = "Henriette"
                }; 

                IdentityResult result3 = userManager.CreateAsync(sr3, "hejhejhej").Result; 
                if (result3.Succeeded) 
                { 
                    IdentityResult resultAdd3 = userManager.AddToRoleAsync(sr3, StaffRoles.Restaurant).Result; 
                    if (!resultAdd3.Succeeded)
                    {
                        log.LogInformation("AddToRoleAsync Failed!");
                    }
                }
                else
                {
                log.LogInformation("CreateAsync Failed!");
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
