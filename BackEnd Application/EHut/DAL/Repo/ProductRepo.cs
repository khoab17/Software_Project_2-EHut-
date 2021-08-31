using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class ProductRepo
    {
        static EHutEntities context;
        static ProductRepo()
        {
            context = new EHutEntities();
        }

        // Get All the products
        public static List<Product> GetProducts()
        {
            var data = context.Products.ToList();
            return data;
        }


        // Add Product
        public static void AddProduct(Product p)
        {
            context.Products.Add(p);
            context.SaveChanges();
        }


        //Update Product
        public static void UpdateProduct(Product p)
        {
            var product = context.Products.FirstOrDefault(x => x.ProductId == p.ProductId);
            context.Entry(product).CurrentValues.SetValues(p);
            context.SaveChanges();
        }


        //Delete product
        public static void DeleteProduct(int id)
        {
            var product = context.Products.FirstOrDefault(x => x.ProductId == id);
            context.Products.Remove(product);
            context.SaveChanges();
        }


    }
}
