using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL.Model
{
    public class OrderModel
    {
        public int OrderId { get; set; }


        [Required(ErrorMessage = "Can't be empty")]
        public int CustomerId { get; set; }


        [Required(ErrorMessage = "Can't be empty")]
        public DateTime Date { get; set; }


        [Required(ErrorMessage = "Can't be empty")]
        public double AddedSubtotal { get; set; }

        [Required(ErrorMessage = "Can't be empty")]
        public int DiscountId { get; set; }

        [Required(ErrorMessage = "Can't be empty")]
        public double GrandTotal { get; set; }


        public int DeliverymanId { get; set; }



        [Required(ErrorMessage = "Can't be empty")]
        public bool DeliveryStatus { get; set; }

    }
}
