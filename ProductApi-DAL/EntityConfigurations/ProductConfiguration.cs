using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using ProductApi.Models;

namespace ProductApi_DAL.EntityConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(a => a.id);
            builder.Property(a => a.id)
                .UseIdentityColumn();

            builder.HasOne(a => a.Category)
                .WithMany(a => a.Products)
                .HasForeignKey(a => a.categoryId);

            builder.HasOne(a => a.Supplier)
                 .WithMany(a => a.Products)
                 .HasForeignKey(a => a.supplierId);
            //Relation'ların tek configuration'da tanımlanması yeterli. Ayrıca 'Category ve Supplier' Config'te tanıma gerek yok.

            builder.Property(t => t.name).HasMaxLength(50);

            List<Product2> productList2 = new List<Product2>();
            List<Product2> productList = new List<Product2>();
            using (WebClient wc = new WebClient())
            {
                
                string baseUrl = "https://northwind.vercel.app/api/";

                var json = wc.DownloadString(baseUrl + "products");
                productList2.AddRange(JsonConvert.DeserializeObject<List<Product2>>(json));
                productList= productList2;

            }
            builder.HasData(productList);
        }
    }
}
