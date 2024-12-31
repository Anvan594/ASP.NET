using System.ComponentModel.DataAnnotations;

namespace DevXuongMoc.Models
{
    public class PaymentMethod
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Tên phương thức")]
        public string Name { get; set; }

        [Display(Name = "Mô tả")]
        public string Description { get; set; }
    }
}
