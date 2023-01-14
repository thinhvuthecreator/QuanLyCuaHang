using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Models;
using SQL_Connection;

namespace SQL_Connection
{
    public class CTHD_DAL
    {
        static public DataTable loadDuLieuCTHD(int soHD)
        {
            string getCTHDQuerry = "EXEC CTHD_HOADON_Select @soHD =" + soHD;            // lấy dữ liệu tất cả nhân viên
            DataTable getCTHD = new DataTable();
            getCTHD = SQL_Connect.Instance.ExecuteSQL(getCTHDQuerry);
            return getCTHD;
        }
        static public bool themCTHD(CTHD cthd)
        {
            bool isSuccess = true;
            try
            {

                string themCTHDQuerry = "INSERT CTHD VALUES (" + cthd.MaHD + "," + cthd.MaSP + "," + cthd.SoLuong + ")";
                SQL_Connect.Instance.ExecuteNONquerrySQL(themCTHDQuerry);

            }
            catch
            {
                isSuccess = false;
            }
            return isSuccess;
        }

        static public bool xoaCTHD(string maHD,string maSP)
        {
            bool isSuccess = true;
            try
            {
                string deletectHDQuerry = "DELETE CTHD WHERE SOHD =" + maHD + "AND MASP =" + maSP;
                SQL_Connect.Instance.ExecuteNONquerrySQL(deletectHDQuerry);
            }
            catch
            {
                isSuccess = false;
            }
            return isSuccess;
        }
    }
}

