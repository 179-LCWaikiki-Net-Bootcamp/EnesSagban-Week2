using AutoMapper;
using ProductApi.Models;
using ProductApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi_BLL.MappingFolder
{
    public class Mapping:Profile
    {
        public Mapping()
        {
            //Entity ve VM'ler arasında yapılacak AutoMapper tanımlamaları

            CreateMap<Product, ProductVM>().ForMember(x => x.CategoryName, x=>x.MapFrom(x=>x.Category.name))
                .ForMember(x => x.SupplierName, x => x.MapFrom(x => x.Supplier.contactName));
            CreateMap<ProductVM, Product>();

            CreateMap<Supplier, SupplierVM>();
            CreateMap<SupplierVM, Supplier>();

            CreateMap<Category, CategoryVM>();
            CreateMap<CategoryVM, Category>();
        }
    }
}
