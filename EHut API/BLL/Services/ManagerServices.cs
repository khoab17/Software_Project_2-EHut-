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
    public class ManagerServices
    {
        ManagerRepo repo = new ManagerRepo();
        public List<ManagerModel> GetAll()
        {
            var data = repo.GetAll();
            return Mapper<Manager, ManagerModel>.ListOfEntityToModel(data);
        }

        public ManagerModel Get(int id)
        {
            var data = repo.Get(id);
            return Mapper<Manager, ManagerModel>.EntityToModel(data);
        }

        public ManagerModel GetByPhone(string phone)
        {
            var data = repo.GetByPhone(phone);
            return Mapper<Manager, ManagerModel>.EntityToModel(data);
        }

        public ManagerModel Insert(ManagerModel model)
        {
            var entity = Mapper<Manager, ManagerModel>.ModelToEntity(model);
            bool done = repo.Insert(entity);

            CredentialServices credentialServices = new CredentialServices();
            var temp = this.GetByPhone(model.Phone);
            //insert in credential table
            CredentialModel credentialModel = new CredentialModel();
            credentialModel.Password = temp.Password;
            credentialModel.Password = temp.Phone;
            credentialModel.Role = temp.ManagerialRole;
            credentialModel.UserId = temp.ManagerId;
            var cred = credentialServices.Insert(credentialModel);

            if (done && cred != null)
            {
                return model;
            }
            else
                return null;
        }


        public ManagerModel Update(ManagerModel model)
        {
            var entity = Mapper<Manager, ManagerModel>.ModelToEntity(model);
            bool done = repo.Update(entity);
            if (done)
            {
                return model;
            }
            else
                return null;
        }

        public bool Delete(int id)
        {
            bool done = repo.Delete(id);
            if (done)
            {
                return true;
            }
            else
                return false;
        }
    }
}
