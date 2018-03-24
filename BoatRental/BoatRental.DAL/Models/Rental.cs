using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatRental.DAL.Models
{
    public class Rental
    {
        public int Id { get; set; }

        public int BookingNumber { get; set; }

        public int BoatNumber { get; set; }

        public string PersonalNumber { get; set; }

        public DateTime DeliveryDate { get; set; }

        public DateTime FilingDate { get; set; }

        public Decimal Cost { get; set; }
    }
}
