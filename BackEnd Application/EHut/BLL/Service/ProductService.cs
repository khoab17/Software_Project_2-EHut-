using BEL.Model;
using DAL;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class ProductService
    {

        //Get Products
        public static List<ProductModel> GetProducts()
        {
            var temp = ProductRepo.GetProducts();
            var data=AutoMapper.Mapper.Map<List<Product>, List<ProductModel>>(temp);
            return data;
        }
    }
}
