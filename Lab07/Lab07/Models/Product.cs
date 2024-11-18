using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace Lab07.Models
{
    [Table("Products")]
    public class Product
    {
        public int ProductID { get; set; }
        public int ProductName { get; set; }
        public float ProductPrice { get; set; }
        public float salePrice { get; set; }
        public bool Status { get; set; }
        public int? CategoryId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }

    }
}
