using DataLayer;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middleware
{
    public static class ProductExtension
    {
        //1. GetAllActiveProducts
        public static IEnumerable<Product> GetAllActiveProducts(this Middlelayer layer, bool active_status = true)
        {
            using (DbWrapper db = new DbWrapper())
            {
                return db.GetAllProducts(active_status: active_status);
            }
        }

        //2. GetActiveProductByCode
        public static Product GetActiveProductByCode(this Middlelayer layer, string code, bool active_status = true)
        {
            using (DbWrapper db = new DbWrapper())
            {
                return db.GetProductByCode(code: code, active_status: active_status);
            }
        }

        //3. GetActiveProductByID
        public static Product GetActiveProductByID(this Middlelayer layer, int Id, bool active_status = true)
        {
            using (DbWrapper db = new DbWrapper())
            {
                return db.GetProductByID(id: Id, active_status: active_status);
            }
        }

        //4. AddProductQuantity
        public static Int32 AddProductQuantity(this Middlelayer layer, int prod_id, int quantity)
        {
            using (DbWrapper db = new DbWrapper())
            {
                return db.AddProductQuantity(prod_id: prod_id, quantity: quantity);
            }
        }

        //5. DeleteProductByID
        public static Int32 DeleteProductByID(this Middlelayer layer, int Id)
        {
            using (DbWrapper db = new DbWrapper())
            {
                return db.DeleteProductByID(id: Id);
            }
        }

        //6. DeleteProductByCode
        public static Int32 DeleteProductByCode(this Middlelayer layer, string code)
        {
            using (DbWrapper db = new DbWrapper())
            {
                return db.DeleteProductByCode(code: code);
            }
        }

        //7. InsertNewProduct
        public static Int32 InsertNewProduct(this Middlelayer layer, Product product)
        {
            using (DbWrapper db = new DbWrapper())
            {
                return db.InsertNewProduct(product: product);
            }
        }

        //8. UpdateProductByID
        public static Int32 UpdateProductByID(this Middlelayer layer, Product product)
        {
            using (DbWrapper db = new DbWrapper())
            {
                return db.UpdateProductByID(product: product);
            }
        }
    }
}
