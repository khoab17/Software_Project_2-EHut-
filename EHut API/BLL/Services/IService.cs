using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    interface IService<TEntity,TEntityModel> where TEntity :class
                                             where TEntityModel:class
    {
        List<TEntityModel> GetAll();
        TEntityModel Get(int id);
        TEntityModel Insert(TEntity entity);
        TEntityModel Update(TEntity entity);
        bool Delete(int id);
    }
}
