using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement
{
    public class ProductService
    {
        public static void AddProduct(Product pd)
        {
            using(var db=new OrderContext())
            {
                db.Products.Add(pd);
                db.SaveChanges();
            }
        }

        public static List<Product> GetAllProduct()
        {
            using(var db=new OrderContext())
            {
                return db.Products.ToList();
            }
        }
    }
}
