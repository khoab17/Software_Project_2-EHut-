using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.View_Models
{
    public class ProductViewModel
    {
        private double subTotal;
        public int ProductId { get; set; }
        public double Price  { get; set; }
        public int Quantity { get; set; }
        //public double SubTotal=Price*Qantity;
        public double GetSubTotal()
        {
            subTotal = Price * Quantity;
            return subTotal;
        }
    }
}
