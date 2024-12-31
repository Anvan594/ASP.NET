using DevXuongMoc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DevXuongMoc.Controllers
{
    public class CartController : Controller
    {
        private readonly DevXuongMocContext _context;

        public CartController(DevXuongMocContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var cart = GetCart();
            return View(cart);
        }

        [HttpPost]
        public IActionResult AddToCart(int productId, int quantity = 1)
        {
            var product = _context.Products.Find(productId);
            if (product != null)
            {
                var cart = GetCart();
                cart.AddItem(product, quantity);  // Add the product to the cart
                SaveCart(cart);  // Save the updated cart to session
            }
            return RedirectToAction("Index");
        }

        private ShoppingCart GetCart()
        {
            var cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("Cart") ?? new ShoppingCart();
            return cart;
        }

        private void SaveCart(ShoppingCart cart)
        {
            HttpContext.Session.SetObjectAsJson("Cart", cart);
        }

        [HttpPost]
        public IActionResult UpdateQuantity(int id, int quantity)
        {
            // If quantity is less than or equal to 0, remove the item
            if (quantity <= 0)
            {
                return DeleteItem(id);
            }

            // Retrieve the cart from session
            var cart = GetCart();

            // Find the product in the cart
            var item = cart.Items.FirstOrDefault(i => i.ProductId == id);

            if (item != null)
            {
                item.Quantity = quantity;  // Update the quantity
                SaveCart(cart);  // Save the cart to session
            }

            // Return item total and cart total
            return Json(new
            {
                success = true,
                itemTotal = $"{item.Total:N0} VND",
                total = $"{cart.Total:N0} VND"
            });
        }

        [HttpPost]
        public IActionResult DeleteItem(int id)
        {
            // Retrieve the cart from session
            var cart = GetCart();

            // Find the product in the cart
            var item = cart.Items.FirstOrDefault(i => i.ProductId == id);

            if (item != null)
            {
                cart.Items.Remove(item);  // Remove the product from the cart
                SaveCart(cart);  // Save the updated cart to session
            }

            // Return updated cart total
            return Json(new
            {
                success = true,
                total = $"{cart.Total:N0} VND"
            });
        }

        [HttpPost]
        public IActionResult Checkout()
        {
            var cart = GetCart();

            if (cart.Items.Count == 0)
            {
                return Json(new
                {
                    success = false,
                    message = "Giỏ hàng của bạn đang trống. Vui lòng thêm sản phẩm trước khi thanh toán."
                });
            }

            // Thực hiện thanh toán ở đây...

            // Xóa giỏ hàng sau khi thanh toán thành công
            HttpContext.Session.Remove("Cart");

            return Json(new
            {
                success = true,
                message = "Thanh toán thành công! Cảm ơn bạn đã mua sắm."
            });
        }
    }
}
