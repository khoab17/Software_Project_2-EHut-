using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Discount
    {
        public int DiscountId { get; set; }
        [Required(ErrorMessage = "Can't be empty")]
        public int ProviderId { get; set; }


        [Required(ErrorMessage = "Can't be empty")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Can't be empty")]


        public double Percentage { get; set; }
        /*[ForeignKey("ProviderId")]
        public Shop Shop { get; set; }
        [ForeignKey("ProviderId")]
        public Manager Manager { get; set; }*/
    }
}
