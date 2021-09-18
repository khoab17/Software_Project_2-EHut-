using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class MasterRepo
    {
        public AdminRepo AdminRepo { get; set; }
        public ProductRepo ProductRepo { get; set; }
    }
}
