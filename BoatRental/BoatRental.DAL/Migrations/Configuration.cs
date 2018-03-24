namespace BoatRental.DAL.Migrations
{
    using BoatRental.DAL.Enum;
    using BoatRental.DAL.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BoatRentalDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BoatRentalDbContext context)
        {
            List<Boat> Boats = new List<Boat>();
            Boats.Add(new Boat()
            {
                Id = 1,
                BoatNumber = 101,
                BoatType = BoatType.Dinghy,
                Booked = false
            });
            Boats.Add(new Boat()
            {
                Id = 2,
                BoatNumber = 102,
                BoatType = BoatType.SailBoat,
                Booked = false
            });
            Boats.Add(new Boat()
            {
                Id = 3,
                BoatNumber = 103,
                BoatType = BoatType.Yacht,
                Booked = false
            });
            foreach (var boat in Boats)
                context.Boats.Add(boat);
        }
    }
}
