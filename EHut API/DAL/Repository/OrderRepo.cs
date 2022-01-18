using DAL.Models;
using DAL.View_Models;
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

        public List<int> GetNonDeliveredOrders()
        {
            var data = context.Orders.Where(x => x.DeliveryStatus == false).ToList();
            List<int> orders = new List<int>();
            foreach (var order in data)
            {
                orders.Add(order.OrderId);
            }
            return orders;
        }

        public new bool Insert(Order entity)
        {
            context.Orders.Add(entity);

            if (context.SaveChanges() > 0)
            {
                return true;
            }
            else
                return false;

        }

        public List<SumGroupByModel> GetYearlySalesData()
        {
            List<SumGroupByModel> yearlySalesReport = context.Database.SqlQuery<SumGroupByModel>("select sum(GrandTotal) as Column1, YEAR(Date) as Id from Orders group by YEAR(Date)").ToList();
            return yearlySalesReport;
        }

        public List<SumGroupByModel> GetMonthlySalesDataForAYear(int year)
        {
            List<SumGroupByModel> monthlyInfoByForYear = context.Database.SqlQuery<SumGroupByModel>("select sum(Orders.GrandTotal) as Column1, Month(SalesRecords.Date) as Id from Orders FULL OUTER JOIN SalesRecords ON SalesRecords.OrderId=Orders.OrderId where YEAR(SalesRecords.Date) = '"+year+"' AND Status = 'Delivered'  group by MONTH(SalesRecords.Date)").ToList();

            return monthlyInfoByForYear;
        }
    }
}
