using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestProject.Models
{

    public class Items
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public decimal price { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [Required]
        [DisplayName("Category")]
        [ForeignKey("Category") ]
        public int CategoryId { get; set;}
        public string? imagepath { get; set; }
        [NotMapped]
        public IFormFile? clientFile { get; set; }
        public Category? Category { get; set; }
    }
}
