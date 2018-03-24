using BoatRental.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoatRental.DAL
{
    public class BoatRentalDbContext:DbContext
    {
        public BoatRentalDbContext(DbContextOptions<BoatRentalDbContext> dbContextOptions) 
            : base(dbContextOptions)
        {
        }

        public DbSet<Boat> Boats { get; set; }
        public DbSet<Rental> Rentals { get; set; }

    }
}
