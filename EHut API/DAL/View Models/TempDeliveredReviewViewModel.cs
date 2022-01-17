using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.View_Models
{
    public class TempDeliveredReviewViewModel
    {
        public int ProductId { get; set; }
        public double Price { get; set; }
        public string Comment { get; set; }
        public int Ratting { get; set; }
    }
}
