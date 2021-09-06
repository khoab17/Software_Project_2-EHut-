using BEL.Model;
using DAL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class DeliverymanServices
    {
        DeliverymanRepo deliverymanRepo = new DeliverymanRepo();

        public List<DeliverymanModel> GetAll()
        {
            var temp = deliverymanRepo.GetAll();
            var data = AutoMapper.Mapper.Map<List<Deliveryman>, List<DeliverymanModel>>(temp);//---------------to map deliverymanModel to Admin
            return data;
        }

        public DeliverymanModel Get(int id)
        {
            var temp = deliverymanRepo.Get(id);
            var data = AutoMapper.Mapper.Map<Deliveryman, DeliverymanModel>(temp);
            return data;
        }

        public DeliverymanModel GetByPhone(string phone)                     //--------------to get User By Phone number
        {
            var temp = deliverymanRepo.GetByPhone(phone);
            var data = AutoMapper.Mapper.Map<Deliveryman, DeliverymanModel>(temp); 
            return data;
        }

        public DeliverymanModel Insert(DeliverymanModel deliverymanModel)
        {
            Deliveryman deliveryman = AutoMapper.Mapper.Map<DeliverymanModel, Deliveryman>(deliverymanModel);
            bool done = deliverymanRepo.Insert(deliveryman);

            if (done)
            {
                return deliverymanModel;
            }
            else
                return null;
        }

        
        public DeliverymanModel Update(DeliverymanModel deliverymanModel)
        {
            Deliveryman deliveryman = AutoMapper.Mapper.Map<DeliverymanModel, Deliveryman>(deliverymanModel);//---------------to map admin to DeliverymanModel
            bool done = deliverymanRepo.Update(deliveryman);
            if (done)
            {
                return deliverymanModel;
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
