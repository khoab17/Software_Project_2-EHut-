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
    public class MonthlyExpenditureServices
    {
        MonthlyExpenditureRepo repo = new MonthlyExpenditureRepo();
        public List<MonthlyExpenditureModel> GetAll()
        {
            var data = repo.GetAll();
            return Mapper<MonthlyExpenditure, MonthlyExpenditureModel>.ListOfEntityToModel(data);
        }

        public MonthlyExpenditureModel Get(int id)
        {
            var data = repo.Get(id);
            return Mapper<MonthlyExpenditure, MonthlyExpenditureModel>.EntityToModel(data);
        }

        public MonthlyExpenditureModel GetByPhone(string phone)
        {
            var data = repo.GetByPhone(phone);
            return Mapper<MonthlyExpenditure, MonthlyExpenditureModel>.EntityToModel(data);
        }

        public MonthlyExpenditureModel Insert(MonthlyExpenditureModel model)
        {
            var entity = Mapper<MonthlyExpenditure, MonthlyExpenditureModel>.ModelToEntity(model);
            bool done = repo.Insert(entity);

            if (done)
            {
                return model;
            }
            else
                return null;
        }


        public MonthlyExpenditureModel Update(MonthlyExpenditureModel model)
        {
            var entity = Mapper<MonthlyExpenditure, MonthlyExpenditureModel>.ModelToEntity(model);
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
