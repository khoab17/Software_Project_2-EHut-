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
    public class ShopServices
    {
        ShopRepo repo = new ShopRepo();
        public List<SalesRecordModel> GetAll()
        {
            var data = repo.GetAll();
            return Mapper<SalesRecord, SalesRecordModel>.ListOfEntityToModel(data);
        }

        public SalesRecordModel Get(int id)
        {
            var data = repo.Get(id);
            return Mapper<SalesRecord, SalesRecordModel>.EntityToModel(data);
        }

        public SalesRecordModel GetByPhone(string phone)
        {
            var data = repo.GetByPhone(phone);
            return Mapper<SalesRecord, SalesRecordModel>.EntityToModel(data);
        }

        public SalesRecordModel Insert(SalesRecordModel model)
        {
            var entity = Mapper<SalesRecord, SalesRecordModel>.ModelToEntity(model);
            bool done = repo.Insert(entity);

            if (done)
            {
                return model;
            }
            else
                return null;
        }


        public SalesRecordModel Update(SalesRecordModel model)
        {
            var entity = Mapper<SalesRecord, SalesRecordModel>.ModelToEntity(model);
            bool done = repo.Update(entity);
            if (done)
            {
                return model;
            }
            else
                return null;
        }

        public bool Delete(int id)
        {
            bool done = repo.Delete(id);
            if (done)
            {
                return true;
            }
            else
                return false;
        }
    }
}
