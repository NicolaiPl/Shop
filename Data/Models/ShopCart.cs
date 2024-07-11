using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class ShopCart
    {
        private readonly AppDBContent appDBContent;

        public ShopCart(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public string ShopCartId { get; set; }

        public List<ShopCartItem> listShopItem { get; set; }

        public static ShopCart GetCart(IServiceProvider service)
        {

            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = service.GetService<AppDBContent>();

            string shopCartId = session.GetString("cartid") ?? Guid.NewGuid().ToString();

            session.SetString("cartid", shopCartId);

            return new ShopCart(context) { ShopCartId = shopCartId };
        }

        internal static object getShopItems()
        {
            throw new NotImplementedException();
        }

        internal void AddToCart(Car item)
        {
            throw new NotImplementedException();
        }

        public void AddToCart(Car car, int amout)
        {
            appDBContent.ShopCartItems.Add(new ShopCartItem {
                ShopCartId = ShopCartId,
                car = car,
                price = car.price
            });

            appDBContent.SaveChanges();
        }

        public List<ShopCartItem> getShopItem()
        {
            return appDBContent.ShopCartItems.Where(c => c.ShopCartId == ShopCartId).Include(s => s.car).ToList();
        }
    }
}
