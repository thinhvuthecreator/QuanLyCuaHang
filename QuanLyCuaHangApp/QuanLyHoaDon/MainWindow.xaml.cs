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
            hoadonListView.SelectedIndex = 0;
            // loadDuLieuHDListView();
            // loadDuLieuCTHDListView();
        }

        #region objects
        class HoaDonView
        {
            public int soHD { get; set; }
            public string tenNV { get; set; }
            public string tenKH { get; set; } 
            public decimal triGia { get; set; }
            public int giaTriKM { get; set; }
            public decimal  triGiaSauKM { get; set; }
            public DateTime ngHD { get; set; }

        }
        class HoaDonAboveView
        {
            public int soHD;
            public string tenNV;
            public string tenKH;
            public string ngHD;
            public decimal triGia;

        }
        class CTHDView
        {
            public string TenSP { get; set; }
            public decimal DonGia { get; set; }
            public int SoLuong { get; set; }
        }
        #endregion

        #region methods
        void loadDuLieuHDListView()
        {
            hoadonListView.ItemsSource = null;
            List<HoaDonView> listHD = new List<HoaDonView>();
            DataTable dataHD = SQL_Connect.Instance.ExecuteSQL("SELECT SOHD,TENNV,TENKH,NGHD,TRIGA,GIATRIKM,TRIGIASAUKM FROM HOADON AS HD INNER JOIN NHANVIEN AS NV ON HD.MANV = NV.MANV INNER JOIN KHACHHANG AS KH ON HD.MAKH = KH.MAKH LEFT JOIN KHUYENMAI AS KM ON HD.MAKM = KM.MAKM");
            foreach (DataRow HDdata in dataHD.Rows)
            {
                listHD.Add(new HoaDonView() { soHD = int.Parse(HDdata[0].ToString()), tenNV = HDdata[1].ToString(), tenKH = HDdata[2].ToString(), ngHD = DateTime.Parse(HDdata[3].ToString()), triGia = decimal.Parse(HDdata[4].ToString()), giaTriKM = HDdata[5].ToString() != "" ? int.Parse(HDdata[5].ToString()) : 0, triGiaSauKM = decimal.Parse(HDdata[6].ToString())});
            }
            hoadonListView.ItemsSource = listHD;
            CTHDListView.SelectedIndex = 0;
        }
        void loadDuLieuCTHDListView(int soHD)
        {
            CTHDListView.ItemsSource = null;
            List<CTHDView> cthdList = new List<CTHDView>();
            DataTable dataCTHD = CTHD_DAL.loadDuLieuCTHD(soHD);
            foreach (DataRow row in dataCTHD.Rows)
            {
                cthdList.Add(new CTHDView { TenSP = row[0].ToString(), DonGia = decimal.Parse(row[1].ToString()),SoLuong = int.Parse(row[2].ToString()) });
            }
            CTHDListView.ItemsSource = cthdList;
            CTHDListView.SelectedIndex = 0;
        }
        #endregion

        #region events
        private void hoadonListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            HoaDonView hd = (HoaDonView)hoadonListView.SelectedItem;
            if (hd == null)
            {

            }
            else
            {
                soHDTextBox.Text = hd.soHD.ToString();
                nvTextbox.Text = hd.tenNV;
                khTextbox.Text = hd.tenKH;
                ngHdTextBox.Text = hd.ngHD.ToString();
                triGiaHDTextbox.Text = hd.triGia.ToString();
                kmTextbox.Text = hd.giaTriKM.ToString();
                triGiaHDSauKMTextbox.Text = hd.triGiaSauKM.ToString();
                loadDuLieuCTHDListView(hd.soHD);
                CTHDListView.SelectedIndex = 0;
            }
        }
        private void CTHDListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CTHDView cthd = (CTHDView)CTHDListView.SelectedItem;   // chương trình chạy vào đây trước ? 
           
            if(cthd == null)
            {
               
            }
            else
            {
                spTextBox.Text = cthd.TenSP;
                donGiaTextbox.Text = cthd.DonGia.ToString();
                soLuongTextBox.Text = cthd.SoLuong.ToString();
            }
           
        }
        private void addHDButton_Click(object sender, RoutedEventArgs e)
        {
            addHoaDonWPF.MainWindow addHoaDonWindow = new addHoaDonWPF.MainWindow();
            addHoaDonWindow.Show();
        }
        private void Window_Activated(object sender, EventArgs e)
        {
            loadDuLieuHDListView(); 
        }
        private void deleteHDButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult decicion = MessageBox.Show("Bạn có muốn xóa hóa đơn này không ?", "", MessageBoxButton.YesNo);
            if (decicion == MessageBoxResult.Yes)
            {
               
                string deleteHDfromCTHD_Querry = "DELETE FROM CTHD WHERE SOHD =" + soHDTextBox.Text;
                SQL_Connect.Instance.ExecuteNONquerrySQL(deleteHDfromCTHD_Querry);
                if (HoaDon_DAL.xoaHoaDon(soHDTextBox.Text))
                {
                    MessageBox.Show("Xóa thành công !");
                }
                else
                {
                    MessageBox.Show("Xóa thất bại !");
                }
            }
            else
            {

            }
        }

        #endregion

    }
}
