using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SQL_Connection;
using Models;
using System.Data;
using System.Data.SqlClient;

namespace ThongKe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            loadListThongKeSP();
            loadThongTinDongTien();
        }
         
        #region objects
        public class sanPham
        {
            public int maSP { get; set; }
            public string tenSP { get; set; }
            public int soluongNhap { get; set; }
            public int soluongBan { get; set; }
            public sanPham()
            {
                soluongBan = 0;
            }
        }
        #endregion

        #region methods
        string luongNV()
        {
            decimal luong = 0;
            DataTable data = SQL_Connect.Instance.ExecuteSQL("SELECT SUM(LUONG) FROM NHANVIEN");
            if (decimal.TryParse(data.Rows[0][0].ToString(),out luong) == false)
            {
                return "0";
            }
            else
            {
                return data.Rows[0][0].ToString();
            }
        }
        string tienNhapHang()
        { 

            decimal tien = 0;
            DataTable data = SQL_Connect.Instance.ExecuteSQL("SELECT SUM(GIA) FROM SANPHAM");
            if (decimal.TryParse(data.Rows[0][0].ToString(), out tien) == false)
            {
                return "0";
            }
            else
            {
                return data.Rows[0][0].ToString();
            }
        }
        string doanhThu()
        {
            decimal doanhthu = 0;
            DataTable data = SQL_Connect.Instance.ExecuteSQL("SELECT SUM(TRIGIASAUKM) FROM HOADON");
            if (decimal.TryParse(data.Rows[0][0].ToString(), out doanhthu) == false)
            {
                return "0";
            }
            else
            {
                return data.Rows[0][0].ToString();
            }
        }
        string lai()
        {
            return (decimal.Parse(doanhThu()) - (decimal.Parse(luongNV()) + decimal.Parse(tienNhapHang()))).ToString();
        }

        void loadThongTinDongTien()
        {
            luongNVTextblock.Text = luongNV() + " VND";
            tienHangTextblock.Text = tienNhapHang() + " VND";
            doanhthuTextblock.Text = doanhThu() + " VND";
            laiTextblock.Text = lai() + " VND";
        }
        void loadListThongKeSP()
        {
            List<sanPham> listSP = new List<sanPham>();
            
            DataTable dataTatCaSP = SQL_Connect.Instance.ExecuteSQL("SELECT MASP,TENSP,SOLUONGSP FROM SANPHAM");
            foreach(DataRow row in dataTatCaSP.Rows)
            {
                listSP.Add(new sanPham { maSP = int.Parse(row[0].ToString()),tenSP = row[1].ToString(), soluongNhap = int.Parse(row[2].ToString())});
            }

            DataTable dataSP_in_CTHD = SQL_Connect.Instance.ExecuteSQL("SELECT MASP,SUM(SOLUONG) as BANDUOC FROM CTHD GROUP BY MASP");
            foreach (sanPham sp in listSP)
            {
                foreach (DataRow row in dataSP_in_CTHD.Rows)
                {
                    if(sp.maSP == int.Parse(row[0].ToString()))
                    {
                        sp.soluongBan = int.Parse(row[1].ToString());
                    }
                }
            }
            listSP_Listview.ItemsSource = listSP;
        }

        #endregion

    }




}
