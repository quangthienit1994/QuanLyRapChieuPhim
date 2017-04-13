using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

using DTO;

namespace DAL
{
    public class qlbhDAL
    {
        private DataProvider dp;

        public qlbhDAL()
        {
            dp = new DataProvider();
        }

        public List<qlbhDTO> GetNhanVien(string sql)
        {
            List<qlbhDTO> list= new List<qlbhDTO>();


            int maLoaiSp;
            string tenLoaiSp;

            dp.Connect();
            try
            {
                SqlDataReader dr = dp.executeReader(sql);
                while (dr.Read())
                {
                    maLoaiSp = dr.GetInt32(0);
                    tenLoaiSp = dr.GetString(1);

                    qlbhDTO ql = new qlbhDTO(maLoaiSp, tenLoaiSp);//-> gọi DTO, DTO lấy dữ liệu từ Data
                    list.Add(ql);
                }
                dr.Close();
                return list;// trả về List đã có dữ liệu
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                dp.DisConnect();
            }
        }

        //public List<qlbhDTO> GetNhanVien(string sql);

        public int add(qlbhDTO ql)
        {
            List<SqlParameter> paras= new List<SqlParameter>();
            paras.Add(new SqlParameter("@MaSp", ql.MaLoaiSp));
            paras.Add(new SqlParameter("@TenLoaiSp", ql.TenLoaiSp));

            try
            {
                return (dp.executeNonQuery("addSP", System.Data.CommandType.StoredProcedure, paras));
            }
            catch (SqlException ex)
            {
                
                throw ex;
            }
        }
    }
}
