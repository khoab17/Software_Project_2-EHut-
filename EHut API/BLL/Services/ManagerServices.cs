
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
        public List<Manager> GetAll()
        {
            var data = repo.GetAll();
            return data;
        }

        public Manager Get(int id)
        {
            var data = repo.Get(id);
            return data;
        }

        public Manager GetByPhone(string phone)
        {
            var data = repo.GetByPhone(phone);
            return data;
        }

        public Manager Insert(Manager model)
        {
            var entity = model;
            bool done = repo.Insert(entity);

            CredentialServices credentialServices = new CredentialServices();
            var temp = this.GetByPhone(model.Phone);
            //insert in credential table
            Credential credential = new Credential();
            credential.Password = temp.Password;
            credential.Phone = temp.Phone;
            credential.Role = temp.ManagerialRole;
            credential.UserId = temp.ManagerId;
            var cred = credentialServices.Insert(credential);

            if (done && cred != null)
            {
                model.ManagerId = credential.UserId;
                return model;
            }
            else
                return null;
        }


        public Manager Update(Manager model)
        {
            var entity = model;
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
