using Microsoft.Extensions.DependencyInjection;
using ProductApi_DAL.Abstract;
using ProductApi_DAL.ProductRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi_DAL.DependecyInjectionDAL
{
    public static class DIContainerDAL
    {
        /// <summary>
        /// Buradan 'program.cs'e kadar uzanacak Constructer Dependency Injection yapısının tanımlandığı DIContainer
        /// Burada hangi interface kullanıldığında hangi Repo'nun instance'ının alınacağını belirttik.
        /// </summary>
        /// <param name="services"></param>
        public static void AddScopedDAL(this IServiceCollection services)
        {
            services.AddDbContext<ProductDbContext>();
            services.AddScoped<IProductDAL, ProductRepository>(); //Bu DI uzantısı ile ProductRepository'in instance'ı alınır.
            services.AddScoped<ICategoryDAL, CategoryRepository>();
            services.AddScoped<ISupplierDAL, SupplierRepository>();

        }
    }
}
