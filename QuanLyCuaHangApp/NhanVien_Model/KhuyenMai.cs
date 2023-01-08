using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class KhuyenMai
    {
        private int maKM;
        private decimal giaTriKM;
        private decimal giaTriDK;

        public int MaKM { get => maKM; set => maKM = value; }
        public decimal GiaTriKM { get => giaTriKM; set => giaTriKM = value; }
        public decimal GiaTriDK { get => giaTriDK; set => giaTriDK = value; }
    }
}
