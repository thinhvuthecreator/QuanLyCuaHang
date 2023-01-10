using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data;
using System.Data.SqlClient;

namespace SQL_Connection
{
    public class HoaDon_DAL
    {
        static public DataTable loadDuLieuHD()
        {
            string getHDQuerry = "EXEC  HoaDonSelect";            // lấy dữ liệu tất cả nhân viên
            DataTable getHoaDon = new DataTable();
            getHoaDon = SQL_Connect.Instance.ExecuteSQL(getHDQuerry);
            return getHoaDon;
        }
        static public bool themHoaDon(HoaDon hd)
        {
            bool isSuccess = true;
            try
            {
               
                    string themHDQuerry = "INSERT HOADON VALUES ('"+ hd.NgHoaDon.ToShortDateString() + "'," + hd.TriGia + "," + hd.MaKH + "," + hd.MaNV + ")";
                    SQL_Connect.Instance.ExecuteNONquerrySQL(themHDQuerry);
                
            }
            catch
            {
                isSuccess = false;
            }
            return isSuccess;
        }
       
        static public bool xoaHoaDon(string ma)
        {
            bool isSuccess = true;
            try
            {
                string deleteHDQuerry = "DELETE HOADON WHERE MAHD =" + ma;
                SQL_Connect.Instance.ExecuteNONquerrySQL(deleteHDQuerry);
            }
            catch
            {
                isSuccess = false;
            }
            return isSuccess;
        }
    }
}
