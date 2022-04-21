using Microsoft.Extensions.DependencyInjection;
using ProductApi_BLL.Abstract;
using ProductApi_BLL.Services;
using ProductApi_DAL.DependecyInjectionDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi_BLL.DependecyInjectionBLL
{
    public static class DIContainerBLL
    {
        public static void AddScopedBLL(this IServiceCollection services)
        {
            services.AddScopedDAL();
            services.AddScoped<IProductBLL,ProductService>();
            services.AddScoped<ISupplierBLL,SupplierService>();
            services.AddScoped<ICategoryBLL,CategoryService>();

            //DIContainerDAL gibi interface üzerinden instance alınacak ilgili Service'in tanımlanması.
        }
    }
}
