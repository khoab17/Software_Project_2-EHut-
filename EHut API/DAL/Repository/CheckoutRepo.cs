using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class CheckoutRepo
    {
        SalesRecordRepo salesRecordRepo=new SalesRecordRepo();

        public SalesRecord Insert (SalesRecord salesRecord)
        {
           if( salesRecordRepo.Insert(salesRecord))
            {
                return salesRecord;
            }
           return null;
        }

        public bool AddOrderId(SalesRecord salesRecord)
        {
            return salesRecordRepo.AddOrderId(salesRecord);
        }
       
    }
}
