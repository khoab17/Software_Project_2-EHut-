using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class BankInformation
    {
        [Required(ErrorMessage = "Can't be empty")]
        public int BankInformationId { get; set; }


        [Required(ErrorMessage = "Can't be empty")]
        [StringLength(50, ErrorMessage = "Can't be more than 50 character", MinimumLength = 5)]
        public string Name { get; set; }


        [Required(ErrorMessage = "Can't be empty")]
        public string AccountHolderName { get; set; }


        [Required(ErrorMessage = "Can't be empty")]
        public string AccountNumber { get; set; }


        [Required(ErrorMessage = "Can't be empty")]
        public string BranchName { get; set; }


        [Required(ErrorMessage = "Can't be empty")]
        public string RoutingNumber { get; set; }

        public string ChequeBookImage { get; set; }
    }
}
