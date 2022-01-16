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


        public Order Insert(List<CheckoutViewModel> viewModel)
        {
            ProductServices productServices = new ProductServices();
            List<SalesRecord> salesRecords = new List<SalesRecord>();
            double AddedSubTotal = 0.0;

            ///
            /// Availablity of all Products should be checked before procceding to the next part
            ///

            foreach (var item in viewModel)
            {
                for (int i = 0; i < item.Products.Count; i++)
                {
                    SalesRecord model = new SalesRecord();
                    model.CustomerId = item.CustomerId;
                    model.ShopId = item.ShopId;
                    model.ProductId = item.Products[i].ProductId;
                    model.Quantity = item.Products[i].Qantity;
                    model.Date = DateTime.Now;
                    model.Price = item.Products[i].Price;
                    model.Subtotal = item.Products[i].GetSubTotal();
                    model.Status = "Pending";
                    salesRecords.Add(model);            // Inserting Sales Recors to List

                    AddedSubTotal += item.Products[i].GetSubTotal();     // Adding subTotals from each Product

                }
            }

            /// Creating New Order to Insert into Table[Orders]
            double discount = discountServices.Get(1).Percentage;

            foreach (var item in viewModel)
            {
                Order order = new Order();
                order.CustomerId = item.CustomerId;
                order.Date = DateTime.Now;
                order.AddedSubtotal = AddedSubTotal;
                order.DiscountId = item.DiscountId;
                order.GrandTotal = AddedSubTotal - discount;
                order.DeliverymanId = -1;       // "-1 to denote invalid"
                order.DeliveryStatus = false;

                doneOrder = orderServices.Insert(order);   //Inserting to [Orders]
            }



            ///  Inserting Sales Records to Table[Sales Record] without OrderId or OrderId as -1;
            if (doneOrder != null)
            {
                foreach (var item in viewModel)
                {
                    int orderId = orderServices.GetOrderId(item.CustomerId);
                    foreach (var sale in salesRecords)
                    {
                        sale.OrderId = orderId;
                        doneSales = checkoutRepo.Insert(sale);
                    }
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
