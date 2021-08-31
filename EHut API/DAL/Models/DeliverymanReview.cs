using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class DeliverymanReview
    {
        public int DeliveryManReviewId { get; set; }

        [Required(ErrorMessage = "Can't be empty")]
        public int DeliveryManId { get; set; }


        [Required(ErrorMessage = "Can't be empty")]
        public int CustomerId { get; set; }


        public string Comment { get; set; }
        [ForeignKey("DeliveryManId")]
        public Deliveryman Deliveryman { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
    }
}
