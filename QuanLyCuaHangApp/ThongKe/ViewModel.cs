using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace ThongKe
{
    public class ViewModel
    {
        public List<Sale> data { get; set; }
        
        public ViewModel()
        {
            data = new List<Sale>()
            {
                new Sale {doanhThu = 120000,thangNay = "tháng trước" },
                new Sale {doanhThu = 150000,thangNay = "tháng này"}

            };
        }

    }
}
