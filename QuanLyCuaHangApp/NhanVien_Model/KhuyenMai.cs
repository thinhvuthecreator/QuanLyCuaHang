using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Khuyenmai
    {
        private int maKM;
        private int giaTriKM;
        private decimal giaTriDK;

        public int MaKM { get => maKM; set => maKM = value; }
        public int GiaTriKM { get => giaTriKM; set => giaTriKM = value; }
        public decimal GiaTriDK { get => giaTriDK; set => giaTriDK = value; }
    }
}
