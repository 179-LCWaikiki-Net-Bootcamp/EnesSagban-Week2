using ProductApi.Core.Entity;
using System.ComponentModel.DataAnnotations;

namespace ProductApi.Models
{
    public class Category : BaseEntity
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }
        [Required]
        [MaxLength(100), MinLength(10)]
        public string description { get; set; } = "Default description.";
        public string? name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
