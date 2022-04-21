using ProductApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi_BLL.Abstract
{
    public interface ISupplierBLL
    {
        List<SupplierVM> GetAllSuppliers();
        SupplierVM GetSupplierById(int id);
        SupplierVM CreateSupplier(SupplierVM supplier);
        SupplierVM UpdateSupplier(SupplierVM updateSupplier);
        int DeleteSupplier(int id);
        List<SupplierVM> GetSupplierByFilter(string str);
        List<ProductVM> GetProductsInCategory(int id);
    }
}
