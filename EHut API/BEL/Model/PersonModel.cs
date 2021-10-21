using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL.Model
{
    public class PersonModel
    {
        [Required(ErrorMessage = "Can't be empty")]
        [StringLength(50, ErrorMessage = "Can't be more than 50 character", MinimumLength = 5)]
        public string Name { get; set; }


        [Required(ErrorMessage = "Can't be empty")]
        [StringLength(150, ErrorMessage = "Can't be more than 50 character", MinimumLength = 5)]
        public string Address { get; set; }


        [Required(ErrorMessage = "Can't be empty")]
        [Phone(ErrorMessage = "Phone Number is not valid")]
        [MaxLength(50, ErrorMessage = "Can't be more than 50 character")]
        [Index(IsUnique = true)]
        public string Phone { get; set; }


        [Required(ErrorMessage = "Can't be empty")]
        [EmailAddress(ErrorMessage = "Email address is not valid")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Can't be empty")]
        public string Gender { get; set; }


        [Required(ErrorMessage = "Can't be empty")]
        public string Password { get; set; }

        public string Image { get; set; }
    }
}
