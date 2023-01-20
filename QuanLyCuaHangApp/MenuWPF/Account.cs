using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuWPF
{
    public class Account
    {
        private static string taiKhoan;
        private static string matKhau;

        public static string TaiKhoan { get => taiKhoan; set => taiKhoan = value; }
        public static string MatKhau { get => matKhau; set => matKhau = value; }
       
    }
}
