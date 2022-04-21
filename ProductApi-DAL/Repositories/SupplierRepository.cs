using ProductApi.Core.EntityFramework;
using ProductApi.Models;
using ProductApi_DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProductApi_DAL.ProductRepositories
{
    public class SupplierRepository : EFRepositoryBase<Supplier, ProductDbContext>, ISupplierDAL
    {
        public SupplierRepository(ProductDbContext context) : base(context)
        {
        }
    }
}
