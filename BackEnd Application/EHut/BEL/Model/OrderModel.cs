using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL.Model
{
    public class OrderModel
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public System.DateTime Date { get; set; }
        public double AddedSubtotal { get; set; }
        public int DiscountId { get; set; }
        public double GrandTotal { get; set; }
        public int DeliverymanId { get; set; }
        public bool DeliveryStatus { get; set; }

    }
}
