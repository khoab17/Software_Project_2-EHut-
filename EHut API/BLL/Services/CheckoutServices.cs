using DAL.Models;
using DAL.Repository;
using DAL.View_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CheckoutServices
    {
        CheckoutRepo checkoutRepo = new CheckoutRepo();

        DiscountServices discountServices = new DiscountServices();
        OrderServices orderServices = new OrderServices();
        Order doneOrder = null;
        SalesRecord doneSales = null;
        public Order Insert(CheckoutViewModel viewModel)
        {
            ProductServices productServices = new ProductServices();
            List<SalesRecord> salesRecords = new List<SalesRecord>();
            double AddedSubTotal = 0.0;

            ///
            /// Availablity of all Products should be checked before procceding to the next part
            ///



            for (int i = 0; i < viewModel.Products.Count; i++)
            {
                SalesRecord model = new SalesRecord();
                model.CustomerId = viewModel.CustomerId;
                model.ShopId = viewModel.ShopId;
                model.ProductId = viewModel.Products[i].ProductId;
                model.Quantity = viewModel.Products[i].Qantity;
                model.Date = DateTime.Now;
                model.Price = viewModel.Products[i].Price;
                model.Subtotal = viewModel.Products[i].GetSubTotal();
                salesRecords.Add(model);            // Inserting Sales Recors to List

                AddedSubTotal+=viewModel.Products[i].GetSubTotal();     // Adding subTotals from each Product
            }

            
            /// Creating New Order to Insert into Table[Orders]
            double discount = discountServices.Get(viewModel.DiscountId).Percentage;

            Order order = new Order();
            order.CustomerId = viewModel.CustomerId;
            order.Date = DateTime.Now;
            order.AddedSubtotal = AddedSubTotal;
            order.DiscountId = viewModel.DiscountId;
            order.GrandTotal = AddedSubTotal - discount;
            order.DeliverymanId = -1;       // "-1 to denote invalid"
            order.DeliveryStatus = false;

            doneOrder = orderServices.Insert(order);   //Inserting to [Orders]



            ///  Inserting Sales Records to Table[Sales Record] without OrderId or OrderId as -1;
            if (doneOrder!=null)
            {
                int orderId = orderServices.GetOrderId(viewModel.CustomerId);
                foreach (var item in salesRecords)
                {
                    item.OrderId = orderId;
                    doneSales = checkoutRepo.Insert(item);
                }
            }
            

            if (doneSales!=null)
            {
                return doneOrder;
            }
            else
                return null;
        }

       
    }
}
