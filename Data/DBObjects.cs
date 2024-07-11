using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data
{
    public class DBObjects
    {
        public static void Initial(AppDBContent content)
        {

            if (!content.Category.Any())
            {
                content.Category.AddRange(Categories.Select(c => c.Value));
            }
            if (!content.Car.Any())
            {
                content.AddRange(
                   new Car
                   {
                       Name = "Tesla",
                       ShortDesc = "",
                       LongDesc = "",
                       img = "/img/tesla.jpeg",
                       price = 45000,
                       isFavorite = true,
                       available = true,
                       Category = Categories["Электромобили"]
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
                        Category = Categories["Классические автомобили"]
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
                        Category = Categories["Классические автомобили"]
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
                        Category = Categories["Электромобили"]
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
                        Category = Categories["Классические автомобили"]
                    }
                );
            }

            content.SaveChanges();
        }

        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if(category == null)
                {
                    var list = new Category[]
                    {
                        new Category {categoryName = "Электромобили", desc ="Современный вид транспорта"},
                        new Category {categoryName = "Классические автомобили", desc = "Машина с двигателем внутреннего сгорания"}
                    };

                    category = new Dictionary<string, Category>();
                    foreach(Category el in list)                  
                        category.Add(el.categoryName, el);
                }

                return category;
            }    
        }
    }
}
