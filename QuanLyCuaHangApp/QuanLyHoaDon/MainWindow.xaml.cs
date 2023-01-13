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
using System.Data;
using System.Data.SqlClient;
using Models;
using SQL_Connection;

namespace QuanLyHoaDon
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            loadDuLieuHDListView();
        }

        #region objects
        class HoaDonView
        {
            public int soHD;
            public string tenSP;
            public decimal donGia, tongTriGia;
            public int soLuong, khuyenMai;
            
        }
        class HoaDonAboveView
        {
            public int soHD;
            public string tenNV;
            public string tenKH;
            public string ngHD;
            public decimal triGia;

        }
        #endregion

        #region methods
        void loadDuLieuHDListView()
        {
            List<HoaDonView> listHD = new List<HoaDonView>();
            DataTable dataHD = SQL_Connect.Instance.ExecuteSQL("SELECT HD.SOHD, TENSP, GIA, SOLUONG, GIATRIKM, HD.TRIGA FROM HOADON HD, CTHD CT, SANPHAM SP, KHUYENMAI KM WHERE HD.SOHD = CT.SOHD AND  CT.MASP = SP.MASP AND HD.MAKM = KM.MAKM");
            foreach (DataRow HDdata in dataHD.Rows)
            {
                listHD.Add(new HoaDonView() { soHD = int.Parse(HDdata[0].ToString()), tenSP = HDdata[1].ToString(), donGia = decimal.Parse(HDdata[2].ToString()), soLuong = int.Parse(HDdata[3].ToString()), khuyenMai = int.Parse(HDdata[4].ToString()), tongTriGia = decimal.Parse(HDdata[5].ToString()) });
            }
            hoadonListView.ItemsSource = listHD;
            hoadonListView.SelectedIndex = 0;
        }
        #endregion

        #region events
        private void hoadonListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            DataTable hoaDonData = SQL_Connect.Instance.ExecuteSQL("SELECT SOHD,TENNV,TENKH,NGHD,TRIGA FROM HOADON HD,NHANVIEN NV,KHACHHANG KH WHERE HD.MAKH = KH.MAKH AND HD.MANV = NV.MANV ");

            foreach(DataRow data in hoaDonData.Rows)
            {
                soHDTextBox.Text = data[0].ToString();
                nvTextbox.Text = data[1].ToString();
                khTextbox.Text = data[2].ToString();
                ngHdTextBox.Text = data[3].ToString();
                triGiaHDTextbox.Text = data[4].ToString();
            }

            DataTable cthdData = SQL_Connect.Instance.ExecuteSQL("SELECT TENSP,GIA,SOLUONG,GIATRIKM FROM CTHD CT, HOADON HD, KHUYENMAI KM,SANPHAM SP WHERE CT.SOHD = HD.SOHD AND CT.MASP = SP.MASP AND HD.SOHD = KM.SOHD");

            foreach (DataRow data in cthdData.Rows)
            {
                spTextBox.Text = data[0].ToString();
                donGiaTextbox.Text = data[1].ToString();
                soLuongTextBox.Text = data[2].ToString();
                khuyenMaiTextBox.Text = data[3].ToString();
               
            }


        }
        #endregion
    }
}
