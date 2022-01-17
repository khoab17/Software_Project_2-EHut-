
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
    public class ShopServices
    {
        ShopRepo repo = new ShopRepo();
        OrderServices orderServices = new OrderServices();
        public List<Shop> GetAll()
        {
            var data = repo.GetAll();
            return data;
        }

        public Shop Get(int id)
        {
            var data = repo.Get(id);
            return data;
        }

        public Shop GetByPhone(string phone)
        {
            var data = repo.GetByPhone(phone);
            return data;
        }

        public Shop Insert(Shop model)
        {
            //inital value for every shop
            model.Rating = 5;
            model.TotalRecievedPayment = 0;
            model.TotalSold = 0;
            model.Status = false;

            var entity = model;
            bool done = repo.Insert(entity);

            //get the model just inserted
            CredentialServices credentialServices = new CredentialServices();
            var temp = this.GetByPhone(model.Phone);
            //insert in credential table
            Credential credential = new Credential();
            credential.Password = temp.Password;
            credential.Phone = temp.Phone;
            credential.Role = "Shop";
            credential.UserId = temp.ShopId;
            var cred= credentialServices.Insert(credential);

            if (done && cred!=null)
            {
                model.ShopId = credential.UserId;
                return model;
            }
            else
                return null;
        }


        public Shop Update(Shop model)
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

        public List<SumGroupByModel> GetYearlySalesData()
        {
            return orderServices.GetYearlySalesData();
        }
        public List<SumGroupByModel> GetMonthlySalesDataForAYear(int year)
        {
            return orderServices.GetMonthlySalesDataForAYear(year);
        }

        
    }
}
