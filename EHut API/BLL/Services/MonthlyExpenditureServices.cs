
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
        public List<MonthlyExpenditure> GetAll()
        {
            var data = repo.GetAll();
            return data;
        }

        public MonthlyExpenditure Get(int id)
        {
            var data = repo.Get(id);
            return data;
        }

        public MonthlyExpenditure GetByPhone(string phone)
        {
            var data = repo.GetByPhone(phone);
            return data;
        }

        public MonthlyExpenditure Insert(MonthlyExpenditure model)
        {
            var entity = model;
            bool done = repo.Insert(entity);

            if (done)
            {
                return model;
            }
            else
                return null;
        }


        public MonthlyExpenditure Update(MonthlyExpenditure model)
        {
            var entity = model;
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
