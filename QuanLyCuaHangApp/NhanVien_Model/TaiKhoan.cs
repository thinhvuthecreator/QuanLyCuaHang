using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TaiKhoan
    {
        private int maNV,maTK;
        private string eMail,taikhoan,matKhau;

    
        public string EMail { get => eMail; set => eMail = value; }
        public string taiKhoan { get => taikhoan; set => taikhoan = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
        public int MaNV { get => maNV; set => maNV = value; }
        public int MaTK { get => maTK; set => maTK = value; }
    }
}
