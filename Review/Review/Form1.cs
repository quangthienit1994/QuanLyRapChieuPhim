using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

using BUS;
using DTO;

namespace Review
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private List<qlbhDTO> GetNhanVien()
        {
            try
            {
                string sql = "SELECT * FROM LoaiSP";
                return new qlbhBUS().GetNhanVien(sql);// 1/return -> gọi BUS -> class BUS thực thi, 2/ BUS trả ngược lại list sau khi DAL hoàn thành
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        private void dvgQLBH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dvgQLBH.DataSource = GetNhanVien();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int maLoaiSp;
            string tenLoaiSp;

            maLoaiSp = Convert.ToInt32(txtMaSp.Text);
            tenLoaiSp = Convert.ToString(txtTenSp.Text);

            qlbhDTO ql = new qlbhDTO(maLoaiSp, tenLoaiSp);
            int i = new qlbhBUS().add(ql);
            dvgQLBH.DataSource = GetNhanVien();
        }

        
    }
}
