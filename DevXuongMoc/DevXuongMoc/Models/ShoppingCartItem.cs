using System;
using System.Collections.Generic;

namespace DevXuongMoc.Models
{
    public class ShoppingCartItem
    {
        public List<ShoppingCartItem> Items { get; set; }
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public decimal GetTotal()
        {
            if (Items == null || !Items.Any()) return 0;
            return Items.Sum(item => item.Price * item.Quantity);
        }

    }

    public class ShoppingCart
    {
        public List<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();

        public decimal Total
        {
            get
            {
                decimal total = 0;
                foreach (var item in Items)
                {
                    total += item.Price * item.Quantity;
                }
                return total;
            }
        }

        public int ProductId { get; internal set; }
        public int Quantity { get; internal set; }
        public int Price { get; internal set; }

        public void AddItem(Product product, int quantity)
        {
            var existingItem = Items.Find(i => i.ProductId == product.Id);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                Items.Add(new ShoppingCartItem
                {
                    Image = product.Image,
                    ProductId = product.Id,
                    Title = product.Title,
                    Price = product.PriceNew ?? 0,
                    Quantity = quantity
                });
            }
        }

        public void RemoveItem(int productId)
        {
            Items.RemoveAll(i => i.ProductId == productId);
        }

    }
}