using ProductApi.Core.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductApi.Models
{

    public class Product : BaseEntity
    {
        [ForeignKey("Supplier")]
        public int supplierId { get; set; }
        [ForeignKey("Category")]
        public int? categoryId { get; set; }
        [Required]
        public string quantityPerUnit { get; set; } = "17";
        [Required]
        [Range(0.1,Double.MaxValue)]
        public decimal unitPrice { get; set; }
        public int unitsInStock { get; set; }
        public int unitsOnOrder { get; set; } = 17;
        public int reorderLevel { get; set; } = 17;
        public bool discontinued { get; set; } = false;
        public string name { get; set; }
        public Supplier Supplier { get; set; }
        public Category Category { get; set; }

    }

    /// <summary>
    /// JSON dönüşümünde supplier ve category'nin boş gelmesi için yardımcı class
    /// </summary>
    public class Product2
    {
        public int id { get; set; }
        public int supplierId { get; set; }
        public int? categoryId { get; set; }
        public string quantityPerUnit { get; set; }
        public decimal unitPrice { get; set; }
        public int unitsInStock { get; set; }
        public int unitsOnOrder { get; set; }
        public int reorderLevel { get; set; }
        public bool discontinued { get; set; }
        public string name { get; set; }
    }
}
