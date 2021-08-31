using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL.Model
{
    public class DeliverymanModel
    {

        public int DeliveryManId { get; set; }
        public string Nid { get; set; }
        public bool Status { get; set; }
        public double Rating { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
    }
}
