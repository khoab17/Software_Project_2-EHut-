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
    public class ShopReviewServices
    {
        ShopReviewRepo repo = new ShopReviewRepo();
        public List<ShopReviewModel> GetAll()
        {
            var data = repo.GetAll();
            return Mapper<ShopReview, ShopReviewModel>.ListOfEntityToModel(data);
        }

        public ShopReviewModel Get(int id)
        {
            var data = repo.Get(id);
            return Mapper<ShopReview, ShopReviewModel>.EntityToModel(data);
        }

        public ShopReviewModel GetByPhone(string phone)
        {
            var data = repo.GetByPhone(phone);
            return Mapper<ShopReview, ShopReviewModel>.EntityToModel(data);
        }

        public ShopReviewModel Insert(ShopReviewModel model)
        {
            var entity = Mapper<ShopReview, ShopReviewModel>.ModelToEntity(model);
            bool done = repo.Insert(entity);

            if (done)
            {
                return model;
            }
            else
                return null;
        }


        public ShopReviewModel Update(ShopReviewModel model)
        {
            var entity = Mapper<ShopReview, ShopReviewModel>.ModelToEntity(model);
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
