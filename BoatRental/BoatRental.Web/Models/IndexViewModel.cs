using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoatRental.Web.Models
{
    public class IndexViewModel
    {
        public List<RentalViewModel> Rentals { get; set; }

        public List<BoatViewModel> Boats { get; set; }
    }
}