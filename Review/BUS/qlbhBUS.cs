using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

using DAL;
using DTO;

namespace BUS
{
    public class qlbhBUS //class BUS được gọi
    {
        public List<qlbhDTO> GetNhanVien(string sql)// trả ngược về DAL có List đã có dữ liệu
        {
            try
            {
                return new qlbhDAL().GetNhanVien(sql);//  return-> gọi DAL -> class DAL thực thi.
            }
            catch (SqlException  ex)
            {
                throw ex;
            }

        }

        public int add(qlbhDTO ql)
        {
            try
            {
                return (new qlbhDAL().add(ql));
            }
            catch (SqlException ex)
            {
                
                throw ex;
            }
        }
    }
}
