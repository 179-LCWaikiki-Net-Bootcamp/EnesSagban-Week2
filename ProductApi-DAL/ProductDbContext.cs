using ProductApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using ProductApi_DAL.EntityConfigurations;

namespace ProductApi_DAL
{
    public class ProductDbContext : DbContext
    {
        /// <summary>
        /// DAL katmanı 'set as startup' yapıldıktan sonra 'add-migration' migration oluşturulup, 
        /// 'update-database' ile database create edilir.Database 'northwind/api' endpointslerinden 
        /// ilgili data'ları fetch ederek bu veriler ile oluşturulur.
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=ProductDB;Trusted_Connection=True;");
            optionsBuilder.EnableSensitiveDataLogging();
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new SupplierConfiguration());
        }
    }
}
