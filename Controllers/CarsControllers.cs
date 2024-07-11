using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class CarsControllers : Controller
    {
        private readonly IAllCars _allCars;
        private readonly ICarsCategory _carsCategory;

        public CarsControllers(IAllCars iAllCars, ICarsCategory iCarsCategory)
        {
            _allCars = iAllCars;
            _carsCategory = iCarsCategory;
        }

        [Route("Cars/List")]
        [Route("Cars/List/{category}")]
        public ViewResult List(string category)
        {

            string _category = category;
            IEnumerable<Car> cars = null;
            string CarCategory = "";
                if(string.IsNullOrEmpty(category)) {
                cars = _allCars.Cars.OrderBy(i => i.id);
            }
            else
            {
                if(string.Equals("electro",category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.Cars.Where(i => i.Category.categoryName.Equals("Электромобили")).OrderBy(i => i.id);
                }
                else if (string.Equals("fuel", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.Cars.Where(i => i.Category.categoryName.Equals("Класические автомобили")).OrderBy(i => i.id);
                }

                CarCategory = _category;

            }

            //ViewBag.Category = "Some New";
            //var cars = _allCars.Cars;

        var carObj = new CarsListViewModel
        {
                getAllCars = cars,
                CarCategory = CarCategory
        };
        ViewBag.Title = "Страница с автомобилями";
            //CarsListViewModel obj = new CarsListViewModel();
            //obj.getAllCars = _allCars.Cars;
            //obj.CarCategory = "Автомобили";


            return View(carObj);
        }
    }
}
