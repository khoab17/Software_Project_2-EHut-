using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Brand
    {
        public Brand()
        {
            Products = new HashSet<Product>();
        }
        public int BrandId { get; set; }


        [Required(ErrorMessage = "Can't be empty")]
        [StringLength(50, ErrorMessage = "Can't be more than 50 character", MinimumLength = 1)]
        public string Name { get; set; }



        public ICollection<Product> Products { get; set; }
    }
}
