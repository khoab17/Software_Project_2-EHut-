using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class CustomerRepo : Repository<Customer>
    {
        public override Customer GetByPhone(string phone)
        {
            return context.Customers.Where(x => x.Phone == phone).FirstOrDefault();
        }
    }
}
