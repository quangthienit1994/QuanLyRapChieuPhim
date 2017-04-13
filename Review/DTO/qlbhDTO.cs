using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class qlbhDTO
    {
        public int MaLoaiSp { get; set; }
        public string TenLoaiSp { get; set; }

        public qlbhDTO(int maLoaiSp, string tenLoaiSp)
        {
            MaLoaiSp = maLoaiSp;
            TenLoaiSp = tenLoaiSp;
        }
    }
}
