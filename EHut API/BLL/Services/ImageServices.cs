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
    public class ImageServices
    {
        ImageRepo repo = new ImageRepo();
        public List<ImageModel> GetAll()
        {
            var data = repo.GetAll();
            return Mapper<Image, ImageModel>.ListOfEntityToModel(data);
        }

        public ImageModel Get(int id)
        {
            var data = repo.Get(id);
            return Mapper<Image, ImageModel>.EntityToModel(data);
        }

        public ImageModel GetByPhone(string phone)
        {
            var data = repo.GetByPhone(phone);
            return Mapper<Image, ImageModel>.EntityToModel(data);
        }

        public ImageModel Insert(ImageModel model)
        {
            var entity = Mapper<Image, ImageModel>.ModelToEntity(model);
            bool done = repo.Insert(entity);

            if (done)
            {
                return model;
            }
            else
                return null;
        }


        public ImageModel Update(ImageModel model)
        {
            var entity = Mapper<Image, ImageModel>.ModelToEntity(model);
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
