using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RK_Hotels.Models;

namespace RK_Hotels.Data
{
    public class RK_HotelsDatabaseContext : DbContext
    {
        public RK_HotelsDatabaseContext (DbContextOptions<RK_HotelsDatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<RK_Hotels.Models.Hotel_Detail> Hotel_Detail { get; set; }

        public DbSet<RK_Hotels.Models.Room_Detail> Room_Detail { get; set; }

        public DbSet<RK_Hotels.Models.Service_Detail> Service_Detail { get; set; }

        public DbSet<RK_Hotels.Models.Customer_Detail> Customer_Detail { get; set; }
    }
}
