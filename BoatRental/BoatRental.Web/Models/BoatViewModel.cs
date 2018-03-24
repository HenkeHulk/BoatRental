using BoatRental.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoatRental.Web.Models
{
    public class BoatViewModel
    {
        public int Id { get; set; }

        public int BoatNumber { get; set; }

        public BoatType BoatType { get; set; }

        public bool Booked { get; set; }
    }
}