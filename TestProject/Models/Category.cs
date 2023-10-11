using Humanizer;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace TestProject.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? name { get; set; }

        [NotMapped]
        public IFormFile? clientFile { get; set; }

        public byte[]?dbImage { get; set; }
        public ICollection<Items>? Items { get; set; }
        [NotMapped]
        public string? imgSrc
        {
            get
            {
                if (dbImage!=null)
                {
                    string base645 = Convert.ToBase64String(dbImage, 0, dbImage.Length);
                    return "data:image/jpg;base64," + base645;
                }
                else
                {
                    return string.Empty;
                }
            }
        }
    }
}
