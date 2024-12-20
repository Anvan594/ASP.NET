using Microsoft.AspNetCore.Mvc;
using DevXuongMoc.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
namespace DevXuongMoc.Areas.CustomerUser.Controllers
{
    public class LoginController : Controller
    {
        private readonly DevXuongMocContext _context;

        public LoginController(DevXuongMocContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Models.LoginUser model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Thông tin đăng nhập không hợp lệ.");
                return View(model);
            }

            var dataLogin = _context.Customers
                .Where(x => x.Email == model.Email && x.Password == model.Password)
                .FirstOrDefault();

            if (dataLogin != null)
            {
                // Serialize đối tượng Customer và lưu vào session
                string customerJson = JsonConvert.SerializeObject(dataLogin);
                HttpContext.Session.SetString("CustomerLogin", customerJson);
                HttpContext.Session.SetInt32("Id", (int)dataLogin.Id);

                return RedirectToAction("Index", "Home", new { customerId = dataLogin.Id });
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Thông tin đăng nhập không chính xác.");
                return View(model);
            }
        }
        // GET: Account/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(Customer customer)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra nếu tên đăng nhập đã tồn tại
                var existingUser = _context.Customers.FirstOrDefault(c => c.Username == customer.Username);
                if (existingUser != null)
                {
                    ModelState.AddModelError("Username", "Tên tài khoản đã tồn tại.");
                    return View(customer);
                }
                var existingemail = _context.Customers.FirstOrDefault(c => c.Email == customer.Email);
                if (existingemail != null)
                {
                    ModelState.AddModelError("Email", "Email tài khoản đã tồn tại.");
                    return View(customer);
                }

                // Thêm khách hàng mới vào cơ sở dữ liệu
                customer.CreatedDate = DateTime.Now;
                customer.Isactive = true;
                customer.Isdelete = false;
                _context.Add(customer);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View(customer);
        }
        // Controller: LoginController

        public IActionResult ForgotPassword()
        {
            return View();
        }

        // POST: ForgotPassword
        [HttpPost]
        public IActionResult ForgotPassword(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                ModelState.AddModelError("", "Vui lòng nhập email.");
                return View();
            }

            // Tìm người dùng bằng email
            var user = _context.Customers.FirstOrDefault(c => c.Email == email);

            if (user != null)
            {
                // Nếu tìm thấy người dùng, điều hướng đến trang đặt lại mật khẩu
                return RedirectToAction("ResetPassword", new { email = user.Email });
            }
            else
            {
                ModelState.AddModelError("", "Không tìm thấy tài khoản với email này.");
                return View();
            }
        }

        // GET: ResetPassword
        public IActionResult ResetPassword(string email)
        {
            return View(new ResetPasswordViewModel { Email = email });
        }

        // POST: ResetPassword
        [HttpPost]
        public IActionResult ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Tìm người dùng bằng email
                var user = _context.Customers.FirstOrDefault(c => c.Email == model.Email);

                if (user != null)
                {
                    // Cập nhật mật khẩu mới
                    user.Password = model.NewPassword;

                    _context.SaveChanges();
                    TempData["SuccessMessage"] = "Mật khẩu đã được cập nhật thành công!";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Không tìm thấy tài khoản với email này.");
                }
            }

            return View(model);
        }


        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("CustomerLogin");
            HttpContext.Session.Remove("Id");

            return RedirectToAction("Index");
        }
    }
}
