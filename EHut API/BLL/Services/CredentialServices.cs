
using DAL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CredentialServices
    {
        CredentialService credentialRepo = new CredentialService();
        public List<Credential> GetAll()
        {
            var data = credentialRepo.GetAll();
            return data;

        }

        public Credential Get(int id)
        {
            var data = credentialRepo.Get(id);
            return data;
        }

        public Credential GetByPhone(string phone)
        {
            var data = credentialRepo.GetByPhone(phone);
            return data;
        }

        public Credential GetByUserId(int id)
        {
            return credentialRepo.GetByUserId(id);
        }


        public Credential Insert(Credential model)
        {
            var entity = model;
            bool done = credentialRepo.Insert(entity);

            if (done)
            {
                return model;
            }
            else
                return null;
        }


        public Credential Update(Credential model)
        {
            var entity = model; ;
            bool done = credentialRepo.Update(entity);
            if (done)
            {
                return model;
            }
            else
                return null;
        }

        public bool Delete(int id)
        {
            bool done = credentialRepo.Delete(id);
            if (done)
            {
                return true;
            }
            else
                return false;
        }
    }
}
