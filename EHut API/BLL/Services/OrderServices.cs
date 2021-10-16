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
    public class OrderServices
    {
        OrderRepo repo = new OrderRepo();
        public List<OrderModel> GetAll()
        {
            var data = repo.GetAll();
            return Mapper<Order, OrderModel>.ListOfEntityToModel(data);
        }

        public OrderModel Get(int id)
        {
            var data = repo.Get(id);
            return Mapper<Order, OrderModel>.EntityToModel(data);
        }

        public OrderModel GetByPhone(string phone)
        {
            var data = repo.GetByPhone(phone);
            return Mapper<Order, OrderModel>.EntityToModel(data);
        }

        public OrderModel Insert(OrderModel model)
        {
            var entity = Mapper<Order, OrderModel>.ModelToEntity(model);
            bool done = repo.Insert(entity);

            if (done)
            {
                return model;
            }
            else
                return null;
        }


        public OrderModel Update(OrderModel model)
        {
            var entity = Mapper<Order, OrderModel>.ModelToEntity(model);
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
