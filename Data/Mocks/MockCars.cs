using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Mocks
{
    public class CarsRepository : IAllCars
    {
        private readonly ICarsCategory _categoryCars = new MockCategory();

        public IEnumerable<Car> Cars
        {
            get
            {
                return new List<Car>
                {
                    new Car 
                    {
                        Name = "Tesla",
                        ShortDesc = "",
                        LongDesc = "",
                        img = "/img/tesla.jpeg",
                        price = 45000,
                        isFavorite = true,
                        available = true,
                        Category = _categoryCars.AllCategories.First()
                    },
                    new Car
                    {
                        Name = "Volvo",
                        ShortDesc = "",
                        LongDesc = "",
                        img = "/img/tesla.jpeg",
                        price = 55000,
                        isFavorite = true,
                        available = true,
                        Category = _categoryCars.AllCategories.Last()
                    },
                    new Car
                    {
                        Name = "Mazda",
                        ShortDesc = "",
                        LongDesc = "",
                        img = "/img/tesla.jpeg",
                        price = 40000,
                        isFavorite = true,
                        available = true,
                        Category = _categoryCars.AllCategories.Last()
                    },
                    new Car
                    {
                        Name = "Toyta",
                        ShortDesc = "",
                        LongDesc = "",
                        img = "/img/tesla.jpeg",
                        price = 35000,
                        isFavorite = true,
                        available = true,
                        Category = _categoryCars.AllCategories.First()
                    },
                    new Car
                    {
                        Name = "Lada",
                        ShortDesc = "",
                        LongDesc = "",
                        img = "/img/tesla.jpeg",
                        price = 5000,
                        isFavorite = true,
                        available = true,
                        Category = _categoryCars.AllCategories.Last()
                    }
                };
            }
        }

        public IEnumerable<Car> GetFavCars { get; set; }

        public Car GetObjectCar(int carId)
        {
            throw new NotImplementedException();
        }
    }
}
