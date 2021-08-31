using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL.Model
{
    public class DiscountModel
    {
        public int DiscountId { get; set; }
        public int ProviderId { get; set; }
        public string Name { get; set; }
        public double Percentage { get; set; }

    }
}
