using BoatRental.Models;
using BoatRental.Models.Enum;
using BoatRental.Repository.Repositories;
using BoatRental.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoatRental.Web.Helpers
{
    public class RentalHelper
    {
        BoatRepository boatRepository = new BoatRepository();
        RentalRepository rentalRepository = new RentalRepository();

        public void ReturnBoat(int bookingNumber)
        {
            var booking = FindByBookingId(bookingNumber);
            var boat = FindBoatByNumber(booking.BoatNumber);
            boat.Booked = false;
            UpdateBoat(boat);
            TimeSpan timeSpan = DateTime.Now - booking.DeliveryDate;
            booking.Cost = rentalRepository.RentalCost(timeSpan, 500, 100, boat.BoatType);
            UpdateRental(booking);
        }

        public BoatViewModel FindBoatByNumber(int boatNumber)
        {
            var dbBoat = boatRepository.All.Where(x => x.BoatNumber == boatNumber).FirstOrDefault();
            var boat = new BoatViewModel()
            {
                Id = dbBoat.Id,
                BoatNumber = dbBoat.BoatNumber,
                BoatType = dbBoat.BoatType,
                Booked = dbBoat.Booked,
                BoatTypeString = BoatTypeString(dbBoat.BoatType),
            };
            return boat;
        }

        public RentalViewModel FindByBookingById(int id)
        {
            var dbBooking = rentalRepository.Find(id);
            var booking = new RentalViewModel()
            {
                Id = dbBooking.Id,
                BoatNumber = dbBooking.BoatNumber,
                BookingNumber = dbBooking.BookingNumber,
                DeliveryDate = dbBooking.DeliveryDate,
                PersonalNumber = dbBooking.PersonalNumber,
                Cost = dbBooking.Cost,
                selectBoat = selectBoat()
            };
            return booking;
        }

        public RentalViewModel FindByBookingId(int bookingNumber)
        {
            var dbBooking = rentalRepository.All.Where(x => x.BookingNumber == bookingNumber).FirstOrDefault();
            var booking = new RentalViewModel()
            {
                Id = dbBooking.Id,
                BoatNumber = dbBooking.BoatNumber,
                BookingNumber = dbBooking.BookingNumber,
                DeliveryDate = dbBooking.DeliveryDate,
                PersonalNumber = dbBooking.PersonalNumber,
                Cost = dbBooking.Cost,
                selectBoat = selectBoat()
            };
            return booking;
        }

        public int InsertRental(RentalViewModel rental)
        {
            var dbRental = new Rental()
            {
                BookingNumber = NextBookingNumber(),
                BoatNumber = rental.BoatNumber,
                PersonalNumber = rental.PersonalNumber,
                DeliveryDate = rental.DeliveryDate,
                Cost = rental.Cost
            };
            var boat = boatRepository.All.Where(x => x.BoatNumber == rental.BoatNumber).FirstOrDefault();
            boat.Booked = true;
            boatRepository.Update(boat);
            return rentalRepository.Insert(dbRental);
        } 

        public void UpdateRental(RentalViewModel rental)
        {
            var dbRental = new Rental()
            {
                Id = rental.Id,
                BookingNumber = rental.BookingNumber,
                BoatNumber = rental.BoatNumber,
                PersonalNumber = rental.PersonalNumber,
                DeliveryDate = rental.DeliveryDate,
                Cost = rental.Cost
            };
            rentalRepository.Update(dbRental);
        }

        public int InsertBoat(BoatViewModel boat)
        {
            var dbBoat = new Boat()
            {
                BoatNumber = boat.BoatNumber,
                BoatType = boat.BoatType,
                Booked = boat.Booked
            };
            return boatRepository.Insert(dbBoat);
        }

        public void UpdateBoat(BoatViewModel boat)
        {
            var dbBoat = new Boat()
            {
                Id = boat.Id,
                BoatNumber = boat.BoatNumber,
                BoatType = boat.BoatType,
                Booked = boat.Booked
            };
            boatRepository.Update(dbBoat);
        }

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

        public int NextBookingNumber()
        {
            var dbRentals = allRentals();
            if (dbRentals != null && dbRentals.Count() != 0)
            {
                int nextBooking = rentalRepository.All.Max(x => x.BookingNumber);
                if (nextBooking == 0)
                    return nextBooking = 1001;
                else
                    return nextBooking += 1;
            }
            else
                return 1001;
        }

        public List<SelectListItem> selectBoat()
        {
            var dbBoats = boatRepository.All.Where(x => x.Booked == false).ToList();
            var boatList = new List<SelectListItem>();
            foreach (var boat in dbBoats)
            {
                var selectBoat = new SelectListItem()
                {
                    Value = boat.BoatNumber.ToString(),
                    Text = BoatTypeString(boat.BoatType)
                };
                boatList.Add(selectBoat);
            }
            return boatList;
        }
    }
}