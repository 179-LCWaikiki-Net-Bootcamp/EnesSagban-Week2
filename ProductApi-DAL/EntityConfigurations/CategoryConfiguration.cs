using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using ProductApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi_DAL.EntityConfigurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        /// <summary>
        /// Database tablolarının property configuration'larının yapılıp 'HasData' eklendiği kısım.
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(a => a.id);
            builder.Property(a => a.id)
                .UseIdentityColumn();

            builder.Property(t => t.name).HasMaxLength(50);

            List<Category> categoryList = new List<Category>();
            using (WebClient wc = new WebClient())
            {

                string baseUrl = "https://northwind.vercel.app/api/";

                var json = wc.DownloadString(baseUrl + "categories");
                categoryList.AddRange(JsonConvert.DeserializeObject<List<Category>>(json));

            }
            builder.HasData(categoryList);
        }
    }
}
