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
       
        public override Admin GetByPhone(string phone)
        {
            return context.Admins.Where(x => x.Phone == phone).FirstOrDefault();
        }

        public new  bool Insert(Admin entity)
        {
            context.Admins.Add(entity);
           
                if (context.SaveChanges() > 0)
                {
                    return true;
                }
                else
                    return false;

        }
    }
}
