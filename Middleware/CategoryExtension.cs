using DataLayer;
using DataObjects;
using System;
using System.Collections.Generic;

namespace Middleware
{
    public static class CategoryExtension
    {
        //24. GetAllCategories
        public static IEnumerable<Category> GetAllCategories(this Middlelayer layer, bool active_status = true)
        {
            using (DbWrapper db = new DbWrapper())
            {
                return db.GetAllCategories(active_status: active_status);
            }
        }

        //9. GetCategoryProducts
        public static IEnumerable<Product> GetCategoryProducts(this Middlelayer layer, int cat_id)
        {
            using (DbWrapper db = new DbWrapper())
            {
                return db.GetCategoryProducts(cat_id: cat_id);
            }
        }

        //10. GetCategoryProductsCount
        public static IEnumerable<NameCount> GetCategoryProductsCount(this Middlelayer layer)
        {
            using (DbWrapper db = new DbWrapper())
            {
                return db.GetCategoryProductsCount();
            }
        }

        //11. InsertNewCategory
        public static Int32 InsertNewCategory(this Middlelayer layer, Category category)
        {
            using (DbWrapper db = new DbWrapper())
            {
                return db.InsertNewCategory(category: category);
            }
        }
    }
}
