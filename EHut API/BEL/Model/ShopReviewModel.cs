using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL.Model
{
    public class ShopReviewModel
    {
        public int ShopReviewId { get; set; }

        [Required(ErrorMessage = "Can't be empty")]
        public int ShopId { get; set; }



        [Required(ErrorMessage = "Can't be empty")]
        public int CustomerId { get; set; }


        [Required(ErrorMessage = "Can't be empty")]
        public string Comment { get; set; }


        [Required(ErrorMessage = "Can't be empty")]
        public string Image { get; set; }
    }
}
