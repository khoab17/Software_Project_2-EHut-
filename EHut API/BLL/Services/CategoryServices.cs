
using DAL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CategoryServices
    {
        CategoryRepo categoryRepo = new CategoryRepo();
        public List<Category> GetAll()
        {
            var data = categoryRepo.GetAll();
            return data;

        }

        public Category Get(int id)
        {
            var data = categoryRepo.Get(id);
            return data;
        }



        public Category Insert(Category model)
        {
            var entity = model;
            bool done = categoryRepo.Insert(entity);

            if (done)
            {
                return model;
            }
            else
                return null;
        }


        public Category Update(Category model)
        {
            var entity = model;
            bool done = categoryRepo.Update(entity);
            if (done)
            {
                return model;
            }
            else
                return null;
        }

        public bool Delete(int id)
        {
            bool done = categoryRepo.Delete(id);
            if (done)
            {
                return true;
            }
            else
                return false;
        }
    }
}
