using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data;

namespace SQL_Connection
{
    public static class NhanVien_DAL
    {

       static public DataTable loadDuLieuNV()
        {
            
           
            string getNVQuerry = "EXEC NhanVienSelect";            // lấy dữ liệu tất cả nhân viên
            DataTable getNhanVien = new DataTable();
            getNhanVien = SQL_Connect.Instance.ExecuteSQL(getNVQuerry);
            return getNhanVien;
        }
       static public bool themNhanVien(NhanVien nv)
        {

            bool isSuccess = true;

          


          try
           {
                if (nv.LuongNV == -1 || nv.SdtNV == -1)
                {
                    return false;
                }
                else
                {
                    string addNVQuerry = "INSERT NHANVIEN (TENNV,NGSINH,GIOITINH,SDTNV,LUONG,IMAGENV) VALUES (" + "N'" + nv.TenNV + "','" + nv.NgSinhNV.ToShortDateString() + "'," + "N'" + nv.GioiTinh + "'," + nv.SdtNV + "," + nv.LuongNV + ",N'" + nv.FileAnh + "')";
                    SQL_Connect.Instance.ExecuteNONquerrySQL(addNVQuerry);
                }
            }
          catch
           {
                isSuccess = false;
           }


            return isSuccess;
        }
       static public bool updateNhanVien(NhanVien nv)
        {
            bool isSuccess = true;

            if(nv.LuongNV == -1 || nv.SdtNV == -1)
            {
                return false;
            }

            try
            {
                string updateNVQuerry = "UPDATE NHANVIEN SET TENNV = N'" + nv.TenNV + "', NGSINH = '" + nv.NgSinhNV.ToShortDateString() + "', GIOITINH = N'" + nv.GioiTinh + "',SDTNV = " + nv.SdtNV + ",LUONG =" + nv.LuongNV + ",IMAGENV = N'"+ nv.FileAnh + "' WHERE MANV =" + nv.MaNV;
                SQL_Connect .Instance.ExecuteNONquerrySQL(updateNVQuerry);
            }
            catch
            {
                isSuccess = false;
            }
            return isSuccess;
        }
       static public bool xoaNhanVien(string maNV)
        {
            bool isSuccess = true;
            try
            {
                string deleteNVQuerry = "DELETE NHANVIEN WHERE MANV = " + maNV;
                SQL_Connect.Instance.ExecuteNONquerrySQL(deleteNVQuerry);
            }
            catch
            {
                isSuccess = false;
            }
            return isSuccess;
        }
       




    }
}
