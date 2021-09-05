using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL.Model
{
    public class ProductDistributionModel
    {
        public int ProductDistributionId { get; set; }

        [Required(ErrorMessage = "Can't be empty")]
        public int ProductId { get; set; }


        [Required(ErrorMessage = "Can't be empty")]
        public int ShopId { get; set; }


        [Required(ErrorMessage = "Can't be empty")]
        public int Quantity { get; set; }


        [Required(ErrorMessage = "Can't be empty")]
        public bool Status { get; set; }
    }
}
