using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{

    public class SalesRecordRepo : Repository<SalesRecord>
    {
        private OrderRepo _orderRepo;



        public bool AddOrderId(SalesRecord salesRecord)
        {
            context.Entry(salesRecord).State = EntityState.Modified;
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

       /* public bool  UpdateSalesRecorStatus(int id, string status)
        {
             var temp = context.SalesRecords.Where(x=>x.SalesRecordId == id).FirstOrDefault();
             temp.Status = status;

        }*/

        public List<SalesRecord> GetSalesRecordByShop(int shopId)
        {

            return context.SalesRecords.Where(x=>x.ShopId==shopId && x.Status == "Pending").ToList();

        }
    }
}
