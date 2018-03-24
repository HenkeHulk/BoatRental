using BoatRental.DAL;
using BoatRental.Models;
using BoatRental.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatRental.Repository.Repositories
{
    public class BoatRepository : IBoatRepository
    {
        BoatRentalDbContext db = new BoatRentalDbContext();
        public IQueryable<Boat> All => db.Boats;

        public void Delete(int id)
        {
            var delBoat = Find(id);
            db.Boats.Remove(delBoat);
            Save();
            Dispose();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public Boat Find(int id)
        {
            return db.Boats.Find(id);
        }

        public int Insert(Boat entity)
        {
            var existBoat = Find(entity.Id);
            if (existBoat == null)
                db.Boats.Add(entity);
            else
            {
                existBoat.Id = entity.Id;
                existBoat.BoatNumber = entity.BoatNumber;
                existBoat.BoatType = entity.BoatType;
                existBoat.Booked = entity.Booked;
            }
            Save();
            return entity.Id;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Boat entity)
        {
            var existBoat = Find(entity.Id);
            if (existBoat == null)
                db.Boats.Add(entity);
            else
            {
                existBoat.Id = entity.Id;
                existBoat.BoatNumber = entity.BoatNumber;
                existBoat.BoatType = entity.BoatType;
                existBoat.Booked = entity.Booked;
            }
            Save();
        }
    }
}
