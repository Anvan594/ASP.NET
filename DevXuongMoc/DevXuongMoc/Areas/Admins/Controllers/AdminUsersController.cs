using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DevXuongMoc.Models;

namespace DevXuongMoc.Areas.Admins.Controllers
{
    [Area("Admins")]
    public class AdminUsersController : Controller
    {
        private readonly DevXuongMocContext _context;

        public AdminUsersController(DevXuongMocContext context)
        {
            _context = context;
        }

        // GET: Admins/AdminUsers
        public async Task<IActionResult> Index(string searchString)
        {
            ViewData["SearchString"] = searchString;

            // Truy vấn danh sách Admin Users
            var users = from u in _context.AdminUsers
                        select u;

            // Lọc dữ liệu nếu có từ khóa tìm kiếm
            if (!string.IsNullOrEmpty(searchString))
            {
                users = users.Where(u => u.Name.Contains(searchString) || u.Account.Contains(searchString));
            }

            return View(users.ToList());
        }

        public PartialViewResult Details(int id)
        {
            var adminUser = _context.AdminUsers.FirstOrDefault(x => x.Id == id);
            return PartialView("Details", adminUser); // Trả về Partial View với dữ liệu chi tiết
        }

        // GET: Admins/AdminUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admins/AdminUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Account,Password,MaNhanSu,Name,Phone,Email,Avatar,IdPhongBan,NgayTao,NguoiTao,NgayCapNhat,NguoiCapNhat,SessionToken,Salt,IsAdmin,TrangThai,IsDelete")] AdminUser adminUser)
        {
            if (ModelState.IsValid)
            {

                _context.Add(adminUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(adminUser);
        }

        /*
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var item = _context.AdminUsers.FirstOrDefault(x => x.Id == id); // Lấy dữ liệu từ database
            if (item == null)
            {
                return NotFound(); // Xử lý khi không tìm thấy
            }
            return PartialView("Edit", item); // Trả model vào PartialView
        }*/
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var item = _context.AdminUsers.Find(id); // Lấy dữ liệu từ DB
            if (item == null)
            {
                return NotFound();
            }
            return PartialView("Edit", item); // Trả về PartialView với form
        }

        [HttpPost]
        public IActionResult Edit(AdminUser model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.AdminUsers.Find(model.Id);
                if (user == null)
                {
                    return NotFound();
                }

                // Cập nhật dữ liệu
                user.Account = model.Account;
                user.Name = model.Name;
                user.Phone = model.Phone;
                user.Email = model.Email;
                user.TrangThai = model.TrangThai;
                user.NgayCapNhat = DateTime.Now;

                _context.SaveChanges();
                return RedirectToAction("Index", "AdminUsers");
            }

            return PartialView("Edit", model); // Nếu lỗi, trả lại form với thông báo
        }


        // Hiển thị trang xác nhận xóa
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var user = _context.AdminUsers.Find(id);
            if (user == null) return NotFound();

            return View(user); // Trả về view xác nhận xóa
        }

        // Xử lý hành động xóa
        [HttpPost, ActionName("Delete")] // Đổi tên action để tránh trùng
        public IActionResult DeleteConfirmed(int id)
        {
            var user = _context.AdminUsers.Find(id);
            if (user == null) return NotFound();

            _context.AdminUsers.Remove(user);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }


        // POST: Admins/AdminUsers/Delete/5
        /*[HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var adminUser = await _context.AdminUsers.FindAsync(id);
            if (adminUser != null)
            {
                _context.AdminUsers.Remove(adminUser);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }*/

        private bool AdminUserExists(int id)
        {
            return _context.AdminUsers.Any(e => e.Id == id);
        }
    }
}
