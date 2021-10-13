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
    public class CategoryServices
    {
        CategoryRepo categoryRepo = new CategoryRepo();
        public List<CategoryModel> GetAll()
        {
            var data = categoryRepo.GetAll();
            return Mapper<Category, CategoryModel>.ListOfEntityToModel(data);

        }

        public CategoryModel Get(int id)
        {
            var data = categoryRepo.Get(id);
            return Mapper<Category, CategoryModel>.EntityToModel(data);
        }



        public CategoryModel Insert(CategoryModel model)
        {
            var entity = Mapper<Category, CategoryModel>.ModelToEntity(model);
            bool done = categoryRepo.Insert(entity);

            if (done)
            {
                return model;
            }
            else
                return null;
        }


        public CategoryModel Update(CategoryModel model)
        {
            var entity = Mapper<Category, CategoryModel>.ModelToEntity(model);
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
