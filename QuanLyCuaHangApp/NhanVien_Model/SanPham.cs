using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class SanPham
    {
        private int maSP, maLoaiSP;
        private int soLuongSP;
        private string tenSP;
        private decimal giaSP;
        private DateTime ngThemSp;
        private string fileAnh;

        public int MaSP { get => maSP; set => maSP = value; }
        public int MaLoaiSP { get => maLoaiSP; set => maLoaiSP = value; }
        public string TenSP { get => tenSP; set => tenSP = value; }
        public decimal GiaSP { get => giaSP; set => giaSP = value; }
        public DateTime NgThemSp { get => ngThemSp; set => ngThemSp = value; }
        public int SoLuongSP { get => soLuongSP; set => soLuongSP = value; }
        public string FileAnh { get => fileAnh; set => fileAnh = value; }
    }
}
