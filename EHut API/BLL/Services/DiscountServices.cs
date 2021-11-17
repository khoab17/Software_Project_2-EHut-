
using DAL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class DiscountServices
    {
        DiscountRepo repo = new DiscountRepo();
        public List<Discount> GetAll()
        {
            var data = repo.GetAll();
            return data;
        }

        public Discount Get(int id)
        {
            var data = repo.Get(id);
            return data;
        }

        public Discount GetByPhone(string phone)
        {
            var data = repo.GetByPhone(phone);
            return data;
        }

        public Discount Insert(Discount model)
        {
            var entity = model;
            bool done = repo.Insert(entity);

            if (done)
            {
                return model;
            }
            else
                return null;
        }


        public Discount Update(Discount model)
        {
            var entity = model;
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
