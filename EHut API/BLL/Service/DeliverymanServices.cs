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
        public DeliverymanModel Get(int id)
        {
            var temp = deliverymanRepo.Get(id);
            var data = AutoMapper.Mapper.Map<Deliveryman, DeliverymanModel>(temp);
            return data;
        }
    }
}
