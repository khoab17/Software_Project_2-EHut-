
using DAL.Models;
using DAL.Repository;
using DAL.View_Models;
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


       public int GetOrderId(int customerId)
        {
            return repo.GetOrderId(customerId);
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

        public List<SumGroupByModel> GetYearlySalesData()
        {
            return repo.GetYearlySalesData();
        }
        public List<SumGroupByModel> GetMonthlySalesDataForAYear(int year,int id)
        {
            return repo.GetMonthlySalesDataForAYear(year,id);
        }
    }
}
