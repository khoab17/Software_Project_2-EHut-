
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

        public List<Brand> GetAll()
        {
            var data = brandRepo.GetAll();
            return data;

        }

        public Brand Get(int id)
        {
            var data = brandRepo.Get(id);
            return data;
        }

        

        public Brand Insert(Brand model)
        {
            var entity = model;
            bool done = brandRepo.Insert(entity);

            if (done)
            {
                return model;
            }
            else
                return null;
        }


        public Brand Update(Brand model)
        {
            var entity = model;
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
