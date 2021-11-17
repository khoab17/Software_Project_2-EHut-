
using DAL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class SalesRecordServices
    {
        SalesRecordRepo repo = new SalesRecordRepo();
        public List<SalesRecord> GetAll()
        {
            var data = repo.GetAll();
            return data;
        }

        public SalesRecord Get(int id)
        {
            var data = repo.Get(id);
            return data;
        }

        public SalesRecord GetByPhone(string phone)
        {
            var data = repo.GetByPhone(phone);
            return data;
        }

        public SalesRecord Insert(SalesRecord model)
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


        public SalesRecord Update(SalesRecord model)
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
