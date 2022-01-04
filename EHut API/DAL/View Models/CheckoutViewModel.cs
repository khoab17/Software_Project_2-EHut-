using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.View_Models
{
    public class CheckoutViewModel
    {
        public int CustomerId { get; set; }
        public int ShopId { get; set; }
        public int DiscountId { get; set; }
        public List<ProductViewModel> Products { get; set; }

    }

    //public class ProductViewModel
    //{
    //    private double subTotal;
    //    public int ProductId { get; set; }
    //    public double Price { get; set; }
    //    public int Qantity { get; set; }
    //    //public double SubTotal=Price*Qantity;
    //    public double GetSubTotal()
    //    {
    //        subTotal = Price * Qantity;
    //        return subTotal;
    //    }
    //}
}
