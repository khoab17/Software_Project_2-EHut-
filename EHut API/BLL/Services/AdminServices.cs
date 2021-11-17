
using DAL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// Please read the DocumentConventions.txt first


namespace BLL.Services
{
    public class AdminServices
    {
        
        AdminRepo adminRepo = new AdminRepo();  
        public List<Admin> GetAll()
        {
            var data = adminRepo.GetAll();
            return data;
        }

        public Admin Get(int id)
        {
            var data = adminRepo.Get(id);
            return data;
        }

        public Admin GetByPhone(string phone)                     
        {
            var data = adminRepo.GetByPhone(phone);
            return data;
        }

        public Admin Insert(Admin model)
        {
            var entity = model; 
            bool done = adminRepo.Insert(entity);

            //get the model just inserted
            CredentialServices credentialServices = new CredentialServices();
            var temp = this.GetByPhone(model.Phone);
            //insert in credential table
            Credential credential = new Credential();
            credential.Password = temp.Password;
            credential.Phone = temp.Phone;
            credential.Role = "Admin";
            credential.UserId = temp.AdminId;
            var cred = credentialServices.Insert(credential);

            if (done && cred!=null)
            {
                model.AdminId = credential.UserId;
                return model;
            }
            else
                return null;
        }


        public Admin Update(Admin model)
        {
            var entity = model;  
            bool done = adminRepo.Update(entity);
            if (done)
            {
                return model;
            }
            else
                return null;
        }

        public bool Delete(int id)
        {
            bool done = adminRepo.Delete(id);
            if (done)
            {
                return true;
            }
            else
                return false;
        }
    }
}
