
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
        CredentialServices credentialServices = new CredentialServices();
        public List<Customer> GetAll()
        {
            var data = customerRepo.GetAll();
            return data;

        }

        public Customer Get(int id)
        {
            var data = customerRepo.Get(id);
            return data;
        }

        public Customer GetByPhone(string phone)
        {
            var data = customerRepo.GetByPhone(phone);
            return data;
        }

        public Customer Insert(Customer model)
        {
            var entity = model;
            bool done = customerRepo.Insert(entity);

            CredentialServices credentialServices = new CredentialServices();
            var temp = this.GetByPhone(model.Phone);
            //insert in credential table
            Credential credential = new Credential();
            credential.Password = temp.Password;
            credential.Phone = temp.Phone;
            credential.Role = "Customer";
            credential.UserId = temp.CustomerId;
            var cred = credentialServices.Insert(credential);

            if (done && cred != null)
            {
                model.CustomerId = credential.UserId;
                return model;
            }
            else
                return null;
        }


        public Customer Update(Customer model)
        {
            var entity = model;
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
