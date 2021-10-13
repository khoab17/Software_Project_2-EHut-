using BEL.Model;
using DAL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class BankInformationServices
    {
        BankInformationRepo bankInformationRepo = new BankInformationRepo();

        private BankInformationModel EntityToModelMapper(BankInformation entity)
        {
            BankInformationModel bankInformationModel = AutoMapper.Mapper.Map<BankInformation, BankInformationModel>(entity);
            return bankInformationModel;
        }
        public List<BankInformationModel> GetAll()
        {
            var temp = bankInformationRepo.GetAll();
            var data = AutoMapper.Mapper.Map<List<BankInformation>, List<BankInformationModel>>(temp);//---------------to map adminModel to Admin
            return data;
        }
        
        public BankInformationModel Get(int id)
        {
            var temp = bankInformationRepo.Get(id);
            return EntityToModelMapper(temp);
        }

      
        public BankInformationModel Insert(BankInformationModel entity)
        {
            BankInformation bankInformation  = AutoMapper.Mapper.Map<BankInformationModel, BankInformation>(entity);
            bool done = bankInformationRepo.Insert(bankInformation);

            if (done)
            {
                return entity;
            }
            else
                return null;
        }


        public BankInformationModel Update(BankInformationModel entityModel)
        { 
            BankInformation bankInformation = AutoMapper.Mapper.Map<BankInformationModel, BankInformation>(entityModel);//---------------to map admin to AdminModel
            bool done = bankInformationRepo.Update(bankInformation);
            if (done)
            {
                return entityModel;
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
