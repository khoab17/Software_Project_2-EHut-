using BEL.Model;
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
        public List<ProductModel> GetAll()
        {

            var data = productRepo.GetAll();
            return Mapper<Product, ProductModel>.ListOfEntityToModel(data);
        }

        public ProductModel Get(int id)
        {
            var data = productRepo.Get(id);
            return Mapper<Product, ProductModel>.EntityToModel(data);
        }

        

        public ProductModel Insert(ProductModel model)
        {
            var entity = Mapper<Product, ProductModel>.ModelToEntity(model);
            bool done = productRepo.Insert(entity);

            if (done)
            {
                return model;
            }
            else
                return null;
        }


        public ProductModel Update(ProductModel model)
        {
            var entity = Mapper<Product, ProductModel>.ModelToEntity(model);  
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
