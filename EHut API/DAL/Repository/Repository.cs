using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected EHut context = new EHut();
        public bool Delete(int id)
        {
            context.Set<TEntity>().Remove(Get(id));
            if (context.SaveChanges() > 0)
            {
                return true;
            }
            else
                return false;
        }

        public TEntity Get(int id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public List<TEntity> GetAll()
        {
            return context.Set<TEntity>().ToList();
        }

        public bool Insert(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            try
            {
                if (context.SaveChanges() > 0)
                {
                    return true;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
            
        }

        public bool Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            try
            {
                if (context.SaveChanges() > 0)
                {
                    return true;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        /// Custom Methods
        public virtual TEntity GetByPhone(string phone)
        {
            return context.Set<TEntity>().Find(phone);
        }
    }
}
