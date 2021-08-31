using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL.Model
{
    public class CustomerModel
    {
        public int CustomerId { get; set; }
        public string Occupation { get; set; }
        public int NumberOfFamilyMemberAdult { get; set; }
        public int NumberOfFamilyMemberChild { get; set; }
        public int NumberOfDeliveryGrocery { get; set; }
        public int NumberOfDeliveryVegitables { get; set; }
        public string DeliveryDay { get; set; }
        public string DeliveryTime { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
    }
}
