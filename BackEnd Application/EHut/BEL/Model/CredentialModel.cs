using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL.Model
{
    public class CredentialModel
    {
        public int CredentialId { get; set; }
        public int UserId { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }

       // public virtual AdminModel Admin { get; set; }
       // public virtual Customer Customer { get; set; }
      //  public virtual Manager Manager { get; set; }
    }
}
