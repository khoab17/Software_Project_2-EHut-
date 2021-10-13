using BEL.Model;
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
        CredentialRepo credentialRepo = new CredentialRepo();
        public List<CredentialModel> GetAll()
        {
            var data = credentialRepo.GetAll();
            return Mapper<Credential, CredentialModel>.ListOfEntityToModel(data);

        }

        public CredentialModel Get(int id)
        {
            var data = credentialRepo.Get(id);
            return Mapper<Credential, CredentialModel>.EntityToModel(data);
        }



        public CredentialModel Insert(CredentialModel model)
        {
            var entity = Mapper<Credential, CredentialModel>.ModelToEntity(model);
            bool done = credentialRepo.Insert(entity);

            if (done)
            {
                return model;
            }
            else
                return null;
        }


        public CredentialModel Update(CredentialModel model)
        {
            var entity = Mapper<Credential, CredentialModel>.ModelToEntity(model);
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
