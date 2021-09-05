using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL.Model
{
    public class ProductModel
    {

        public int ProductId { get; set; }


        [Required(ErrorMessage = "Can't be empty")]
        [StringLength(50, ErrorMessage = "Can't be more than 50 character", MinimumLength = 5)]
        public string Name { get; set; }


        [Required(ErrorMessage = "Can't be empty")]
        public int BrandId { get; set; }


        [Required(ErrorMessage = "Can't be empty")]
        public int CategoryId { get; set; }


        public string Details { get; set; }



        [Required(ErrorMessage = "Can't be empty")]
        public double Warranty { get; set; }


        [Required(ErrorMessage = "Can't be empty")]
        public double Price { get; set; }


        [Required(ErrorMessage = "Can't be empty")]
        public bool Status { get; set; }

    }
}
