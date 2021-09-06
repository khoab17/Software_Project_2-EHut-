using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class DeliverymanRepo : Repository<Deliveryman>
    {
        public Deliveryman GetByPhone(string phone)
        {
            return context.Deliverymen.Where(x => x.Phone == phone).FirstOrDefault();
        }
    }
}
