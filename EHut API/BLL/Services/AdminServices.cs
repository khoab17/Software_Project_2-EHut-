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
    public class AdminServices
    {
        AdminRepo adminRepo = new AdminRepo();  //--------------to get data from Repository
        public List<AdminModel> GetAll()
        {
            var temp = adminRepo.GetAll();
            var data = AutoMapper.Mapper.Map<List<Admin>, List<AdminModel>>(temp);//---------------to map adminModel to Admin
            return data;
        }

        public AdminModel Get(int id)
        {
            var temp = adminRepo.Get(id);
            var data = AutoMapper.Mapper.Map<Admin, AdminModel>(temp); 
            return data;
        }

        public AdminModel GetByPhone(string phone)                     //--------------to get User By Phone number
        {
            var temp = adminRepo.GetByPhone(phone);
            var data = AutoMapper.Mapper.Map<Admin, AdminModel>(temp); 
            return data;
        }

        public AdminModel Insert(AdminModel adminModel)
        {
            Admin admin = AutoMapper.Mapper.Map<AdminModel, Admin>(adminModel);
            bool done = adminRepo.Insert(admin);

            if (done)
            {
                return adminModel;
            }
            else
                return null;
        }

        
        public AdminModel Update(AdminModel adminModel)
        {
            Admin admin = AutoMapper.Mapper.Map<AdminModel, Admin>(adminModel);//---------------to map admin to AdminModel
            bool done = adminRepo.Update(admin);
            if (done)
            {
                return adminModel;
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
