using System.ComponentModel.DataAnnotations;

namespace CRUDDapperApplication.Models
{
    public class Products
    {
        public int PId { get; set; }

        [Required]
        public string Pname { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Price must be a positive number")]
        public int Price { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
