using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL.Model
{
    public class ProductModel
    {

        public int ProductId { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public string Details { get; set; }
        public double Warranty { get; set; }
        public double Price { get; set; }
        public bool Status { get; set; }

    }
}
