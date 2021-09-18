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
    public class Service /*<TEntity, TEntityModel> : IService<TEntity, TEntityModel> 
                                                    where TEntity : class
                                                    where TEntityModel : class*/
    {
        private object entity;
        private object entityModel;
        private MasterRepo repo;
        public Service(object en, object enModel)
        {
            entity = en;
            entityModel = enModel;
            RepoFinder();
        }

        public void RepoFinder()
        {
            if (entity == new Admin() { })
            {
                AdminRepo adminRepo = new AdminRepo();
                repo.AdminRepo = new AdminRepo();
            }
            else
            {
                ProductRepo productRepo = new ProductRepo();
               // this.repo = productRepo;
            }    
        }

        public void GetAll()
        {
            //Object repoObject= RepoFinder();
            //var temp = repoObject.GetAll();
            //var data = AutoMapper.Mapper.Map<List<TEntity>, List<TEntityModel>>(temp);
            //return data;
            var temp = repo.AdminRepo.GetAll();
            List<AdminModel> adminModels  = AutoMapper.Mapper.Map<List<Admin>, List<AdminModel>>(temp);//---------------to map adminModel to Admin
            int a = 0;
            //return adminModels;
        }
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public object Get(int id)
        {
            throw new NotImplementedException();
        }

        

        public object Insert(object en)
        {
            throw new NotImplementedException();
        }

        public object Update(object en)
        {
            throw new NotImplementedException();
        }
    }
}
