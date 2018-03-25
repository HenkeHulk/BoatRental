using BoatRental.Models.Enum;
using BoatRental.Repository.Repositories;
using BoatRental.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoatRental.Web.Helpers
{
    public class RentalHelper
    {
        BoatRepository boatRepository = new BoatRepository();
        RentalRepository rentalRepository = new RentalRepository();

        public List<BoatViewModel> allBoats()
        {
            var dbBoats = boatRepository.All.ToList();
            var boats = new List<BoatViewModel>();
            foreach (var dbBoat in dbBoats)
            {
                var boat = new BoatViewModel()
                {
                    Id = dbBoat.Id,
                    BoatNumber = dbBoat.BoatNumber,
                    BoatType = dbBoat.BoatType,
                    BoatTypeString = BoatTypeString(dbBoat.BoatType),
                    Booked = dbBoat.Booked
                };
                boats.Add(boat);
            }
            return boats;
        }

        public string BoatTypeString(BoatType boatType)
        {
            if (boatType == BoatType.Dinghy)
                return "Jolle";
            else if (boatType == BoatType.SailBoat)
                return "Liten Segelbåt";
            else
                return "Stor Segelbåt";
        }

        public List<RentalViewModel> allRentals()
        {
            var dbRentals = rentalRepository.All.ToList();
            var rentals = new List<RentalViewModel>();
            foreach (var dbRental in dbRentals)
            {
                var rental = new RentalViewModel()
                {
                    Id = dbRental.Id,
                    BookingNumber = dbRental.BookingNumber,
                    PersonalNumber = dbRental.PersonalNumber,
                    BoatNumber = dbRental.BoatNumber,
                    DeliveryDate = dbRental.DeliveryDate,
                    FilingDate = dbRental.FilingDate,
                    Cost = dbRental.Cost
                };
                rentals.Add(rental);
            }
            return rentals;
        }

        public IndexViewModel indexViewModel()
        {
            var model = new IndexViewModel()
            {
                Rentals = allRentals(),
                Boats = allBoats()
            };
            return model;
        }


    }
}