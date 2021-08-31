using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL.Model
{
    public class CustomerModel: PersonModel
    {
        public int CustomerId { get; set; }
        public string Occupation { get; set; }
        public int NumberOfFamilyMemberAdult { get; set; }
        public int NumberOfFamilyMemberChild { get; set; }
        public int NumberOfDeliveryGrocery { get; set; }
        public int NumberOfDeliveryVegitables { get; set; }
        public string DeliveryDay { get; set; }
        public string DeliveryTime { get; set; }
       
    }
}
