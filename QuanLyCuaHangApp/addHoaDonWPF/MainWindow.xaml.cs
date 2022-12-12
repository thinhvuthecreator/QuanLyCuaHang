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
using SQL_Connection;
using Models;
namespace addHoaDonWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int soLuong = 0;
        List<danhSachSanPham> dsSP = new List<danhSachSanPham>();
        public MainWindow()
        {
            InitializeComponent();


            loadNVcmb();
            loadKHcmb();
            loadSPcmb();

        }
        #region object
        public class danhSachSanPham
        {
            public string tenSP { get; set; }
            public int SoLuong { get; set; }
            public decimal gia { get; set; }

        }
        public class NhanVienAo
        {
            public int maNV { get; set; }
            public string tenNV { get; set; }
            public NhanVienAo()
            {

            }
            public NhanVienAo(int ma, string ten)
            {
                maNV = ma;
                tenNV = ten;
            }
        }

        public class KhachHangAo
        {
            public int maKH { get; set; }
            public string tenKH { get; set; }
            KhachHangAo()
            {

            }
            public KhachHangAo(int ma, string ten)
            {
                maKH = ma;
                tenKH = ten;
            }
        }

        public class SanPhamAo
        {
            public int maSP { get; set; }
            public string tenSP { get; set; }
            SanPhamAo()
            {

            }
            public SanPhamAo(int ma, string ten)
            {
                maSP = ma;
                tenSP = ten;
            }
        }
        #endregion

        #region methods

        void loadNVcmb()
        {
            List<NhanVienAo> listNV = new List<NhanVienAo>();
            string laytenNVQuerry = "SELECT MANV,TENNV FROM NHANVIEN";
            DataTable dataNhanvien = SQL_Connect.Instance.ExecuteSQL(laytenNVQuerry);

            foreach (DataRow data in dataNhanvien.Rows)
            {
                
                NhanVienAo nvAo = new NhanVienAo(int.Parse(data[0].ToString()), data[1].ToString());
                listNV.Add(nvAo);
            }

            nhanVienCombobox.ItemsSource = listNV;
            nhanVienCombobox.DisplayMemberPath = "tenNV";
            nhanVienCombobox.SelectedValuePath = "maNV";
        }

        void  loadKHcmb()
        {
            List<KhachHangAo> listKH = new List<KhachHangAo>();
            string laytenKHQuerry = "SELECT MAKH,TENKH FROM KHACHHANG";
            DataTable dataKH = SQL_Connect.Instance.ExecuteSQL(laytenKHQuerry);

            foreach (DataRow data in dataKH.Rows)
            {

                KhachHangAo khAo = new KhachHangAo(int.Parse(data[0].ToString()), data[1].ToString());
                listKH.Add(khAo);
            }

            khachhangCombobox.ItemsSource = listKH;
            khachhangCombobox.DisplayMemberPath = "tenKH";
            khachhangCombobox.SelectedValuePath = "maKH";
        }

        void loadSPcmb()
        {
            List<SanPhamAo> listSP = new List<SanPhamAo>();
            string laytenSPQuerry = "SELECT MASP,TENSP FROM SANPHAM";
            DataTable dataSP = SQL_Connect.Instance.ExecuteSQL(laytenSPQuerry);

            foreach (DataRow data in dataSP.Rows)
            {

                SanPhamAo spAo = new SanPhamAo(int.Parse(data[0].ToString()), data[1].ToString());
                listSP.Add(spAo);
            }

            sanPhamCombobox.ItemsSource = listSP;
            sanPhamCombobox.DisplayMemberPath = "tenSP";
            sanPhamCombobox.SelectedValuePath = "maSP";
        }

        int layMaNV()
        {
            return int.Parse(nhanVienCombobox.SelectedValue.ToString());
        }

        int layMaKH()
        {
            return int.Parse(khachhangCombobox.SelectedValue.ToString());
        }
        #endregion
        void themSPListView()
        {
            decimal Gia = 0;

            soLuong++;

            DataTable data = SQL_Connect.Instance.ExecuteSQL("SELECT GIA FROM SANPHAM WHERE MASP = " + sanPhamCombobox.SelectedValue);

            foreach (DataRow dt in data.Rows)
            {
                Gia = decimal.Parse(dt[0].ToString());
            }

            danhSachSanPham ds = new danhSachSanPham();
            ds.tenSP = sanPhamCombobox.Text;
            ds.gia = Gia;
            ds.SoLuong = soLuong;
            dsSP.Add(ds);                 // dsSP là List<danhsachsanpham>
            dsSPListview.Items.Add(ds);
        }

        #region events
       

       

        private void addHDBtn_Click(object sender, RoutedEventArgs e)
        {
            HoaDon hd = new HoaDon();
            hd.TriGia = int.Parse(tongtriGiaTextbox.Text);
            hd.MaKH = layMaKH();
            hd.MaNV = layMaNV();
        }

        #endregion 

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {

            themSPListView();
           
        }

        private void reduceBtn_Click(object sender, RoutedEventArgs e)
        {
            if (soLuong == 0)
            {
                MessageBox.Show("Không có sản phẩm này trong giỏ hàng !");
            }
            else
            {
                soLuong--;
                MessageBox.Show(soLuong.ToString());
            }
        }

        private void huyThemHDBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
