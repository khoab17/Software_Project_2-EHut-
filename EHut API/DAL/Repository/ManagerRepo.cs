using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class ManagerRepo : Repository<Manager>
    {
        public override Manager GetByPhone(string phone)
        {
            return context.Managers.Where(x => x.Phone == phone).FirstOrDefault();
        }

    }
}
