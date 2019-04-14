using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace DAL
{
    public class DBHelper
    {

        private static SqlConnection connection;
        //获取连接..打开连接
        public static SqlConnection Connection
        {
            get
            {
                string connectionString = ConfigurationManager.ConnectionStrings["OA_DB"].ToString();
                
                if (connection == null)
                {
                    connection = new SqlConnection(connectionString);
                    connection.Open();
                }
                else if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }
                else if (connection.State == System.Data.ConnectionState.Broken)
                {
                    connection.Close();
                    connection.Open();
                }
                return connection;
            }
        }



        public static int ExecuteNonQueryProc(string procName, params SqlParameter[] values)
        {
            SqlCommand cmd = new SqlCommand(procName, Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            if (values != null)
                cmd.Parameters.AddRange(values);
            return cmd.ExecuteNonQuery();
        }

        public static int ExecuteScalarProc(string procName, params SqlParameter[] values)
        {
            SqlCommand cmd = new SqlCommand(procName, Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            if (values != null)
                cmd.Parameters.AddRange(values);
            int result = (int)cmd.ExecuteScalar();
            return result;
        }

        public static SqlDataReader ExecuteReaderProc(string procName, params SqlParameter[] values)
        {
            SqlCommand cmd = new SqlCommand(procName, Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            if (values != null)
                cmd.Parameters.AddRange(values);
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }

        public static DataTable GetDataTableProc(string procName, params SqlParameter[] values)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand(procName, Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            if (values != null)
                cmd.Parameters.AddRange(values);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds.Tables[0];
        }






    }
}
