using Microsoft.AspNetCore.Mvc.Rendering;

namespace NetcoreMVCLap3.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public string Image { get; set; }
        public float Price { get; set; }
        public int TotalPage { get; set; }
        public string Sumary { get; set; }
        public List<Book> GetBookList()
        {
            List<Book> books = new List<Book>()
            {
                new Book()
                {
                    Id = 1,
                    Title = "Chí Phèo",
                    AuthorId = 1,
                    GenreId = 1,
                    Image = "/images/product/1b.jpg",
                    Price = 500000,
                    Sumary = "",
                    TotalPage = 250
                },
                new Book()
                {
                    Id = 2,
                    Title = "Lão Hạc",
                    AuthorId = 1,
                    GenreId = 1,
                    Image = "/images/product/2b.jpg",
                    Price = 500000,
                    Sumary = "",
                    TotalPage = 250
                },
                new Book()
                {
                    Id = 1,
                    Title = "Tắt Đèn",
                    AuthorId = 1,
                    GenreId = 1,
                    Image = "/images/product/3b.jpg",
                    Price = 500000,
                    Sumary = "",
                    TotalPage = 250
                },
                new Book()
                {
                    Id = 1,
                    Title = "Văn An",
                    AuthorId = 2,
                    GenreId = 1,
                    Image = "/images/product/4b.png",
                    Price = 50000,
                    Sumary = "",
                    TotalPage = 250
                }

            };
            return books;
        }
        public Book GetBookById(int id)
        {
            Book book = this.GetBookList().FirstOrDefault(x => x.Id == id);
            return book;
        }
        public List<SelectListItem> Authors { get; } = new List<SelectListItem>()
        {
            new SelectListItem {Value="1",Text="Nam Cao"},
            new SelectListItem {Value="2",Text="Ngô Tất Tố" },
            new SelectListItem {Value="3",Text="Adamkhoom" },
            new SelectListItem {Value="4",Text="Nguyễn Văn An" }
        };
        public List<SelectListItem> Genres { get; } = new List<SelectListItem>()
        {
            new SelectListItem {Value="1",Text="Truyện Tranh" },
            new SelectListItem {Value="2",Text="Văn học đương đại" },
            new SelectListItem {Value="3",Text="Truyện Cười" },
            new SelectListItem {Value="4",Text="FIFA Online 4" }
        };
    }
}
