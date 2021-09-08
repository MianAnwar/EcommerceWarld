using DataObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DbWrapper : IDisposable
    {
        public IEnumerable<Product> GetAllProducts(bool active_status = true)
        {
            Dapper.DynamicParameters param = new Dapper.DynamicParameters();
            param.Add("@Is_active", active_status);
            return EcommerceDb.ReturnList<Product>("dbo.GetAllProducts", param);
        }

        //[dbo].[GetProductByCode]
        public Product GetProductByCode(string code, bool active_status = true)
        {
            Dapper.DynamicParameters param = new Dapper.DynamicParameters();
            param.Add("@code", code);
            param.Add("@Is_active", active_status);
            return EcommerceDb.ReturnList<Product>("dbo.GetProductByCode", param).FirstOrDefault<Product>();
        }

        //[dbo].[[GetProductByID]]
        public Product GetProductByID(int id, bool active_status = true)
        {
            Dapper.DynamicParameters param = new Dapper.DynamicParameters();
            param.Add("@prod_id", id);
            param.Add("@Is_active", active_status);
            return EcommerceDb.ReturnList<Product>("dbo.GetProductByID", param).FirstOrDefault<Product>();
        }

        //[dbo].[AddProductQuantity]
        public Int32 AddProductQuantity(int prod_id, int quantity)
        {
            SqlParameter parameterProdID = new SqlParameter("@prod_id", SqlDbType.Int);
            parameterProdID.Value = prod_id;
            SqlParameter parameterQuantity = new SqlParameter("@Quantity", SqlDbType.Int);
            parameterQuantity.Value = quantity;
            Object oValue = EcommerceDb.ExecuteScalar("dbo.AddProductQuantity", parameterProdID, parameterQuantity);
            Int32 count;
            if(Int32.TryParse(oValue.ToString(), out count))
            {
                return count;
            }
            return -1;
        }

        //[CategoryProducts]
        public IEnumerable<Product> GetCategoryProducts(int cat_id)
        {
            Dapper.DynamicParameters param = new Dapper.DynamicParameters();
            param.Add("@cat_id", cat_id);
            return EcommerceDb.ReturnList<Product>("dbo.CategoryProducts", param);
        }

        //[[CategoryProductsCount]]
        public IEnumerable<NameCount> GetCategoryProductsCount()
        {
            return EcommerceDb.ReturnList<NameCount>("dbo.CategoryProductsCount");
        }

        //[Customer_OrderCount]
        public IEnumerable<NameCount> GetCustomer_OrderCount(bool active_status = true)
        {
            Dapper.DynamicParameters param = new Dapper.DynamicParameters();
            param.Add("@Is_active", active_status);
            return EcommerceDb.ReturnList<NameCount>("dbo.Customer_OrderCount", param);
        }

        //[[CustomersDetail]]
        public IEnumerable<Customer> GetCustomersDetail(bool active_status = true)
        {
            Dapper.DynamicParameters param = new Dapper.DynamicParameters();
            param.Add("@Is_active", active_status);
            return EcommerceDb.ReturnList<Customer>("dbo.CustomersDetail", param);
        }

        //[dbo].[[DeleteCustomer]]
        public Int32 DeleteCustomer(int cust_id)
        {
            SqlParameter parameterCustID = new SqlParameter("@cust_id", SqlDbType.Int);
            parameterCustID.Value = cust_id;
            Object oValue = EcommerceDb.ExecuteScalar("dbo.DeleteCustomer", parameterCustID);
            Int32 count;
            if (Int32.TryParse(oValue.ToString(), out count))
            {
                return count;
            }
            return -1;
        }

        //[dbo].[[DeleteProductByCode]]
        public Int32 DeleteProductByCode(string code)
        {
            SqlParameter parameterProdCode = new SqlParameter("@code", SqlDbType.NChar);
            parameterProdCode.Value = code;
            Object oValue = EcommerceDb.ExecuteScalar("dbo.DeleteProductByCode", parameterProdCode);
            Int32 count;
            if (Int32.TryParse(oValue.ToString(), out count))
            {
                return count;
            }
            return -1;
        }

        //[dbo].[[[DeleteProductByID]]]
        public Int32 DeleteProductByID(int id)
        {
            SqlParameter parameterProdID = new SqlParameter("@prod_id", SqlDbType.Int);
            parameterProdID.Value = id;
            Object oValue = EcommerceDb.ExecuteScalar("dbo.DeleteProductByID", parameterProdID);
            Int32 count;
            if (Int32.TryParse(oValue.ToString(), out count))
            {
                return count;
            }
            return -1;
        }

        //[GetAllCategories]
        public IEnumerable<Category> GetAllCategories(bool active_status = true)
        {
            Dapper.DynamicParameters param = new Dapper.DynamicParameters();
            param.Add("@Is_active", active_status);
            return EcommerceDb.ReturnList<Category>("dbo.GetAllCategories", param);
        }

        //[[GetAllOrders]]
        public IEnumerable<Order> GetAllOrders(bool status = true, bool active_status = true)
        {
            Dapper.DynamicParameters param = new Dapper.DynamicParameters();
            param.Add("@Status", status);
            param.Add("@Is_active", active_status);
            return EcommerceDb.ReturnList<Order>("dbo.GetAllOrders", param);
        }

        //[dbo].[[GetCustomerByEmail]]
        public Customer GetCustomerByEmail(string email, bool active_status = true)
        {
            Dapper.DynamicParameters param = new Dapper.DynamicParameters();
            param.Add("@email", email);
            param.Add("@Is_active", active_status);
            return EcommerceDb.ReturnList<Customer>("dbo.GetCustomerByEmail", param).FirstOrDefault<Customer>();
        }

        //[dbo].[[[GetCustomerByID]]]
        public Customer GetCustomerByID(int cust_id, bool active_status = true)
        {
            Dapper.DynamicParameters param = new Dapper.DynamicParameters();
            param.Add("@cust_id", cust_id);
            param.Add("@Is_active", active_status);
            return EcommerceDb.ReturnList<Customer>("dbo.GetCustomerByID", param).FirstOrDefault<Customer>();
        }

        //[dbo].[[[InsertIntoCart]]]
        public Int32 InsertIntoCart(Cart cart)
        {
            SqlParameter parameterCustID= new SqlParameter("@cust_id", SqlDbType.Int);
            parameterCustID.Value = cart.Customer_id;// cust_id;
            SqlParameter parameterProdID= new SqlParameter("@prod_id", SqlDbType.Int);
            parameterProdID.Value = cart.Product_id;
            SqlParameter parameterProdQuantity= new SqlParameter("@prod_quantity", SqlDbType.Int);
            parameterProdQuantity.Value = cart.Quantity;
            Object oValue = EcommerceDb.ExecuteScalar("dbo.InsertIntoCart", parameterCustID, parameterProdID, parameterProdQuantity);
            Int32 count;
            if (Int32.TryParse(oValue.ToString(), out count))
            {
                return count;
            }
            return -1;
        }

        //[dbo].[[[[InsertNewCategory]]]]
        public Int32 InsertNewCategory(Category category)
        {
            SqlParameter parameterCatName= new SqlParameter("@cat_name", SqlDbType.NChar);
            parameterCatName.Value = category.Name;
            SqlParameter parameterCreated_by = new SqlParameter("@Created_by", SqlDbType.Int);
            parameterCreated_by.Value = category.Created_by;
            Object oValue = EcommerceDb.ExecuteScalar("dbo.InsertNewCategory", parameterCatName, parameterCreated_by);
            Int32 count;
            if (Int32.TryParse(oValue.ToString(), out count))
            {
                return count;
            }
            return -1;
        }

        //[dbo].[[[[[InsertNewProduct]]]]]
        public Int32 InsertNewProduct(Product product)
        {
            SqlParameter parameterName= new SqlParameter("@Name", SqlDbType.NChar);
            parameterName.Value = product.Name;
            SqlParameter parameterCode= new SqlParameter("@Code", SqlDbType.NChar);
            parameterCode.Value = product.Code;
            SqlParameter parameterPrice= new SqlParameter("@Price", SqlDbType.Real);
            parameterPrice.Value = product.Price;
            SqlParameter parameterDesp= new SqlParameter("@Desp", SqlDbType.NChar);
            parameterDesp.Value = product.Desp;
            SqlParameter parameterQuantity= new SqlParameter("@Quantity", SqlDbType.Int);
            parameterQuantity.Value = product.Quantity;
            SqlParameter parameterCatID = new SqlParameter("@Cat_id", SqlDbType.Int);
            parameterCatID.Value = product.CatID;
            SqlParameter parameterCreated_by = new SqlParameter("@Created_by", SqlDbType.Int);
            parameterCreated_by.Value = product.Created_by;
            Object oValue = EcommerceDb.ExecuteScalar("dbo.InsertNewProduct", parameterName, parameterCode, parameterPrice, parameterDesp, parameterQuantity, parameterCatID, parameterCreated_by);
            Int32 count;
            if (Int32.TryParse(oValue.ToString(), out count))
            {
                return count;
            }
            return -1;
        }

        //[dbo].[[[[[[InsertOrderItems]]]]]]    [GetCartProductIDsOfCustomer]
        public Int32 InsertOrderItems(int cust_id)
        {
            bool flag = false;
            Dapper.DynamicParameters param = new Dapper.DynamicParameters();
            param.Add("@cust_id", cust_id);
            IEnumerable<Cart> carts= EcommerceDb.ReturnList<Cart>("dbo.GetCartProductIDsOfCustomer", param);
            SqlParameter parameterCustID = new SqlParameter("@order_id", SqlDbType.NChar);
            parameterCustID.Value = cust_id;
            foreach (var cart in carts)
            {
                SqlParameter parameterProdID = new SqlParameter("@product_id", SqlDbType.NChar);
                parameterProdID.Value = cart.Product_id;
                Object oValue = EcommerceDb.ExecuteScalar("dbo.InsertOrderItems", parameterCustID, parameterProdID);
                Int32 count;
                if (Int32.TryParse(oValue.ToString(), out count))
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }
            }
            return flag? 1: -1;
        }

        //[dbo].[[[[[InsertOrder]]]]]
        public Int32 InsertOrder(int cust_id)
        {
            SqlParameter parameterCustID= new SqlParameter("@cust_id", SqlDbType.Int);
            parameterCustID.Value = cust_id;
            Object oValue = EcommerceDb.ExecuteScalar("dbo.InsertOrder", parameterCustID);
            Int32 count;
            if (Int32.TryParse(oValue.ToString(), out count))
            {
                return count;
            }
            return -1;
        }

        //[[OrderDetails]]
        public IEnumerable<OrderDetail> GetOrderDetails(int order_id)
        {
            Dapper.DynamicParameters param = new Dapper.DynamicParameters();
            param.Add("@order_id", order_id);
            return EcommerceDb.ReturnList<OrderDetail>("dbo.OrderDetails", param);
        }

        //[[[OrdersByCustomerID]]]
        public IEnumerable<MyOrders> GetOrdersByCustomerID(int cust_id, bool status = true, bool active_status = true)
        {
            Dapper.DynamicParameters param = new Dapper.DynamicParameters();
            param.Add("@cust_id", cust_id);
            param.Add("@Status", status);
            param.Add("@Is_active", active_status);
            return EcommerceDb.ReturnList<MyOrders>("dbo.OrdersByCustomerID", param);
        }

        //[dbo].[[[[[[RegisterNewCustomer]]]]]]
        public Int32 RegisterNewCustomer(Customer customer)
        {
            SqlParameter parameterName = new SqlParameter("@Name", SqlDbType.NChar);
            parameterName.Value = customer.Name;
            SqlParameter parameterAddress = new SqlParameter("@Address", SqlDbType.NChar);
            parameterAddress.Value = customer.Address;
            SqlParameter parameterContactNo = new SqlParameter("@Contact_no", SqlDbType.NChar);
            parameterContactNo.Value = customer.Contact_no;
            SqlParameter parameterEmail = new SqlParameter("@Email", SqlDbType.NChar);
            parameterEmail.Value = customer.Email;
            Object oValue = EcommerceDb.ExecuteScalar("dbo.RegisterNewCustomer", parameterName, parameterName, parameterAddress, parameterContactNo, parameterEmail);
            Int32 count;
            if (Int32.TryParse(oValue.ToString(), out count))
            {
                return count;
            }
            return -1;
        }

        //[dbo].[[[UpdateCustomerByID]]]
        public Int32 UpdateCustomerByID(Customer customer)
        {
            SqlParameter parameterCustID= new SqlParameter("@cust_id", SqlDbType.Int);
            parameterCustID.Value = customer.ID;
            SqlParameter parameterName = new SqlParameter("@Name", SqlDbType.NChar);
            parameterName.Value = customer.Name;
            SqlParameter parameterAddress = new SqlParameter("@Address", SqlDbType.NChar);
            parameterAddress.Value = customer.Address;
            SqlParameter parameterContactNo = new SqlParameter("@Contact_no", SqlDbType.NChar);
            parameterContactNo.Value = customer.Contact_no;
            SqlParameter parameterEmail = new SqlParameter("@Email", SqlDbType.NChar);
            parameterEmail.Value = customer.Email;
            Object oValue = EcommerceDb.ExecuteScalar("dbo.UpdateCustomerByID", parameterName, parameterName, parameterAddress, parameterContactNo, parameterEmail);
            Int32 count;
            if (Int32.TryParse(oValue.ToString(), out count))
            {
                return count;
            }
            return -1;
        }

        //[dbo].[[[[UpdateProductByID]]]]
        public Int32 UpdateProductByID(Product product)
        {
            SqlParameter parameterProdID = new SqlParameter("@prod_id", SqlDbType.Int);
            parameterProdID.Value = product.ID;
            SqlParameter parameterName = new SqlParameter("@Name", SqlDbType.NChar);
            parameterName.Value = product.Name;
            SqlParameter parameterCode = new SqlParameter("@Code", SqlDbType.NChar);
            parameterCode.Value = product.Code;
            SqlParameter parameterPrice = new SqlParameter("@Price", SqlDbType.Real);
            parameterPrice.Value = product.Price;
            SqlParameter parameterDesp = new SqlParameter("@Desp", SqlDbType.NChar);
            parameterDesp.Value = product.Desp;
            SqlParameter parameterCreated_by = new SqlParameter("@Created_by", SqlDbType.Int);
            parameterCreated_by.Value = product.Created_by;
            Object oValue = EcommerceDb.ExecuteScalar("dbo.UpdateProductByID", parameterName, parameterCode, parameterPrice, parameterDesp, parameterCreated_by);
            Int32 count;
            if (Int32.TryParse(oValue.ToString(), out count))
            {
                return count;
            }
            return -1;
        }

        //[dbo].[[[[[UpdateTotalAmountInOrder]]]]]
        public Int32 UpdateTotalAmountInOrder(int order_id)
        {
            SqlParameter parameterOrdeID = new SqlParameter("@order_id", SqlDbType.Int);
            parameterOrdeID.Value = order_id;
            Object oValue = EcommerceDb.ExecuteScalar("dbo.UpdateTotalAmountInOrder", parameterOrdeID);
            Int32 count;
            if (Int32.TryParse(oValue.ToString(), out count))
            {
                return count;
            }
            return -1;
        }

        public void Dispose()
        {
            GC.Collect();
        }
    }
}
