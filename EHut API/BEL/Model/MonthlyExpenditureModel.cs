using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL.Model
{
    public class MonthlyExpenditureModel
    {
        public int MonthlyExpenditureId { get; set; }
        public int CustomerId { get; set; }
        public double Minimum { get; set; }
        public double Maximum { get; set; }

    }
}
