using BEL.Model;
using DAL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ProductDistributionServices
    {
        ProductDistributionRepo repo = new ProductDistributionRepo();
        public List<ProductDistributionModel> GetAll()
        {
            var data = repo.GetAll();
            return Mapper<ProductDistribution, ProductDistributionModel>.ListOfEntityToModel(data);
        }

        public ProductDistributionModel Get(int id)
        {
            var data = repo.Get(id);
            return Mapper<ProductDistribution, ProductDistributionModel>.EntityToModel(data);
        }

        public ProductDistributionModel GetByPhone(string phone)
        {
            var data = repo.GetByPhone(phone);
            return Mapper<ProductDistribution, ProductDistributionModel>.EntityToModel(data);
        }

        public ProductDistributionModel Insert(ProductDistributionModel model)
        {
            var entity = Mapper<ProductDistribution, ProductDistributionModel>.ModelToEntity(model);
            bool done = repo.Insert(entity);

            if (done)
            {
                return model;
            }
            else
                return null;
        }


        public ProductDistributionModel Update(ProductDistributionModel model)
        {
            var entity = Mapper<ProductDistribution, ProductDistributionModel>.ModelToEntity(model);
            bool done = repo.Update(entity);
            if (done)
            {
                return model;
            }
            else
                return null;
        }

        public bool Delete(int id)
        {
            bool done = repo.Delete(id);
            if (done)
            {
                return true;
            }
            else
                return false;
        }
    }
}
