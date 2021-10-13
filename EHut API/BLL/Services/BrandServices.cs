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
    public class BrandServices
    {
        BrandRepo brandRepo = new BrandRepo();

        public List<BrandModel> GetAll()
        {
            var data = brandRepo.GetAll();
            return Mapper<Brand, BrandModel>.ListOfEntityToModel(data);

        }

        public BrandModel Get(int id)
        {
            var data = brandRepo.Get(id);
            return Mapper<Brand, BrandModel>.EntityToModel(data);
        }

        

        public BrandModel Insert(BrandModel model)
        {
            var entity = Mapper<Brand, BrandModel>.ModelToEntity(model);
            bool done = brandRepo.Insert(entity);

            if (done)
            {
                return model;
            }
            else
                return null;
        }


        public BrandModel Update(BrandModel model)
        {
            var entity = Mapper<Brand, BrandModel>.ModelToEntity(model);
            bool done = brandRepo.Update(entity);
            if (done)
            {
                return model;
            }
            else
                return null;
        }

        public bool Delete(int id)
        {
            bool done = brandRepo.Delete(id);
            if (done)
            {
                return true;
            }
            else
                return false;
        }
    }
}
