using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Customer : Person

    {
        public int CustomerId { get; set; }


        
        [StringLength(50, ErrorMessage = "Can't be more than 50 character", MinimumLength = 1)]
        public string Occupation { get; set; }


        
        [Range(0, 10, ErrorMessage = "Member can't be less than 0 or more than 10")]
        public int NumberOfFamilyMemberAdult { get; set; }


        
        [Range(0, 10, ErrorMessage = "Member can't be less than 0 or more than 10")]
        public int NumberOfFamilyMemberChild { get; set; }

        
        [Range(0, 4, ErrorMessage = "Can't be less than 0 or more than 4")]
        public int NumberOfDeliveryGrocery { get; set; }

        
        [Range(0, 8, ErrorMessage = "Member can't be less than 0 or more than 8")]
        public int NumberOfDeliveryVegitables { get; set; }

        
        public string DeliveryDay { get; set; }


        
        public string DeliveryTime { get; set; }

    }
}
