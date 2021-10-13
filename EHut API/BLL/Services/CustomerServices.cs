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
    public class CustomerServices
    {
        CustomerRepo customerRepo = new CustomerRepo();

        public List<CustomerModel> GetAll()
        {
            var data = customerRepo.GetAll();
            return Mapper<Customer, CustomerModel>.ListOfEntityToModel(data);

        }

        public CustomerModel Get(int id)
        {
            var data = customerRepo.Get(id);
            return Mapper<Customer, CustomerModel>.EntityToModel(data);
        }

        public CustomerModel GetByPhone(string phone)
        {
            var data = customerRepo.GetByPhone(phone);
            return Mapper<Customer, CustomerModel>.EntityToModel(data);
        }

        public CustomerModel Insert(CustomerModel model)
        {
            var entity = Mapper<Customer, CustomerModel>.ModelToEntity(model);
            bool done = customerRepo.Insert(entity);

            if (done)
            {
                return model;
            }
            else
                return null;
        }


        public CustomerModel Update(CustomerModel model)
        {
            var entity = Mapper<Customer, CustomerModel>.ModelToEntity(model);
            bool done = customerRepo.Update(entity);
            if (done)
            {
                return model;
            }
            else
                return null;
        }

        public bool Delete(int id)
        {
            bool done = customerRepo.Delete(id);
            if (done)
            {
                return true;
            }
            else
                return false;
        }
    }
}
