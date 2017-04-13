using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL
{
    class DataProvider
    {
        string Strcn = "";
        SqlConnection cn;

        public DataProvider()
        {
            Strcn = ConfigurationManager.ConnectionStrings["Strcn"].ConnectionString;
            cn = new SqlConnection(Strcn);
        }

        public void Connect()
        {
            try
            {

                if (cn != null && cn.State != ConnectionState.Open)
                {
                    cn.Open();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void DisConnect()
        {
            if (cn != null && cn.State != ConnectionState.Closed)
            {
                cn.Close();
            }
        }

        

        public SqlDataReader executeReader(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, cn);
            //SqlDataReader dr = cmd.ExecuteReader();
            //return dr;
            return (cmd.ExecuteReader());
        }

        public int executeNonQuery(string sql, CommandType type, List<SqlParameter> par)
        {
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.CommandType = type;
                if (par != null)
                {
                    foreach (SqlParameter para in par)
                    {
                        cmd.Parameters.Add(para);
                    }
                }
                cmd.ExecuteNonQuery();
                return 1;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally 
            {
                DisConnect();
            }
        }
    }
}
