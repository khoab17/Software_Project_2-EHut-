using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL.Model
{
    public class DeliverymanReviewModel
    {
        public int DeliveryManReviewId { get; set; }

        [Required(ErrorMessage = "Can't be empty")]
        public int DeliveryManId { get; set; }


        [Required(ErrorMessage = "Can't be empty")]
        public int CustomerId { get; set; }


        public string Comment { get; set; }
        
    }
}
