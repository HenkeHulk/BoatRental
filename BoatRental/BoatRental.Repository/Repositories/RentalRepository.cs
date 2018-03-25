using BoatRental.DAL;
using BoatRental.Models;
using BoatRental.Models.Enum;
using BoatRental.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatRental.Repository.Repositories
{
    public class RentalRepository : IRentalRepository
    {
        BoatRentalDbContext db = new BoatRentalDbContext();
        public IQueryable<Rental> All => db.Rentals;

        public void Delete(int id)
        {
            var delRental = Find(id);
            db.Rentals.Remove(delRental);
            Save();
            Dispose();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public Rental Find(int id)
        {
            return db.Rentals.Find(id);
        }

        public int Insert(Rental entity)
        {
            var existRental = Find(entity.Id);
            if (existRental == null)
                db.Rentals.Add(entity);
            else
            {
                existRental.Id = entity.Id;
                existRental.BoatNumber = entity.BoatNumber;
                existRental.BookingNumber = entity.BookingNumber;
                existRental.DeliveryDate = entity.DeliveryDate;
                existRental.Cost = entity.Cost;
                existRental.PersonalNumber = entity.PersonalNumber;
            }
            Save();
            return entity.Id;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public Decimal RentalCost(TimeSpan rentTime, double baseCost, double hourCost, BoatType boatType)
        {
            Decimal rentCost;
            int hours = rentTime.Hours;
            if (rentTime.Days != 0)
                hours += 24 * rentTime.Days;
            if (rentTime.Minutes > 0)
                hours += 1;
            if (boatType == BoatType.Dinghy)
                rentCost = Convert.ToDecimal(baseCost + (hourCost * hours));
            else if (boatType == BoatType.SailBoat)
                rentCost = Convert.ToDecimal((baseCost * 1.2) + ((hourCost * 1.3) * hours));
            else
                rentCost = Convert.ToDecimal((baseCost * 1.5) + ((hourCost * 1.4) * hours));
            return rentCost;
        }

        public void Update(Rental entity)
        {
            var existRental = Find(entity.Id);
            if (existRental == null)
                db.Rentals.Add(entity);
            else
            {
                existRental.Id = entity.Id;
                existRental.BoatNumber = entity.BoatNumber;
                existRental.BookingNumber = entity.BookingNumber;
                existRental.DeliveryDate = entity.DeliveryDate;
                existRental.Cost = entity.Cost;
                existRental.PersonalNumber = entity.PersonalNumber;
            }
            Save();
        }
    }
}
