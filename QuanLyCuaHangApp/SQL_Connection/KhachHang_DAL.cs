using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Models;

namespace SQL_Connection
{
    static public class KhachHang_DAL
    {
        static public DataTable loadDuLieuKH()
        {
            string getKHQuerry = "EXEC KhachHangSelect";            // lấy dữ liệu tất cả nhân viên
            DataTable getKhachHang = new DataTable();
            getKhachHang = SQL_Connect.Instance.ExecuteSQL(getKHQuerry);
            return getKhachHang;
        }
        static public bool themKhachHang(KhachHang kh)
        {
            bool isSuccess = true;
            try
            {
                if(kh.SdtKH == -1)
                {
                    return false;
                }
                else
                {
                    string themKHQuerry = "INSERT KHACHHANG VALUES (N'"+ kh.TenKH +"','" +kh.NgSinhKH.ToShortDateString() + "',N'" + kh.GioiTinhKH +"'," + kh.SdtKH + "," + kh.DoanhSoKH + ",N'" + kh.FileAnh + "')";
                    SQL_Connect.Instance.ExecuteNONquerrySQL(themKHQuerry);
                }
            }
            catch
            {
                isSuccess = false;
            }
            return isSuccess;
        }
        static public bool updateKhachHang(KhachHang kh)
        {
            bool isSuccess = true;

            try
            {
                if(kh.SdtKH == -1 )
                {
                    return false;
                }
                else
                {
                    string updateKHQuerry = "UPDATE KHACHHANG SET TENSP = N'" + kh.TenKH + "', NGSINH = '" + kh.NgSinhKH.ToShortDateString() + "', GIOITINH = N'" + kh.GioiTinhKH + "',SDTKH = " + kh.SdtKH + ",DOANHSO =" + kh.DoanhSoKH +",IMAGEKH =N'" + kh.FileAnh + "' WHERE MAKH = " + kh.MaKH;
                    SQL_Connect.Instance.ExecuteNONquerrySQL(updateKHQuerry);
                }
            }
            catch
            {
                isSuccess = false;
            }
            return isSuccess;
        }
        static public bool xoaKhachHang(string ma)
        {
            bool isSuccess = true;
            try
            {
                string deleteKHQuerry = "DELETE KHACHHANG WHERE MAKH = " + ma;
                SQL_Connect.Instance.ExecuteNONquerrySQL(deleteKHQuerry);
            }
            catch
            {
                isSuccess = false;
            }
            return isSuccess;
        }



        
    }
}
