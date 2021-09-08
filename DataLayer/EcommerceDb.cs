using Dapper;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    internal class EcommerceDb
    {
        public static SqlConnection GetEcommerceDbConnection()
        {
            return new SqlConnection(@"Data Source=LHRLT-8163;Initial Catalog=ecommerce;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        /*
         Start
        */
        public static Object ExecuteScalar(String procedureName, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = EcommerceDb.GetEcommerceDbConnection())
            {
                using (SqlCommand cmd = new SqlCommand(procedureName, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }

        public static IEnumerable<T> ReturnList<T>(String procedureName, Dapper.DynamicParameters parameters = null)
        {
            using(SqlConnection conn = EcommerceDb.GetEcommerceDbConnection())
            {
                conn.Open();
                return conn.Query<T>(procedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
        /*
         End
         */
    }
}


//public static Int32 ExecuteNonQuery(String procedureName, params SqlParameter[] parameters)
//{
//    using (SqlConnection conn = EcommerceDb.GetEcommerceDbConnection())
//    {
//        using (SqlCommand cmd = new SqlCommand(procedureName, conn))
//        {
//            cmd.CommandType = System.Data.CommandType.StoredProcedure;
//            cmd.Parameters.AddRange(parameters);

//            conn.Open();
//            return cmd.ExecuteNonQuery();
//        }
//    }
//}


//public static SqlDataReader ExecuteReader(String procedureName, params SqlParameter[] parameters)
//{
//    SqlConnection conn = EcommerceDb.GetEcommerceDbConnection();

//    using (SqlCommand cmd = new SqlCommand(procedureName, conn))
//    {
//        cmd.CommandType = System.Data.CommandType.StoredProcedure; ;
//        cmd.Parameters.AddRange(parameters);

//        conn.Open();
//        SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

//        return reader;
//    }
//}
