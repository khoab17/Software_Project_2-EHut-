using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class ShopReview
    {
        public int ShopReviewId { get; set; }

        [Required(ErrorMessage = "Can't be empty")]
        public int ShopId { get; set; }

        public int ProductId { get; set; }


        [Required(ErrorMessage = "Can't be empty")]
        public int CustomerId { get; set; }


        [Required(ErrorMessage = "Can't be empty")]
        public string Comment { get; set; }

        public int Ratting { get; set; }

        public string Date { get; set; }
        
        public string ImageSource { get; set; }



        [ForeignKey("ShopId")]
        public Shop Shop { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

    }
}
