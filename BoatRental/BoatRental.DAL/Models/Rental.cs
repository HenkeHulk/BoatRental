using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BoatRental.DAL.Models
{
    public class Rental
    {
        public int Id { get; set; }

        [Display(Name = "Bokningsnummer")]
        public int BookingNumber { get; set; }

        [Display(Name = "Båtnummer")]
        public int BoatNumber { get; set; }

        [Display(Name = "Utlämningsdatum")]
        public DateTime Extradition { get; set; }

        [Display(Name = "Återlämningsdatum")]
        public DateTime ReturnDate { get; set; }
    }
}
