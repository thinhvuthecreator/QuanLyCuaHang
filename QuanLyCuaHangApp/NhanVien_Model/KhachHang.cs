using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class KhachHang
    {
        private int maKH, sdtKH;
        private string tenKH, gioiTinhKH,fileAnh;
        private DateTime ngSinhKH;
        private decimal doanhSoKH;

        public int MaKH { get => maKH; set => maKH = value; }
        public int SdtKH { get => sdtKH; set => sdtKH = value; }       
        public string TenKH { get => tenKH; set => tenKH = value; }
        public string GioiTinhKH { get => gioiTinhKH; set => gioiTinhKH = value; }
        public DateTime NgSinhKH { get => ngSinhKH; set => ngSinhKH = value; }
        public string FileAnh { get => fileAnh; set => fileAnh = value; }
        public decimal DoanhSoKH { get => doanhSoKH; set => doanhSoKH = value; }
    }
}
