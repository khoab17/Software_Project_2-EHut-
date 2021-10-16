﻿using BEL.Model;
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

            if (done)
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
