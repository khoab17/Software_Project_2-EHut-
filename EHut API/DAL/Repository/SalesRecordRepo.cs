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

        public async Task<List<SalesRecord>> GetRecordsToAddOrderId(int customerId)
        {
            List<SalesRecord> records = new List<SalesRecord>();
            var data = await context.SalesRecords.Where(x => x.CustomerId == customerId && x.OrderId == -1).ToListAsync();
            foreach (var record in data)
            {
                records.Add(record);
            }
            return records;
        }

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

        public List<SalesRecord> GetSalesRecordByShop(int shopId)
        {

            return context.SalesRecords.Where(x=>x.ShopId==shopId && x.Status == false).ToList();

        }
    }
}
