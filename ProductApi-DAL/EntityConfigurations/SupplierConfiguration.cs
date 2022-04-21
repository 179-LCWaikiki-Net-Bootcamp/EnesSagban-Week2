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
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            List<Supplier> supplierList = new List<Supplier>();
            List<Supplier2> supplierList2 = new List<Supplier2>();
            
            using (WebClient wc = new WebClient())
            {
                builder.Property(t => t.contactTitle).HasMaxLength(50);

                string baseUrl = "https://northwind.vercel.app/api/";

                var json = wc.DownloadString(baseUrl + "suppliers");
                supplierList2.AddRange(JsonConvert.DeserializeObject<List<Supplier2>>(json));
                foreach (var item in supplierList2)
                {
                    item.strAddress = item.address.street + " " + item.address.city + " " + item.address.region + " " +
                        item.address.postalCode + " " + item.address.country + " " + item.address.phone;
                    Supplier supplier = new Supplier();
                    supplier.id = item.id;
                    supplier.contactName = item.contactName;
                    supplier.companyName = item.companyName;
                    supplier.contactTitle = item.contactTitle;
                    supplier.strAddress = item.strAddress;
                    supplierList.Add(supplier);
                }
            }

            builder.HasData(supplierList);
            //builder.HasData(new Supplier { id=4,companyName="COMP",contactName="qwe",contactTitle="asd" });
        }
    }
}
