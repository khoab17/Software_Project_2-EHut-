
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
    public class DeliverymanServices
    {
        DeliverymanRepo deliverymanRepo = new DeliverymanRepo();

        public List<Deliveryman> GetAll()
        {
            var data = deliverymanRepo.GetAll();
            return data;
        }

        public Deliveryman Get(int id)
        {
            var data = deliverymanRepo.Get(id);
            return data;
        }

        public Deliveryman GetByPhone(string phone)                     
        {
            var data = deliverymanRepo.GetByPhone(phone);
            return data;
        }

        public Deliveryman Insert(Deliveryman model)
        {
           var entity = model;
            bool done = deliverymanRepo.Insert(entity);

            CredentialServices credentialServices = new CredentialServices();
            var temp = this.GetByPhone(model.Phone);
            //insert in credential table
            Credential credential = new Credential();
            credential.Password = temp.Password;
            credential.Phone = temp.Phone;
            credential.Role = "Deliveryman";
            credential.UserId = temp.DeliveryManId;
            var cred = credentialServices.Insert(credential);

            if (done && cred != null)
            {
                model.DeliveryManId = credential.UserId;
                return model;
            }
            else
                return null;
        }

        
        public Deliveryman Update(Deliveryman model)
        {
            var entity = model;
            bool done = deliverymanRepo.Update(entity);
            if (done)
            {
                return model;
            }
            else
                return null;
        }

        public bool Delete(int id)
        {
            bool done = deliverymanRepo.Delete(id);
            if (done)
            {
                return true;
            }
            else
                return false;
        }

    }
}
