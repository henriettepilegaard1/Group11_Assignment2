using System;
using Assignment2.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Assignment2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Bookings> Bookings { get; set; }

        public DbSet<CheckIns> CheckIns { get; set; }

        public DbSet<Staff> Staffs { get; set; }
    }
}
