using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL.Model
{
    public class ShopReviewModel
    {
        public int ShopReviewId { get; set; }
        public int ShopId { get; set; }
        public int CustomerId { get; set; }
        public string Comment { get; set; }
        public string Image { get; set; }
    }
}
