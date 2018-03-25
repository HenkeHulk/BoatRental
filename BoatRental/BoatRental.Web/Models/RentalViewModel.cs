using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoatRental.Web.Models
{
    public class RentalViewModel
    {
        public int Id { get; set; }

        public int BookingNumber { get; set; }

        [Display(Name = "Båt")]
        public int BoatNumber { get; set; }

        public string PersonalNumber { get; set; }

        public DateTime DeliveryDate { get; set; }

        public List<SelectListItem> selectBoat { get; set; }

        public Decimal Cost { get; set; }
    }
}