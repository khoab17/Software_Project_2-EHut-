using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class CredentialService:Repository<Credential>
    {
        public override Credential GetByPhone(string phone)
        {
            return context.Credentials.Where(x => x.Phone == phone).FirstOrDefault();
        }
        public Credential GetByUserId(int id)
        {
            return context.Credentials.Where(x => x.UserId == id).FirstOrDefault();
        }
    }
}
