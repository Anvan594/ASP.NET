using Microsoft.AspNetCore.Mvc;
using NetcoreMVCLap3.Models;

namespace NetcoreMVCLap3.ViewComponents
{
    public class BookViewComponent : ViewComponent
    {
        protected Book book = new Book();
        public IViewComponentResult Invoke()
        {
            var books = book.GetBookList();
            return View(books);
        }
    }
}
