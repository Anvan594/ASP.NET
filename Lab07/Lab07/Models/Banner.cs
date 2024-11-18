using System.ComponentModel.DataAnnotations.Schema;

namespace Lab07.Models
{
    [Table("Banners")]
    public class Banner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public int Prioty { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
    }
}
