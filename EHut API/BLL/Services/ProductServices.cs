
using DAL;
using DAL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// Please read the DocumentConventions.txt first


namespace BLL.Services
{
    public class ProductServices
    {
        ProductRepo productRepo = new ProductRepo();

        //Get Products
        public List<Product> GetAll()
        {

            var data = productRepo.GetAll();
            return data;
        }

        public Product Get(int id)
        {
            var data = productRepo.Get(id);
            return data;
        }

        public List<Product> ProductsByCategory(int id)
        {
            return productRepo.ProductsByCategory(id);
        }
        public List<Product> ProductsByBrand(int id)
        {
            return productRepo.ProductsByBrand(id);
        }
        public List<Product> PriceFilter(float min, float max)
        {
            return productRepo.PriceFilter(min, max);
        }
        public List<Product> Search(string name)
        {
            return productRepo.Search(name);
        }
        /*public List<Product> TopProductSold()//        --- Top product in terms of Number of product sold
        {
          var data= productRepo.TopProductSold();
            return data;
        }*/
        public List<Product> GetTopProducts(int top)
        {
            return productRepo.GetTopProducts(top);
        }


        public Product Insert(Product model)
        {
            var entity = model;
            bool done = productRepo.Insert(entity);

            if (done)
            {
                return model;
            }
            else
                return null;
        }


        public Product Update(Product model)
        {
            var entity = model;  
            bool done = productRepo.Update(entity);
            if (done)
            {
                return model;
            }
            else
                return null;
        }

        public bool Delete(int id)
        {
            bool done = productRepo.Delete(id);
            if (done)
            {
                return true;
            }
            else
                return false;
        }
    }
}
