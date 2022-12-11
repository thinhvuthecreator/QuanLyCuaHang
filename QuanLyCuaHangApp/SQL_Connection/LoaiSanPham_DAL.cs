using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Models;

namespace SQL_Connection
{
    public static class LoaiSanPham_DAL
    {
        static public DataTable loadDuLieuLOAISP()
        {
            string getLSPQuerry = "EXEC LoaiSanPhamSelect";            // lấy dữ liệu tất cả nhân viên
            DataTable getLoaiSanPham = new DataTable();
            getLoaiSanPham = SQL_Connect.Instance.ExecuteSQL(getLSPQuerry);
            return getLoaiSanPham;
        }
        static public bool themLoaiSP(string tenLSP)
        {
            bool isSuccess = true;
            try
            {

                string themLSPQuerry = "INSERT LOAISP VALUES (N'" + tenLSP + "')";
                SQL_Connect.Instance.ExecuteNONquerrySQL(themLSPQuerry);     
            }
            catch
            {
                isSuccess = false;
            }
            return isSuccess;
        }
        static public bool xoaLoaiSP(string ten)
        {
            bool isSuccess = true;
            try
            {
                string deleteLSPQuerry = "DELETE LOAISP WHERE TENLOAISP = N'" + ten + "'";
                SQL_Connect.Instance.ExecuteNONquerrySQL(deleteLSPQuerry);
            }
            catch
            {
                isSuccess = false;
            }
            return isSuccess;
        }


    }
}
