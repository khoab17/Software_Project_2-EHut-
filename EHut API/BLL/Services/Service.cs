using DAL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class Service<TEntity, TEntityModel> : IService<TEntity, TEntityModel> 
                                                    where TEntity : class
                                                    where TEntityModel : class
    {
        /* public object RepoFinder(TEntity)
         {

         //Find the type of TEntity.
         //Create Repo of that type.
         //Return the Repo object.

         }*/
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public TEntityModel Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<TEntityModel> GetAll()
        {
            //Object repoObject= RepoFinder();
            //var temp = repoObject.GetAll();
            //var data = AutoMapper.Mapper.Map<List<TEntity>, List<TEntityModel>>(temp);
            //return data;
            return null;
        }

        public TEntityModel Insert(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntityModel Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
