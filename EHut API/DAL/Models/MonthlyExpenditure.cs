using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class MonthlyExpenditure
    {
        public int MonthlyExpenditureId { get; set; }


        [Required(ErrorMessage = "Can't be empty")]
        public int CustomerId { get; set; }



        public double Minimum { get; set; }


        [Required(ErrorMessage = "Can't be empty")]
        public double Maximum { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
    }
}
