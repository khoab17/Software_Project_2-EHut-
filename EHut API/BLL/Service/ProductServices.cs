using BEL.Model;
using DAL;
using DAL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class ProductServices
    {
        ProductRepo productRepo = new ProductRepo();

        //Get Products
        public List<ProductModel> GetAll()
        {

            var temp = productRepo.GetAll();
            var data = AutoMapper.Mapper.Map<List<Product>, List<ProductModel>>(temp);
            return data;
        }
    }
}
