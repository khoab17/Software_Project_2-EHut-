using BEL.Model;
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

        
        public List<BankInformationModel> GetAll()
        {
            var data = bankInformationRepo.GetAll();
            return Mapper<BankInformation, BankInformationModel>.ListOfEntityToModel(data);
        }
        
        public BankInformationModel Get(int id)
        {
            var data = bankInformationRepo.Get(id);
            return Mapper<BankInformation, BankInformationModel>.EntityToModel(data);
        }

      
        public BankInformationModel Insert(BankInformationModel model)
        {
            var entity = Mapper<BankInformation, BankInformationModel>.ModelToEntity(model);
            bool done = bankInformationRepo.Insert(entity);

            if (done)
            {
                return model;
            }
            else
                return null;
        }


        public BankInformationModel Update(BankInformationModel model)
        {
            var entity = Mapper<BankInformation, BankInformationModel>.ModelToEntity(model);  
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
