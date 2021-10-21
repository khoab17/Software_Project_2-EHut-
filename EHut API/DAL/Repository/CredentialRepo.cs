using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class CredentialRepo:Repository<Credential>
    {
        public override Credential GetByPhone(string phone)
        {
            return context.Credentials.Where(x => x.Phone == phone).FirstOrDefault();
        }
    }
}
