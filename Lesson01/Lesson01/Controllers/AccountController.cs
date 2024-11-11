using Lesson01.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Lesson02.mvc.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            List<Account> accounts = new List<Account>
            {
                new Account()
                {
                    Id = 1,
                    Name = "Test",
                    Email = "Test@gmail.com",
                    Phone = "0327762985",
                    Address = "Hà Nội",
                    Avatar = Url.Content("~/images/Avatar/1.jpg"),
                    Gender=1,
                    Bio="Handsome",
                    Birthday=new DateTime(2003,9,2)
                },
                new Account()
                {
                    Id = 2,
                    Name = "Test",
                    Email = "Test@gmail.com",
                    Phone = "0327762985",
                    Address = "Hà Nội",
                    Avatar = Url.Content("~/images/Avatar/1.jpg"),
                    Gender=1,
                    Bio="Handsome",
                    Birthday=new DateTime(2003,3,8)
                },
                new Account()
                {
                    Id = 3,
                    Name = "Test",
                    Email = "Test@gmail.com",
                    Phone = "0327762985",
                    Address = "Hà Nội",
                    Avatar = Url.Content("~/images/Avatar/1.jpg"),
                    Gender=1,
                    Bio="Handsome",
                    Birthday=new DateTime(2003,6,7)
                }
            };
            ViewBag.Accounts = accounts;
            return View();
        }
        public IActionResult Profile()
        {
            Account account = new Account()
            {
                Id = 1,
                Name = "An",
                Email = "anvan9524@gmail.com",
                Phone = "0327762985",
                Address = "Hà Nội",
                Avatar = ("~/images/Avatar/1.jpg"),
                Gender = 1,
                Bio = "ANNN",
                Birthday = new DateTime(2003, 3, 8)
            };
            ViewBag.account = account;
            return View();
        }
    };
}
