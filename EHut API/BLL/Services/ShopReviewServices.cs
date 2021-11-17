
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
        public List<ShopReview> GetAll()
        {
            var data = repo.GetAll();
            return data;
        }

        public ShopReview Get(int id)
        {
            var data = repo.Get(id);
            return data;
        }

        public ShopReview GetByPhone(string phone)
        {
            var data = repo.GetByPhone(phone);
            return data;
        }

        public ShopReview Insert(ShopReview model)
        {
            var entity = model;
            bool done = repo.Insert(entity);

            if (done)
            {
                return model;
            }
            else
                return null;
        }


        public ShopReview Update(ShopReview model)
        {
            var entity = model;
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
