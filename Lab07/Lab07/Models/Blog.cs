using System.ComponentModel.DataAnnotations.Schema;

namespace Lab07.Models
{
    [Table("Blogs")]
    public class Blog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public DateTime CteatedDate { get; set; }
        public string Image {  get; set; }
        public string Description { get; set; }
    }
}
