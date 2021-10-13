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
    public class DeliverymanServices
    {
        DeliverymanRepo deliverymanRepo = new DeliverymanRepo();

        public List<DeliverymanModel> GetAll()
        {
            var data = deliverymanRepo.GetAll();
            return Mapper<Deliveryman, DeliverymanModel>.ListOfEntityToModel(data);
        }

        public DeliverymanModel Get(int id)
        {
            var data = deliverymanRepo.Get(id);
            return Mapper<Deliveryman, DeliverymanModel>.EntityToModel(data);
        }

        public DeliverymanModel GetByPhone(string phone)                     
        {
            var data = deliverymanRepo.GetByPhone(phone);
            return Mapper<Deliveryman, DeliverymanModel>.EntityToModel(data);
        }

        public DeliverymanModel Insert(DeliverymanModel model)
        {
           var entity = Mapper<Deliveryman, DeliverymanModel>.ModelToEntity(model);
            bool done = deliverymanRepo.Insert(entity);

            if (done)
            {
                return model;
            }
            else
                return null;
        }

        
        public DeliverymanModel Update(DeliverymanModel model)
        {
            var entity = Mapper<Deliveryman, DeliverymanModel>.ModelToEntity(model);
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
