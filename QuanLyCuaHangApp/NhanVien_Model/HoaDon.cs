using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class HoaDon
    {
        private DateTime ngHoaDon;
        private int triGia, maKH, maNV;

        public DateTime NgHoaDon { get => ngHoaDon; set => ngHoaDon = value; }
        public int TriGia { get => triGia; set => triGia = value; }
        public int MaKH { get => maKH; set => maKH = value; }
        public int MaNV { get => maNV; set => maNV = value; }
    }
}
