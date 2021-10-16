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
    public class DeliverymanReviewServices
    {
        DeliverymanReviewRepo repo = new DeliverymanReviewRepo();
        public List<DeliverymanReviewModel> GetAll()
        {
            var data = repo.GetAll();
            return Mapper<DeliverymanReview, DeliverymanReviewModel>.ListOfEntityToModel(data);
        }

        public DeliverymanReviewModel Get(int id)
        {
            var data = repo.Get(id);
            return Mapper<DeliverymanReview, DeliverymanReviewModel>.EntityToModel(data);
        }

        public DeliverymanReviewModel GetByPhone(string phone)
        {
            var data = repo.GetByPhone(phone);
            return Mapper<DeliverymanReview, DeliverymanReviewModel>.EntityToModel(data);
        }

        public DeliverymanReviewModel Insert(DeliverymanReviewModel model)
        {
            var entity = Mapper<DeliverymanReview, DeliverymanReviewModel>.ModelToEntity(model);
            bool done = repo.Insert(entity);

            if (done)
            {
                return model;
            }
            else
                return null;
        }


        public DeliverymanReviewModel Update(DeliverymanReviewModel model)
        {
            var entity = Mapper<DeliverymanReview, DeliverymanReviewModel>.ModelToEntity(model);
            bool done = repo.Update(entity);
            if (done)
            {
                return model;
            }
            else
                return null;
        }

        public bool Delete(int id)
        {
            bool done = repo.Delete(id);
            if (done)
            {
                return true;
            }
            else
                return false;
        }
    }
}
