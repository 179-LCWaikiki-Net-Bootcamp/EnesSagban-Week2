using AutoMapper;
using ProductApi.Models;
using ProductApi.ViewModel;
using ProductApi_BLL.Abstract;
using ProductApi_DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi_BLL.Services
{
    public class SupplierService : ISupplierBLL
    {
        IMapper mapper;
        ISupplierDAL supplierDAL;
        IProductDAL productDAL;

        public SupplierService(ISupplierDAL supplierDAL, IMapper mapper, IProductDAL productDAL)
        {
            this.supplierDAL = supplierDAL;
            this.mapper = mapper;
            this.productDAL = productDAL;
        }


        public List<SupplierVM> GetAllSuppliers()
        {
            return mapper.Map<List<SupplierVM>>(supplierDAL.GetAll().ToList());
        }

        public SupplierVM GetSupplierById(int id)
        {
            return mapper.Map<SupplierVM>(supplierDAL.Get(x => x.id == id, x => x.Products));
        }

        public List<ProductVM> GetProductsInCategory(int id)
        {
            List<Product> products = productDAL.GetAll(x => x.categoryId == id, x => x.Supplier, x => x.Category).ToList();
            List<ProductVM> vm = mapper.Map<List<ProductVM>>(products);
            return vm;
        }

        public SupplierVM CreateSupplier(SupplierVM supplier)
        {
            return mapper.Map<SupplierVM>(supplierDAL.Add(mapper.Map<Supplier>(supplier)));
        }

        public SupplierVM UpdateSupplier(SupplierVM updateSupplier)
        {
            return mapper.Map<SupplierVM>(supplierDAL.Update(mapper.Map<Supplier>(updateSupplier)));
        }

        public int DeleteSupplier(int id)
        {
            Supplier deleteSupplier = supplierDAL.Get(x => x.id == id);
            if (deleteSupplier != null)
                return supplierDAL.Delete(deleteSupplier);
            return 0;
        }

        public List<SupplierVM> GetSupplierByFilter(string str)
        {
            return mapper.Map<List<SupplierVM>>(supplierDAL.GetAll(x => x.contactName.Contains(str)).ToList());
        }
    }
}
