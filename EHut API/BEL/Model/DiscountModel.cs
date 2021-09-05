using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL.Model
{
    public class DiscountModel
    {
        public int DiscountId { get; set; }
        [Required(ErrorMessage = "Can't be empty")]
        public int ProviderId { get; set; }


        [Required(ErrorMessage = "Can't be empty")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Can't be empty")]


        public double Percentage { get; set; }

    }
}
