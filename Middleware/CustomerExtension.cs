using DataLayer;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middleware
{
    public static class CustomerExtension
    {
        //12. GetAllCustomers
        public static IEnumerable<Customer> GetAllCustomers(this Middlelayer layer, bool active_status = true)
        {
            using (DbWrapper db = new DbWrapper())
            {
                return db.GetCustomersDetail(active_status: active_status);
            }
        }

        //13. GetCustomer_OrderCount
        public static IEnumerable<NameCount> GetCustomer_OrderCount(this Middlelayer layer)
        {
            using (DbWrapper db = new DbWrapper())
            {
                return db.GetCustomer_OrderCount();
            }
        }


        //14. DeleteCustomer
        public static Int32 DeleteCustomer(this Middlelayer layer, int cust_id)
        {
            using (DbWrapper db = new DbWrapper())
            {
                return db.DeleteCustomer(cust_id: cust_id);
            }
        }


        //15. GetCustomerByID
        public static Customer GetCustomerByID(this Middlelayer layer, int Id, bool active_status = true)
        {
            using (DbWrapper db = new DbWrapper())
            {
                return db.GetCustomerByID(cust_id: Id, active_status: active_status);
            }
        }

        //16. GetCustomerByEmail
        public static Customer GetCustomerByEmail(this Middlelayer layer, string Email, bool active_status = true)
        {
            using (DbWrapper db = new DbWrapper())
            {
                return db.GetCustomerByEmail(email: Email, active_status: active_status);
            }
        }

        //17. RegisterNewCustomer
        public static Int32 RegisterNewCustomer(this Middlelayer layer, Customer customer)
        {
            using (DbWrapper db = new DbWrapper())
            {
                return db.RegisterNewCustomer(customer: customer);
            }
        }

        //18. UpdateCustomerByID
        public static Int32 UpdateCustomerByID(this Middlelayer layer, Customer customer)
        {
            using (DbWrapper db = new DbWrapper())
            {
                return db.UpdateCustomerByID(customer: customer);
            }
        }

        //25. InsertIntoCart
        public static Int32 InsertIntoCart(this Middlelayer layer, Cart cart)
        {
            using (DbWrapper db = new DbWrapper())
            {
                return db.InsertIntoCart(cart: cart);
            }
        }

    }
}
