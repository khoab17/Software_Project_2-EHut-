using BEL.Model;
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
        public List<AdminModel> GetAll()
        {
            var data = adminRepo.GetAll();
            return Mapper<Admin, AdminModel>.ListOfEntityToModel(data);
        }

        public AdminModel Get(int id)
        {
            var data = adminRepo.Get(id);
            return Mapper<Admin, AdminModel>.EntityToModel(data);
        }

        public AdminModel GetByPhone(string phone)                     
        {
            var data = adminRepo.GetByPhone(phone);
            return Mapper<Admin, AdminModel>.EntityToModel(data);
        }

        public AdminModel Insert(AdminModel model)
        {
            var entity = Mapper<Admin, AdminModel>.ModelToEntity(model);
            bool done = adminRepo.Insert(entity);

            //get the model just inserted
            CredentialServices credentialServices = new CredentialServices();
            var temp = this.GetByPhone(model.Phone);
            //insert in credential table
            CredentialModel credentialModel = new CredentialModel();
            credentialModel.Password = temp.Password;
            credentialModel.Password = temp.Phone;
            credentialModel.Role = "Admin";
            credentialModel.UserId = temp.AdminId;
            var cred = credentialServices.Insert(credentialModel);

            if (done && cred!=null)
            {
                return model;
            }
            else
                return null;
        }


        public AdminModel Update(AdminModel model)
        {
            var entity = Mapper<Admin, AdminModel>.ModelToEntity(model);  
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
