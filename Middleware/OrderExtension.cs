using DataLayer;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middleware
{
    public static class OrderExtension
    {
        //19. GetAllOrders
        public static IEnumerable<Order> GetAllOrders(this Middlelayer layer, bool active_status = true)
        {
            using (DbWrapper db = new DbWrapper())
            {
                return db.GetAllOrders(active_status: active_status);
            }
        }

        //20. InsertOrder
        public static Int32 InsertOrder(this Middlelayer layer, int cust_id)
        {
            using (DbWrapper db = new DbWrapper())
            {
                return db.InsertOrder(cust_id: cust_id);
            }
        }

        //21. GetOrderDetails
        public static IEnumerable<OrderDetail> GetOrderDetails(this Middlelayer layer, int order_id)
        {
            using (DbWrapper db = new DbWrapper())
            {
                return db.GetOrderDetails(order_id: order_id);
            }
        }

        //22. GetOrdersByCustomerID: GetMyOrder for a customer
        public static IEnumerable<MyOrders> GetOrdersByCustomerID(this Middlelayer layer, int cust_id)
        {
            using (DbWrapper db = new DbWrapper())
            {
                return db.GetOrdersByCustomerID(cust_id: cust_id);
            }
        }

        //23. UpdateTotalAmountInOrder
        public static Int32 UpdateTotalAmountInOrder(this Middlelayer layer, int order_id)
        {
            using (DbWrapper db = new DbWrapper())
            {
                return db.UpdateTotalAmountInOrder(order_id: order_id);
            }
        }
    }
}
