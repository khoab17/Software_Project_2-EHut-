using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Shop
    {
        public Shop()
        {
            ProductDistributions = new HashSet<ProductDistribution>();
        }

        public int ShopId { get; set; }

        [Required(ErrorMessage = "Can't be empty")]
        [StringLength(50, ErrorMessage = "Can't be more than 50 character", MinimumLength = 5)]
        public string Name { get; set; }


        [Required(ErrorMessage = "Can't be empty")]
        public string ShopManager { get; set; }


        [Required(ErrorMessage = "Can't be empty")]
        public string Address { get; set; }


        [Required(ErrorMessage = "Can't be empty")]
        [Phone(ErrorMessage = "Phone Number is not valid")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Can't be empty")]
        [EmailAddress(ErrorMessage = "Email address is not valid")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Can't be empty")]
        public int BankInformationId { get; set; }


        [Required(ErrorMessage = "Can't be empty")]
        public bool Status { get; set; }
        public int Rating { get; set; }
        public double TotalSold { get; set; }
        public double TotalRecievedPayment { get; set; }

        [ForeignKey("BankInformationId")]
        public BankInformation BankInformation { get; set; }

        public ICollection<ProductDistribution> ProductDistributions { get; set; }

    }
}
