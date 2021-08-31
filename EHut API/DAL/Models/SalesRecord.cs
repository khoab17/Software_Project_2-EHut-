using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class SalesRecord
    {
        public int SalesRecordId { get; set; }


        [Required(ErrorMessage = "Can't be empty")]
        public int CustomerId { get; set; }


        [Required(ErrorMessage = "Can't be empty")]
        public DateTime Date { get; set; }


        [Required(ErrorMessage = "Can't be empty")]
        public int ProductId { get; set; }


        [Required(ErrorMessage = "Can't be empty")]
        public double Price { get; set; }


        [Required(ErrorMessage = "Can't be empty")]
        public int Quantity { get; set; }


        [Required(ErrorMessage = "Can't be empty")]
        public double Subtotal { get; set; }


        [Required(ErrorMessage = "Can't be empty")]
        public int ShopId { get; set; }
        public int OrderId { get; set; }



        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        [ForeignKey("ShopId")]
        public Shop Shop { get; set; }
        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }

    }
}
