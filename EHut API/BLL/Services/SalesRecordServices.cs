
using DAL.Models;
using DAL.Repository;
using DAL.View_Models;
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

        public List<SalesProductViewModel> GetNonDeliveredRecors(int shopId)
        {
            var recors= repo.GetPendingSalesRecordByShop(shopId);
            List<SalesProductViewModel> productList=new List<SalesProductViewModel>();
            if(recors!=null)
            {
                foreach (var item in recors)
                {
                    SalesProductViewModel model = new SalesProductViewModel();
                    model.Product=productServices.Get(item.ProductId);
                    model.quantity=item.Quantity;
                    model.SalesRecordId=item.SalesRecordId;
                    productList.Add(model);
                }
                return productList;
            }
            else
                return null ;
        }
        public List<SalesProductViewModel> GetRecordsByStatus(int shopId, string status)
        {
            var recors = repo.GetSalesRecordByStatus(shopId,status);
            List<SalesProductViewModel> productList = new List<SalesProductViewModel>();
            if (recors != null)
            {
                foreach (var item in recors)
                {
                    SalesProductViewModel model = new SalesProductViewModel();
                    model.Product = productServices.Get(item.ProductId);
                    model.quantity = item.Quantity;
                    model.SalesRecordId = item.SalesRecordId;
                    model.Date = item.Date.Date.ToString();
                    productList.Add(model);
                }
                return productList;
            }
            else
                return null;

        }

        public List<SalesProductViewModel> GetOrderHistoryByStatus(int customerId, string status)
        {

            var recors = repo.GetOrderHistoryByStatus(customerId, status);
            List<SalesProductViewModel> productList = new List<SalesProductViewModel>();
            if (recors != null)
            {
                foreach (var item in recors)
                {
                    SalesProductViewModel model = new SalesProductViewModel();
                    model.Product = productServices.Get(item.ProductId);
                    model.quantity = item.Quantity;
                    model.SalesRecordId = item.SalesRecordId;
                    productList.Add(model);
                }
                return productList;
            }
            else
                return null;

        }

        public bool UpdateSalesRecorStatus(int id, string status)
        {
            var temp=repo.Get(id);
            temp.Status=status;
            bool done = repo.Update(temp);
            return done;
                
        }
    }
}
