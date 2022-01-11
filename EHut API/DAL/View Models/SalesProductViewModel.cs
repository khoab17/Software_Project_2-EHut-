using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.View_Models
{
    public class SalesProductViewModel
    {
        public int SalesRecordId { get; set; }
        public Product Product { get; set; }
        public int quantity { get; set; }
    }
}
