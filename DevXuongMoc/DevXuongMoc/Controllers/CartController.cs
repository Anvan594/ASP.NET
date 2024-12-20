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
            // If quantity is 0 or negative, we can remove the item
            if (quantity <= 0)
            {
                return DeleteItem(id);
            }

            // Lấy giỏ hàng từ session
            var cart = GetCart();

            // Tìm sản phẩm trong giỏ hàng
            var item = cart.Items.FirstOrDefault(i => i.ProductId == id);

            if (item != null)
            {
                item.Quantity = quantity;  // Cập nhật số lượng
                SaveCart(cart);  // Lưu lại giỏ hàng vào session
            }

            // Trả về tổng tiền cho sản phẩm này và tổng giỏ hàng
            return Json(new
            {
                itemTotal = $"{item.Total:N0} VND",  // Display item total
                total = $"{cart.Total:N0} VND"  // Display the total cart value
            });
        }

        [HttpPost]
        public IActionResult DeleteItem(int id)
        {
            // Lấy giỏ hàng từ session
            var cart = GetCart();

            // Tìm sản phẩm trong giỏ hàng
            var item = cart.Items.FirstOrDefault(i => i.ProductId == id);

            if (item != null)
            {
                cart.Items.Remove(item);  // Xóa sản phẩm khỏi giỏ hàng
                SaveCart(cart);  // Lưu lại giỏ hàng vào session
            }

            // Trả về tổng tiền giỏ hàng sau khi xóa sản phẩm
            return Json(new { total = $"{cart.Total:N0} VND" });  // Display the updated cart total
        }
    }
}
