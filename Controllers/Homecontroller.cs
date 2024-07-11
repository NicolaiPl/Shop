using Shop.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.ViewModels;

namespace Shop.Controllers
{
    public class Homecontroller  : Controller
    {
        private readonly IAllCars _carRep;

        public Homecontroller(IAllCars carRep)
        {
            _carRep = carRep;
        }
        public ViewResult Index()
        {
            var homeCars = new HomeViewModels()
            {
                favCars = _carRep.Cars
            };
            return View(homeCars);
        }
    }
}
