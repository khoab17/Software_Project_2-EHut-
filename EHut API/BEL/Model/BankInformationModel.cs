using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL.Model
{
    public class BankInformationModel
    {

        public int BankInformationId { get; set; }
        public string Name { get; set; }
        public string AccountHolderName { get; set; }
        public string AccountNumber { get; set; }
        public string BranchName { get; set; }
        public string RoutingNumber { get; set; }
        public string ChequeBookImage { get; set; }
    }
}
