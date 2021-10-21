using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Credential
    {
        public int CredentialId { get; set; }


        [Required(ErrorMessage = "Can't be empty")]
        public int UserId { get; set; }


        [Phone]
        [MaxLength(50, ErrorMessage = "Can't be more than 50 character")]
        [Index(IsUnique = true)]
        public string Phone { get; set; }


        [Required(ErrorMessage = "Can't be empty")]
        public string Role { get; set; }
        public string Password { get; set; }

        /*[ForeignKey("UserId")]
        public Admin Admin { get; set; }
        [ForeignKey("UserId")]
        public Manager Manager { get; set; }
        [ForeignKey("UserId")]
        public Customer Customer { get; set; }*/
    }
}
