using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Models;
namespace SQL_Connection
{
    public class TaiKhoan_DAL
    {
        static public DataTable loadDuLieuTK()
        {
            string getTKQuerry = " EXEC TaiKhoanSelect";            // lấy dữ liệu tất cả nhân viên
            DataTable getTaiKhoan = new DataTable();
            getTaiKhoan = SQL_Connect.Instance.ExecuteSQL(getTKQuerry);
            return getTaiKhoan;
        }
        static public bool themTaiKhoan(TaiKhoan tk)
        {
            bool isSuccess = true;
            try
            {
                
             
                    string themTKQuerry = "INSERT ACCOUNT VALUES ("+ tk.MaNV + ",N'" + tk.EMail + "',N'" + tk.taiKhoan + "',N'" + tk.MatKhau + "')";
                    SQL_Connect.Instance.ExecuteNONquerrySQL(themTKQuerry);
               
            }
            catch
            {
                isSuccess = false;
            }
            return isSuccess;
        }
        static public bool updateTaiKhoan(TaiKhoan tk)
        {
            bool isSuccess = true;

            try
            {
               
                    string updateTKQuerry = "UPDATE ACCOUNT SET EMAIL = N'" + tk.EMail + "', MATKHAU = N'" + tk.MatKhau + "' WHERE MATK =" + tk.MaTK;
                    SQL_Connect.Instance.ExecuteNONquerrySQL(updateTKQuerry);
                
            }
            catch
            {
                isSuccess = false;
            }
            return isSuccess;
        }
        static public bool xoaTaiKhoan(string ma)
        {
            bool isSuccess = true;
            try
            {
                string deleteTKQuerry = "DELETE ACCOUNT WHERE MATK = " + ma;
                SQL_Connect.Instance.ExecuteNONquerrySQL(deleteTKQuerry);
            }
            catch
            {
                isSuccess = false;
            }
            return isSuccess;
        }
    }
}
