using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using SQL_Connection;
namespace ThongKe
{
    public class ViewModel
    {
        public List<Sale> data { get; set; }
        
        public ViewModel()
        {
            data = new List<Sale>()
            {
                new Sale {doanhThu = doanhThuThang() ,thangNay = "tháng này"}

               

            };

        }

        decimal doanhThuThang()
        {
            DataTable doanhThu = SQL_Connect.Instance.ExecuteSQL("SELECT SUM(TRIGIASAUKM) FROM HOADON WHERE MONTH(NGHD) = MONTH(GETDATE())");
            if (doanhThu.Rows.Count > 0)
            {
                return decimal.Parse(doanhThu.Rows[0][0].ToString());
            }
            else
            {
                return 0;
            }
        }


    }
}
