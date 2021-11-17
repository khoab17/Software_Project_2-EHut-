
using DAL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class OrderServices
    {
        OrderRepo repo = new OrderRepo();
        public List<Order> GetAll()
        {
            var data = repo.GetAll();
            return data;
        }

        public Order Get(int id)
        {
            var data = repo.Get(id);
            return data;
        }

        public Order GetByPhone(string phone)
        {
            var data = repo.GetByPhone(phone);
            return data;
        }

        public Order Insert(Order model)
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


        public Order Update(Order model)
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
