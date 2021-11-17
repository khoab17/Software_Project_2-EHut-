
using DAL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// Please read the DocumentConventions.txt first

namespace BLL.Services
{
    public class BankInformationServices
    {
        BankInformationRepo bankInformationRepo = new BankInformationRepo();

        
        public List<BankInformation> GetAll()
        {
            var data = bankInformationRepo.GetAll();
            return data;
        }
        
        public BankInformation Get(int id)
        {
            var data = bankInformationRepo.Get(id);
            return data;
        }

      
        public BankInformation Insert(BankInformation model)
        {
            var entity = model;
            bool done = bankInformationRepo.Insert(entity);

            if (done)
            {
                return model;
            }
            else
                return null;
        }


        public BankInformation Update(BankInformation model)
        {
            var entity = model;  
            bool done = bankInformationRepo.Update(entity);
            if (done)
            {
                return model;
            }
            else
                return null;
        }

        public bool Delete(int id)
        {
            bool done = bankInformationRepo.Delete(id);
            if (done)
            {
                return true;
            }
            else
                return false;
        }

    }
}
