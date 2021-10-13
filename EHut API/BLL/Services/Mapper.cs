using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class Mapper<TEntity, TModel> where TEntity : class
                                         where TModel : class
    {
        public static TModel EntityToModel(TEntity entity)
        {
            var model= AutoMapper.Mapper.Map<TEntity, TModel>(entity);
            return model;
        }
        public static List<TModel> ListOfEntityToModel(List<TEntity> entity)
        {
            var model = AutoMapper.Mapper.Map<List<TEntity>, List<TModel>>(entity);
            return model;
        }
        public static TEntity ModelToEntity(TModel model)
        {
            var entity= AutoMapper.Mapper.Map<TModel, TEntity>(model);
            return entity;
        }
        

    }
}
