using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL.Model
{
    public class DeliverymanModel:PersonModel
    {

        public int DeliveryManId { get; set; }
        public string Nid { get; set; }
        public bool Status { get; set; }
        public double Rating { get; set; }
       
    }
}
