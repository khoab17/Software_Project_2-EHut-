
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
        ProductServices productServices = new ProductServices();
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

        public List<Product> GetNonDeliveredRecors(int shopId)
        {
            var recors= repo.GetSalesRecordByShop(shopId);
            List<Product> productList=new List<Product>();
            if(recors!=null)
            {
                foreach (var item in recors)
                {
                    productList.Add(productServices.Get(item.ProductId));
                }
                return productList;
            }
            else
                return null ;
        }
    }
}
