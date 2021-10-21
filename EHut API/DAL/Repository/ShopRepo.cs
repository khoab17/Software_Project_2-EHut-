using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class ShopRepo : Repository<Shop>
    {
        public override Shop GetByPhone(string phone)
        {
            return context.Shops.Where(x => x.Phone == phone).FirstOrDefault();
        }
    }
}
