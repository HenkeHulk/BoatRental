using BoatRental.Web.Helpers;
using BoatRental.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoatRental.Web.Controllers
{
    public class HomeController : Controller
    {
        RentalHelper rentalHelper = new RentalHelper(); 
        public ActionResult Index()
        {
            var model = rentalHelper.indexViewModel();
            return View(model);
        }
    }
}