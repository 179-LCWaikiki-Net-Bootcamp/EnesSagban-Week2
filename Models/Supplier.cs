using ProductApi.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Models
{
    public class Supplier : BaseEntity
    {
        public Supplier()
        {
            Products = new HashSet<Product>();
        }
        public string companyName { get; set; }
        public string contactName { get; set; }
        public string? contactTitle { get; set; }
        public string? strAddress { get; set; }
        //public Address address { get; set; }
        public ICollection<Product> Products { get; set; }
    }

    public class Supplier2
    {
        public int id { get; set; }
        public string companyName { get; set; }
        public string contactName { get; set; }
        public string? contactTitle { get; set; }
        public string? strAddress { get; set; }
        public Address address { get; set; }
    }
    public class Address
    {
        public string street { get; set; }
        public string city { get; set; }
        public string region { get; set; }
        public string postalCode { get; set; }
        public string country { get; set; }
        public string phone { get; set; }

    }
}
