using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class OrderRepo : Repository<Order>
    {
        public int GetOrderId(int customerId)
        {
            int id=context.Orders.Where(x=>x.CustomerId==customerId && x.DeliverymanId==-1).OrderByDescending(x=>x.OrderId).First().OrderId;
            return id;
        }
    }
}
