using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace SQL_Connection
{

    public class SQL_Connect
    {
        string stringConnection = @"Data Source=.\sqlexpress;Initial Catalog=QLBH_Nhom4;Integrated Security=True";

        private static SQL_Connect instance;
        public static SQL_Connect Instance
        {
            get { if (SQL_Connect.instance == null) SQL_Connect.instance = new SQL_Connect(); return SQL_Connect.instance; }
            private set { SQL_Connect.instance = value; }
        }
        private SQL_Connect() { }

        public DataTable ExecuteSQL(string stringQuerry)
        {
            SqlConnection QuanLyBanHangSQLconnection = new SqlConnection(stringConnection);
            SqlCommand querry = new SqlCommand(stringQuerry, QuanLyBanHangSQLconnection);
            SqlDataAdapter temporature = new SqlDataAdapter(querry);
            DataTable dataReturn = new DataTable();
            temporature.Fill(dataReturn);
            return dataReturn;
        }   // thực hiện câu truy vấn sql trả ra 1 datatable;
        public void ExecuteNONquerrySQL(string stringQuerry)
        {
            SqlConnection QuanLyBanHangSQLconnection = new SqlConnection(stringConnection);
            SqlCommand querry = new SqlCommand(stringQuerry, QuanLyBanHangSQLconnection);
            QuanLyBanHangSQLconnection.Open();
            querry.ExecuteNonQuery();
            QuanLyBanHangSQLconnection.Close();

        }   // thực hiện câu truy vấn sql không trả ra gì cả

        public bool Login(string user, string pass)
        {
            string AccountSelectQuerry = "EXEC AccountSelect @taikhoan = N' " + user + " ' , " + "@matkhau = N'" + pass + "'";
            DataTable AccountExistCount = SQL_Connect.instance.ExecuteSQL(AccountSelectQuerry);

            return AccountExistCount.Rows.Count > 0;
        }  //xem co ket qua nao thoa man khong, neu co thi dang nhap thanh cong
    }
}

