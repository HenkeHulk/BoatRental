using BoatRental.DAL.Migrations;
using BoatRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatRental.DAL
{
    public class BoatRentalDbContext : DbContext
    {
        public BoatRentalDbContext() 
            : base("name=BoatRental")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BoatRentalDbContext, Configuration>());
        }

        public virtual DbSet<Boat> Boats { get; set; }
        public virtual DbSet<Rental> Rentals { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
