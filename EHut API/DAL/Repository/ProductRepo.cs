using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class ProductRepo: Repository<Product>
    {
        public List<Product> ProductsByCategory(int id)
        {
            return context.Products.Where(x => x.CategoryId == id).ToList();
        }
        public List<Product> ProductsByBrand(int id)
        {
            return context.Products.Where(x => x.BrandId == id).ToList();
        }

        public List<Product> PriceFilter(float min, float max)
        {
            List<Product> products = this.context.Products.Where(x => x.Price >= min && x.Price <= max).ToList();
            return products;
        }
        public List<Product> Search(string name)
        { 
            return this.context.Products.Where(x => x.Name.Contains(name)).ToList();
        }

        public DbSqlQuery<Product> TopProductSold()//        --- Top product in terms of Number of product sold
        {
            var list1 = context.Products.SqlQuery(@"select ProductId, Name, Price
                    from [Products]
                    where ProductId = (
                    select ProductId from [SalesRecord]
					
                    having count(*) in (
                    select max(count(ProductId)) 
					from [SalesRecord]
                    group by ProductId)
                    group by ProductId
                    )");

            return list1;
        }

        public List<Product> GetTopProducts(int top)//          --- Top product in terms of Price
        {
            return this.context.Products.OrderByDescending(x => x.Price).Take(top).ToList();
        }
    }
}
