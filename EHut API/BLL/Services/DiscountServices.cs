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
    public class DiscountServices
    {
        DiscountRepo repo = new DiscountRepo();
        public List<DiscountModel> GetAll()
        {
            var data = repo.GetAll();
            return Mapper<Discount, DiscountModel>.ListOfEntityToModel(data);
        }

        public DiscountModel Get(int id)
        {
            var data = repo.Get(id);
            return Mapper<Discount, DiscountModel>.EntityToModel(data);
        }

        public DiscountModel GetByPhone(string phone)
        {
            var data = repo.GetByPhone(phone);
            return Mapper<Discount, DiscountModel>.EntityToModel(data);
        }

        public DiscountModel Insert(DiscountModel model)
        {
            var entity = Mapper<Discount, DiscountModel>.ModelToEntity(model);
            bool done = repo.Insert(entity);

            if (done)
            {
                return model;
            }
            else
                return null;
        }


        public DiscountModel Update(DiscountModel model)
        {
            var entity = Mapper<Discount, DiscountModel>.ModelToEntity(model);
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
