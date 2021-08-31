using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Manager : Person
    {
        public int ManagerId { get; set; }


        [Required(ErrorMessage = "Can't be empty")]
        public string ManagerialRole { get; set; }
    }
}
