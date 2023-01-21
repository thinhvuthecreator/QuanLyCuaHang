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
            data = new List<Sale>();
            DataTable dataa = SQL_Connect.Instance.ExecuteSQL("SELECT SUM(TRIGIASAUKM) AS DOANHTHU ,DAY(NGHD) AS NGAY FROM HOADON WHERE MONTH(NGHD) = MONTH(GETDATE()) GROUP BY NGHD ORDER BY NGHD ASC ");
            foreach(DataRow row in dataa.Rows)
            {
                data.Add(new Sale {doanhThu = decimal.Parse(row[0].ToString()),Ngay ="Ngày " + row[1].ToString()});
            }


        }


      

    }
}
