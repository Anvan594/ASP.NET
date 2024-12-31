using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using DevXuongMoc.Models;

namespace DevXuongMoc.Helpers
{
    public static class CartHelper
    {
        public static ShoppingCart GetCart(ISession session)
        {
            var sessionData = session.GetString("ShoppingCart");
            return sessionData != null ? JsonConvert.DeserializeObject<ShoppingCart>(sessionData) : new ShoppingCart();
        }

        public static void SaveCart(ISession session, ShoppingCart cart)
        {
            session.SetString("ShoppingCart", JsonConvert.SerializeObject(cart));
        }
    }
}
