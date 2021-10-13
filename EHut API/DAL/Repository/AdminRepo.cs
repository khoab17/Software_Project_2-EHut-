using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class AdminRepo:Repository<Admin>
    {
        /*public Admin GetByPhone(string phone)
        {
            return context.Admins.Where(x => x.Phone == phone).FirstOrDefault();
        }*/
    }
}
