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
    static public class KhuyenMai_DAL
    {
        static public DataTable loadDuLieuKM()
        {


            string getKMQuerry = "EXEC KhuyenMaiSelect";            // lấy dữ liệu tất cả nhân viên
            DataTable getKhuyenMai = new DataTable();
            getKhuyenMai = SQL_Connect.Instance.ExecuteSQL(getKMQuerry);
            return getKhuyenMai;
        }
        static public bool themKhuyenMai(Khuyenmai km)
        {

            bool isSuccess = true;




            try
            {
                if (km.GiaTriDK == -1 || km.GiaTriKM == -1)
                {
                    return false;
                }
                else
                {
                    string addKMQuerry = "INSERT KHUYENMAI VALUES (" + km.GiaTriKM + "," + km.GiaTriDK + ")";
                    SQL_Connect.Instance.ExecuteNONquerrySQL(addKMQuerry);
                }
            }
            catch
            {
                isSuccess = false;
            }


            return isSuccess;
        }
        static public bool updateKhuyenMai(Khuyenmai km)
        {
            bool isSuccess = true;

            if (km.GiaTriDK == -1 || km.GiaTriKM == -1)
            {
                return false;
            }

            try
            {
                string updateKMQuerry = "UPDATE KHUYENMAI SET GIATRIDIEUKIEN = " + km.GiaTriDK + ", GIATRIKM = " + km.GiaTriKM + " WHERE MAKM =" + km.MaKM;
                SQL_Connect.Instance.ExecuteNONquerrySQL(updateKMQuerry);
            }
            catch
            {
                isSuccess = false;
            }
            return isSuccess;
        }
        static public bool xoaKhuyenMai(int maKM)
        {
            bool isSuccess = true;
            try
            {
                string deleteKMQuerry = "DELETE FROM KHUYENMAI WHERE MAKM = " + maKM;
                SQL_Connect.Instance.ExecuteNONquerrySQL(deleteKMQuerry);
            }
            catch
            {
                isSuccess = false;
            }
            return isSuccess;
        }


    }
}
