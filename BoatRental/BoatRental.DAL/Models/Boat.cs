using BoatRental.DAL.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoatRental.DAL.Models
{
    public class Boat
    {
        public int Id { get; set; }

        public int BoatNumber { get; set; }

        public BoatType BoatType { get; set; }
    }
}
