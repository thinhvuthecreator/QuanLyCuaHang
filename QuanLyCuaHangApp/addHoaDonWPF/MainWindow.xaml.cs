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
        decimal timGiaTriDK_Max(List<decimal> list)
        {
            decimal max = list[0];
            for(int i = 0; i < list.Count;i++)
            {
                if(max <= list[i])
                {
                    max = list[i];
                }
            }
            return max;
        }
        string xuLyChuoi(string s)
        {
            string outPut = "";
            if (s.Contains("V"))
            {
                outPut = s.Remove(s.IndexOf(" "), 4);
            }
            else if (s.Contains("."))
            {
                outPut = s.Remove(s.IndexOf("."), 5);
            }
            return outPut;
        }
        int upDateGia(string tenSP, int sl) // đã OK !! chỉ cần update lại
        {
            int soLanXuatHien = 0;
            int ketQua = 0;
            for(int i =0; i < dsSPListview.Items.Count;i++) 
            {
                danhSachSanPham sp = (danhSachSanPham)dsSPListview.Items[i];
                if(tenSP == sp.tenSP)
                {
                   soLanXuatHien++;
                    if (soLanXuatHien <= 1)
                    {
                        dsSPListview.Items.Remove(dsSPListview.Items[i]);
                        sp.SoLuong += sl;
                        dsSPListview.Items.Add(sp);
                        ketQua = sp.SoLuong;
                    }
                    else
                    {

                    }
                }
                 
            }

            return ketQua;
        }
                   
        bool checkTrung(string tenSP)          
        {
            if (dsSPListview.Items.IsEmpty)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < dsSPListview.Items.Count; i++)           
                {
                    danhSachSanPham data = (danhSachSanPham)dsSPListview.Items[i];                   
                    if (tenSP == data.tenSP)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
                    
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
       
        void themSPListView() // thêm 1 sản phẩm vào danh sách sản phẩm

        {
                #region layGia
                decimal Gia = 0;
                DataTable data = SQL_Connect.Instance.ExecuteSQL("SELECT GIA FROM SANPHAM WHERE MASP = " + sanPhamCombobox.SelectedValue);
                foreach (DataRow dt in data.Rows)
                {
                    Gia = decimal.Parse(dt[0].ToString());
                }
                #endregion
                danhSachSanPham ds = new danhSachSanPham();  
                ds.tenSP = sanPhamCombobox.Text;
                ds.gia = Gia;
                ds.SoLuong = 1;
                dsSPListview.Items.Add(ds);
        }



        bool themDoanhSoKH(decimal triGia,int maKH)
        {
            bool isSuccess = true;
            try
            {
                string addDoanhSoKHQuerry = "UPDATE KHACHHANG SET DOANHSO = " + triGia + " WHERE MAKH =" + maKH;
                SQL_Connect.Instance.ExecuteNONquerrySQL(addDoanhSoKHQuerry);
            }
            catch
            {
                isSuccess = false;
            }
            return isSuccess;
        }
        int layMaKM(int giaTriKM)
        {
            if (kmTextBlock.Visibility == Visibility.Hidden)
            {
                return -1;
            }
            else
            {
                DataTable dataKM = KhuyenMai_DAL.loadDuLieuKM();
                foreach (DataRow row in dataKM.Rows)
                {
                    if (giaTriKM == int.Parse(row[1].ToString()))
                    {
                        return int.Parse(row[0].ToString());
                    }
                }
                return -1;
            }
        }
        int layGiaTriKM(decimal giaTriDK)
        {
            int giaTriKM;
            DataTable data = SQL_Connect.Instance.ExecuteSQL("SELECT GIATRIKM FROM KHUYENMAI WHERE GIATRIDIEUKIEN =" + giaTriDK);
            giaTriKM = int.Parse(data.Rows[0][0].ToString());
            return giaTriKM;
        }
          
            
        #endregion

       
        #region events
        
        private void addBtn_Click(object sender, RoutedEventArgs e)
        {

            #region capNhatDS
            int soLuong = 1;
            // nếu có rồi thì update giá
            if (checkTrung(sanPhamCombobox.Text))
            {
               
                upDateGia(sanPhamCombobox.Text,soLuong);
               
            }
            else  // chưa có thì thêm mới
            {
                themSPListView();
            }
            #endregion
            #region capNhatTriGiaTextBox

            decimal tongTriGia = 0;
            
           
            for(int i = 0; i < dsSPListview.Items.Count;i++)
            {
                danhSachSanPham sp = (danhSachSanPham)dsSPListview.Items[i];
                tongTriGia += sp.gia * sp.SoLuong;
            }

            tongtriGiaTextbox.Text = tongTriGia.ToString().Remove(tongTriGia.ToString().IndexOf(".")) + " VND";
          
            #endregion
        }
        private void reduceBtn_Click(object sender, RoutedEventArgs e)
        {
            #region capNhatDS
            int soLuong = -1;      
            if(upDateGia(sanPhamCombobox.Text, soLuong) == 0)
            {
                for(int i = 0; i < dsSPListview.Items.Count;i++)
                {
                    danhSachSanPham SP = (danhSachSanPham)dsSPListview.Items[i];
                    if(SP.tenSP == sanPhamCombobox.Text)
                    {
                        dsSPListview.Items.Remove(dsSPListview.Items[i]);
                    }
                }
            }
            #endregion

            #region capNhatTriGiaTextBox
            decimal tongTriGia = 0;
            for (int i = 0; i < dsSPListview.Items.Count; i++)
            {
                danhSachSanPham sp = (danhSachSanPham)dsSPListview.Items[i];
                tongTriGia += sp.gia * sp.SoLuong;
            }

            tongtriGiaTextbox.Text = tongTriGia > 0 ?  tongTriGia.ToString().Remove(tongTriGia.ToString().IndexOf(".")) + " VND" : "0";
          
            #endregion



        }
        private void huyThemHDBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void addHDBtn_Click(object sender, RoutedEventArgs e)
        {
            #region themHoaDon
            decimal tongTriGia = 0;

            for (int i = 0; i < dsSPListview.Items.Count; i++)
            {
                danhSachSanPham sp = (danhSachSanPham)dsSPListview.Items[i];
                tongTriGia += sp.gia * sp.SoLuong;
            }

            HoaDon hd = new HoaDon();
            hd.MaKH = layMaKH();
            hd.MaNV = layMaNV();
            hd.TriGia = tongTriGia;
            hd.NgHoaDon = DateTime.Parse(ngHoaDonDatePicker.Text);
            if (kmCheckBox.IsChecked == true && tongtriGiaTextbox.Text != "0")
            {
                hd.MaKM = layMaKM(int.Parse(kmTextBlock.Text));   
            }
            else
            {
                hd.MaKM = -1;
            }
            hd.TriGiaSauKM = decimal.Parse(xuLyChuoi(tongtriGiaSauKMTextbox.Text));
          
            if (HoaDon_DAL.themHoaDon(hd) && themDoanhSoKH(hd.TriGia, hd.MaKH))
            {
                if(hd.MaKM != -1)
                {
                   DataTable soHDCuaHDMoiThemVao = SQL_Connect.Instance.ExecuteSQL("SELECT SOHD FROM HOADON WHERE SOHD = (SELECT MAX(SOHD) FROM HOADON)");
                   int soHD = int.Parse(soHDCuaHDMoiThemVao.Rows[0][0].ToString());
                   HoaDon_DAL.capNhatKhuyenMai(hd.MaKM, soHD);
                }
                MessageBox.Show("Thêm thành công !");
                this.Close(); 
            }
            else
            {
                MessageBox.Show("Thêm thất bại !");
            }
            #endregion

            #region themCTHD
            string layMAHD = "SELECT MAX(SOHD) FROM HOADON";
            DataTable data = SQL_Connect.Instance.ExecuteSQL(layMAHD);
            DataRow dataRow = data.Rows[0];
            string SoHD = dataRow[0].ToString();   //lấy dc số hóa đơn, --> còn mã sản phẩm, số lượng
            for(int i = 0; i < dsSPListview.Items.Count; i++)
            {
                
                danhSachSanPham sp = (danhSachSanPham)dsSPListview.Items[i];
                string layMASP = "SELECT MASP FROM SANPHAM WHERE TENSP = N'" + sp.tenSP + "'";
                DataTable dataMASP = SQL_Connect.Instance.ExecuteSQL(layMASP);
                DataRow dataRowMASP = dataMASP.Rows[0];
                string MaSP = dataRowMASP[0].ToString();
                CTHD cthd = new CTHD();
                cthd.MaHD = int.Parse(SoHD);
                cthd.MaSP = int.Parse(MaSP);
                cthd.SoLuong = sp.SoLuong;
                CTHD_DAL.themCTHD(cthd);
            }
            #endregion

        }

        private void kmCheckBox_Click(object sender, RoutedEventArgs e)
        {
            int giaTriKM_MaxPossible = 0;
            List<decimal> giaTriDKList = new List<decimal>();
            if (tongtriGiaTextbox.Text == "0")
            {
                kmTextBlock.Visibility = Visibility.Hidden;
                tongtriGiaSauKMTextbox.Text = tongtriGiaTextbox.Text;
            }
            else
            {
                if (kmCheckBox.IsChecked == true)
                {
                    kmTextBlock.Visibility = Visibility.Visible;
                    DataTable dataKm = KhuyenMai_DAL.loadDuLieuKM();
                    
                    for (int i = 0; i < dataKm.Rows.Count; i++)
                    {
                       
                       if (decimal.Parse(xuLyChuoi(tongtriGiaTextbox.Text)) >= decimal.Parse(dataKm.Rows[i][2].ToString()))
                       {
                            giaTriDKList.Add(decimal.Parse(dataKm.Rows[i][2].ToString()));
                       }
                       
                    }
                    decimal giaTriDKMax = timGiaTriDK_Max(giaTriDKList);
                    giaTriKM_MaxPossible = layGiaTriKM(giaTriDKMax);
                    kmTextBlock.Text = giaTriKM_MaxPossible.ToString();
                    tongtriGiaSauKMTextbox.Text = (decimal.Parse(xuLyChuoi(tongtriGiaTextbox.Text)) - (decimal.Parse(xuLyChuoi(tongtriGiaTextbox.Text)) * giaTriKM_MaxPossible) / 100).ToString() + " VND";
                }
                else
                {
                    tongtriGiaSauKMTextbox.Text = tongtriGiaTextbox.Text;
                    kmTextBlock.Visibility = Visibility.Hidden;
                }
            }


        }
        private void tongtriGiaTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int giaTriKM_MaxPossible = 0;
            List<decimal> giaTriDKList = new List<decimal>();
            if (tongtriGiaTextbox.Text == "0")
            {
                kmTextBlock.Visibility = Visibility.Hidden;
                tongtriGiaSauKMTextbox.Text = tongtriGiaTextbox.Text;
            }
            else
            {
                if (kmCheckBox.IsChecked == true)
                {
                    kmTextBlock.Visibility = Visibility.Visible;
                    DataTable dataKm = KhuyenMai_DAL.loadDuLieuKM();

                    for (int i = 0; i < dataKm.Rows.Count; i++)
                    {

                        if (decimal.Parse(xuLyChuoi(tongtriGiaTextbox.Text)) >= decimal.Parse(dataKm.Rows[i][2].ToString()))
                        {
                            giaTriDKList.Add(decimal.Parse(dataKm.Rows[i][2].ToString()));
                        }

                    }
                    decimal giaTriDKMax = timGiaTriDK_Max(giaTriDKList);
                    giaTriKM_MaxPossible = layGiaTriKM(giaTriDKMax);
                    kmTextBlock.Text = giaTriKM_MaxPossible.ToString();
                    tongtriGiaSauKMTextbox.Text = (decimal.Parse(xuLyChuoi(tongtriGiaTextbox.Text)) - (decimal.Parse(xuLyChuoi(tongtriGiaTextbox.Text)) * giaTriKM_MaxPossible) / 100).ToString() + " VND";
                }
                else
                {
                    tongtriGiaSauKMTextbox.Text = tongtriGiaTextbox.Text;
                    kmTextBlock.Visibility = Visibility.Hidden;
                }
            }

        }

        #endregion

    }
}
