using AutoMapper;
using ProductApi.Models;
using ProductApi.ViewModel;
using ProductApi_BLL.Abstract;
using ProductApi_BLL.MappingFolder;
using ProductApi_DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi_BLL
{
    public class ProductService:IProductBLL
    {
        IProductDAL productDAL;
        IMapper mapper;
        public ProductService(IProductDAL productDAL,IMapper mapper)
        {
            this.productDAL = productDAL;
            this.mapper = mapper;
        }

        public List<ProductVM> GetAllProducts()
        {

            return mapper.Map<List<ProductVM>>(productDAL.GetAll(null,x=>x.Category,x=>x.Supplier).ToList());
        }

        public ProductVM GetProductById(int id)
        {
            Product product=productDAL.Get(x=>x.id == id, x=>x.Supplier, x=>x.Category);
            ProductVM productVM=mapper.Map<ProductVM>(product);
            return productVM;
            return mapper.Map<ProductVM>(productDAL.Get(x => x.id == id, x => x.Supplier, x => x.Category));
        }

        public ProductVM CreateProduct(ProductVM product)
        {
            
            return mapper.Map<ProductVM>(productDAL.Add(mapper.Map<Product>(product)));
        }

        public ProductVM UpdateProduct(ProductVM updatedProduct)
        {
            return mapper.Map<ProductVM>(productDAL.Update(mapper.Map<Product>(updatedProduct)));
        }
        public int DeleteProduct(int id)
        {
            Product deleteProduct = productDAL.Get(x=>x.id==id);
            if (deleteProduct != null)
                return productDAL.Delete(deleteProduct);
            return 0;
        }

        public List<ProductVM> GetProductByFilter(string str)
        {
            return mapper.Map<List<ProductVM>>(productDAL.GetAll(x => x.name.Contains(str)).ToList());
        }
    }
}
