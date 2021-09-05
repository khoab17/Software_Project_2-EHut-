using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL.Model
{
    public class CustomerModel: PersonModel
    {
        public int CustomerId { get; set; }


        [Required(ErrorMessage = "Can't be empty")]
        [StringLength(50, ErrorMessage = "Can't be more than 50 character", MinimumLength = 1)]
        public string Occupation { get; set; }


        [Required(ErrorMessage = "Can't be empty")]
        [Range(0, 10, ErrorMessage = "Member can't be less than 0 or more than 10")]
        public int NumberOfFamilyMemberAdult { get; set; }


        [Required(ErrorMessage = "Can't be empty")]
        [Range(0, 10, ErrorMessage = "Member can't be less than 0 or more than 10")]
        public int NumberOfFamilyMemberChild { get; set; }

        [Required(ErrorMessage = "Can't be empty")]
        [Range(0, 4, ErrorMessage = "Can't be less than 0 or more than 4")]
        public int NumberOfDeliveryGrocery { get; set; }

        [Required(ErrorMessage = "Can't be empty")]
        [Range(0, 8, ErrorMessage = "Member can't be less than 0 or more than 8")]
        public int NumberOfDeliveryVegitables { get; set; }

        [Required(ErrorMessage = "Can't be empty")]
        public string DeliveryDay { get; set; }


        [Required(ErrorMessage = "Can't be empty")]
        public string DeliveryTime { get; set; }

    }
}
