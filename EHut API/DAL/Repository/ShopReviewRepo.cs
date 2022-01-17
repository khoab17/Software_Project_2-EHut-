using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class ShopReviewRepo : Repository<ShopReview>
    {
        public List<ShopReview> ReviewsByShopId (int shopId)
        {
            return context.ShopReviews.Where(x=>x.ShopId == shopId).ToList();
        }
        public List<ShopReview> ReviewsByProductId(int pId)
        {
            return context.ShopReviews.Where(x => x.ProductId == pId).ToList();
        }

        public List<ShopReview> ReviewsByProductIdAndShopId(int shopId, int pId)
        {
            return context.ShopReviews.Where(x => x.ShopId == shopId &&  x.ProductId == pId).ToList();
        }

    }
}
