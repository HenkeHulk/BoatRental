using BoatRental.Web.Helpers;
using BoatRental.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoatRental.Web.Controllers
{
    public class BoatController : Controller
    {
        RentalHelper rentalHelper = new RentalHelper();

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(BoatViewModel boat)
        {
            int id = rentalHelper.InsertBoat(boat);
            return RedirectToAction("", "");
        }

        [HttpGet]
        public ActionResult Edit(int boatNumber)
        {
            var model = rentalHelper.allBoats().Where(x => x.BoatNumber == boatNumber).FirstOrDefault();
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(BoatViewModel boat)
        {
            rentalHelper.UpdateBoat(boat);
            return RedirectToAction("", "");
        }
    }
}