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
    public static class SanPham_DAL
    {
        static public DataTable loadDuLieuSP()
        {
            string getSPQuerry = "EXEC SanPhamSelect";            // lấy dữ liệu tất cả nhân viên
            DataTable getSanPham = new DataTable();
            getSanPham = SQL_Connect.Instance.ExecuteSQL(getSPQuerry);
            return getSanPham;
        }

        static public bool themSanPham(SanPham sp)
        {
            bool isSuccess = true;
            try
            {
                if (sp.GiaSP == -1 || sp.SoLuongSP == -1)
                {
                    return false;
                }
                else
                {
                    string themSPQuerry = "INSERT SANPHAM VALUES (N'" + sp.TenSP + "'," + sp.GiaSP + "," + sp.MaLoaiSP + "," + sp.SoLuongSP + ",'" + sp.NgThemSp.ToShortDateString() + "')";
                    SQL_Connect.Instance.ExecuteNONquerrySQL(themSPQuerry);
                }
            }
            catch
            {
                isSuccess = false;
            }
            return isSuccess;
        }
        static public bool updateSanPham(SanPham sp)
        {
            bool isSuccess = true;

            try
            {
                if (sp.SoLuongSP == -1 || sp.GiaSP == -1)
                {
                    return false;
                }
                else
                {
                    string updateSPQuerry = "UPDATE SANPHAM SET TENSP = N'" + sp.TenSP + "', GIA =" + sp.GiaSP + ", MALOAISP = N'" + sp.MaLoaiSP + "',SOLUONGSP = " + sp.SoLuongSP + ",NGAYTHEM =" + sp.NgThemSp.ToShortDateString() + " WHERE MASP = N'" + sp.MaSP + "'";
                    SQL_Connect.Instance.ExecuteNONquerrySQL(updateSPQuerry);
                }
            }
            catch
            {
                isSuccess = false;
            }
            return isSuccess;
        }
        static public bool xoaSanPham(string ma)
        {
            bool isSuccess = true;
            try
            {
                string deleteSPQuerry = "DELETE SANPHAM WHERE MASP =" + ma ;
                SQL_Connect.Instance.ExecuteNONquerrySQL(deleteSPQuerry);
            }
            catch
            {
                isSuccess = false;
            }
            return isSuccess;
        }

    }
}
