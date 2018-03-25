using BoatRental.Web.Helpers;
using BoatRental.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoatRental.Web.Controllers
{
    public class RentalController : Controller
    {
        RentalHelper rentalHelper = new RentalHelper();

        [HttpGet]
        public ActionResult Create()
        {
            var model = new RentalViewModel()
            {
                selectBoat = rentalHelper.selectBoat(),
                DeliveryDate = DateTime.Now
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(RentalViewModel rental)
        {
            int id = rentalHelper.InsertRental(rental);
            return RedirectToAction("","");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = rentalHelper.FindByBookingById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(RentalViewModel rental)
        {
            rentalHelper.UpdateRental(rental);
            return RedirectToAction("", "");
        }

        public ActionResult Receipt(int bookingId)
        {
            var model = rentalHelper.FindByBookingId(bookingId);
            return View(model);
        }

        public ActionResult ReturnBoat(int bookingNumber)
        {
            rentalHelper.ReturnBoat(bookingNumber);
            return RedirectToAction("Receipt", "Rental", new { bookingId = bookingNumber });
        }
    }
}