using BoatRental.DAL.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatRental.DAL.Models
{
    public class Boat
    {
        public int Id { get; set; }

        public int BoatNumber { get; set; }

        public BoatType BoatType { get; set; }

        public bool Booked { get; set; }
    }
}
