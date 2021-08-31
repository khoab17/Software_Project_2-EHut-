using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL.Model
{
    public class SalesRecordModel
    {
        public int SalesRecordId { get; set; }
        public int CustomerId { get; set; }
        public System.DateTime Date { get; set; }
        public int ProductId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double Subtotal { get; set; }
        public int ShopId { get; set; }
        public int OrderId { get; set; }
    }
}
