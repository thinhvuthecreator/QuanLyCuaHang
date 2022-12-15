using System;

namespace Models
{
    public class NhanVien
    {
        private string tenNV, gioiTinh,fileAnh;
        private int sdtNV, maNV;
        private DateTime ngSinhNV;
        private decimal luongNV;

        public int MaNV { get => maNV; set => maNV = value; }
        public string TenNV { get => tenNV; set => tenNV = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public int SdtNV { get => sdtNV; set => sdtNV = value; }
        public decimal LuongNV { get => luongNV; set => luongNV = value; }
        public DateTime NgSinhNV { get => ngSinhNV; set => ngSinhNV = value; }
        public string FileAnh { get => fileAnh; set => fileAnh = value; }
    }
}
