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
        public List<ShopModel> GetAll()
        {
            var data = repo.GetAll();
            return Mapper<Shop, ShopModel>.ListOfEntityToModel(data);
        }

        public ShopModel Get(int id)
        {
            var data = repo.Get(id);
            return Mapper<Shop, ShopModel>.EntityToModel(data);
        }

        public ShopModel GetByPhone(string phone)
        {
            var data = repo.GetByPhone(phone);
            return Mapper<Shop, ShopModel>.EntityToModel(data);
        }

        public ShopModel Insert(ShopModel model)
        {
            //inital value for every shop
            model.Rating = 5;
            model.TotalRecievedPayment = 0;
            model.TotalSold = 0;

            var entity = Mapper<Shop, ShopModel>.ModelToEntity(model);
            bool done = repo.Insert(entity);

            //get the model just inserted
            CredentialServices credentialServices = new CredentialServices();
            var temp = this.GetByPhone(model.Phone);
            //insert in credential table
            CredentialModel credentialModel = new CredentialModel();
            credentialModel.Password = temp.Password;
            credentialModel.Password = temp.Phone;
            credentialModel.Role = "Shop";
            credentialModel.UserId = temp.ShopId;
            var cred= credentialServices.Insert(credentialModel);

            if (done && cred!=null)
            {
                return model;
            }
            else
                return null;
        }


        public ShopModel Update(ShopModel model)
        {
            var entity = Mapper<Shop, ShopModel>.ModelToEntity(model);
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
