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
                new Sale {doanhThu = doanhThuHomKia() ,Ngay = "Hôm kia"},
                new Sale {doanhThu = doanhThuHomQua() ,Ngay = "Hôm qua"},
                new Sale {doanhThu = doanhThuHomNay() ,Ngay = "Hôm nay"},

            };


        }

        decimal doanhThuHomNay()
        {
            DataTable doanhThu = SQL_Connect.Instance.ExecuteSQL("SELECT SUM(TRIGIASAUKM) FROM HOADON WHERE DAY(NGHD) = DAY(GETDATE())");
            if (doanhThu.Rows.Count > 0)
            {
                return decimal.Parse(doanhThu.Rows[0][0].ToString());
            }
            else
            {
                return 0;
            }
        }

        decimal doanhThuHomQua()
        {
            DataTable doanhThu = SQL_Connect.Instance.ExecuteSQL("SELECT SUM(TRIGIASAUKM) FROM HOADON WHERE DAY(NGHD) = DAY(GETDATE()) - 1");
            if (doanhThu.Rows.Count > 0)
            {
                return decimal.Parse(doanhThu.Rows[0][0].ToString());
            }
            else
            {
                return 0;
            }
        }
        decimal doanhThuHomKia()
        {
            DataTable doanhThu = SQL_Connect.Instance.ExecuteSQL("SELECT SUM(TRIGIASAUKM) FROM HOADON WHERE DAY(NGHD) = DAY(GETDATE()) - 2");
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
