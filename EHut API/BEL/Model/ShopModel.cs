using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL.Model
{
    public class ShopModel
    {
        public int ShopId { get; set; }
        public string Name { get; set; }
        public string ShopManager { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int BankInformationId { get; set; }
        public bool Status { get; set; }
        public int Rating { get; set; }
        public double TotalSold { get; set; }
        public double TotalRecievedPayment { get; set; }

    }
}
