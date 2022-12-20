using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySanPham
{
    public class SanPhamObject : System.Windows.Controls.Image
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public decimal GiaSP { get; set; }
        public int MaLoaiSP { get; set; }
        public int SoLuongSP { get; set; }
        public DateTime NgThemSP { get; set; }
        public string FileAnh { get; set; }

    }
}
