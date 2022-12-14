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
using Models;
using SQL_Connection;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Win32;

namespace QuanLyKhachHangWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            loadDuLieuKHListView();
            loadImages();
            loadGioiTinhCombobox();
            loadTimKiemCmb();
        }
        #region objects
        #endregion

        #region methods
        void loadImages()
        {
            string resourceImage1 = System.IO.Path.GetFullPath("imageDefault.jpg");
            BitmapImage logoStaff = new BitmapImage();
            logoStaff.BeginInit();
            logoStaff.UriSource = new Uri(resourceImage1);
            logoStaff.EndInit();
            khImage.Source = logoStaff;



        }
        void loadDuLieuKHListView()
        {
            List<KhachHang> listKH = new List<KhachHang>();
            DataTable dataKhachHang = KhachHang_DAL.loadDuLieuKH();
            foreach (DataRow khachhangData in dataKhachHang.Rows)
            {
                listKH.Add(new KhachHang() { MaKH = int.Parse(khachhangData[0].ToString()), TenKH = khachhangData[1].ToString(), SdtKH = int.Parse(khachhangData[4].ToString()), DoanhSoKH = decimal.Parse(khachhangData[5].ToString()), GioiTinhKH = khachhangData[3].ToString(), NgSinhKH = DateTime.Parse(khachhangData[2].ToString()), FileAnh = khachhangData[6].ToString() });
            }
            khachhangListView.ItemsSource = listKH;
            khachhangListView.SelectedIndex = 0;
        }
        string xuLyChuoi(string s)
        {
            if (s == "")
            {
                string fileAnhmacDinh = System.IO.Path.GetFullPath("staff.jpg");

                s = fileAnhmacDinh;
            }
            else
            {
                s = s.Remove(0, 8);
            }
            return s;
        }
        void loadGioiTinhCombobox()
        {
            List<string> gioiTinh = new List<string> { "Nam", "Nữ" };
            gioiTinhKHCombobox.ItemsSource = gioiTinh;


        }
        void loadTimKiemCmb()
        {
            List<string> danhMuc = new List<string> { "ID", "Tên", "SDT", "Doanh số", "Giới tính" };
            timKiemCmb.ItemsSource = danhMuc;
            timKiemCmb.SelectedIndex = 0;
        }


        #endregion

        #region events
        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            AddKhachHangWPF.MainWindow themKHWindow = new AddKhachHangWPF.MainWindow();
            themKHWindow.Show();
        }
        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult decicion = MessageBox.Show("Bạn có muốn xóa khách hàng này không ?", "", MessageBoxButton.YesNo);
            if (decicion == MessageBoxResult.Yes)
            {
                if (KhachHang_DAL.xoaKhachHang(int.Parse(maKHTxtbox.Text)))
                {
                    MessageBox.Show("Xóa thành công !");
                }
                else
                {
                    MessageBox.Show("Xóa thất bại ! Tài khoản nhân viên còn tồn tại trong hệ thống");
                }
            }
        }
        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            KhachHang khUpdate = new KhachHang();
            khUpdate.MaKH = int.Parse(maKHTxtbox.Text);
            khUpdate.TenKH = tenKHTxtbox.Text;
            khUpdate.SdtKH = int.Parse(sdtKHTxtbox.Text);
            khUpdate.NgSinhKH = DateTime.Parse(ngSinhKHDatePicker.Text);
            khUpdate.GioiTinhKH = gioiTinhKHCombobox.Text;
            khUpdate.FileAnh = khImage.Source.ToString();
            khUpdate.DoanhSoKH = decimal.Parse(doanhsoKHTxtbox.Text);

            if (KhachHang_DAL.updateKhachHang(khUpdate) == true)
            {
                MessageBox.Show("Cập nhật thành công !");
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại !");
            }
        }
        private void khImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog imageChoose = new OpenFileDialog();
            if (imageChoose.ShowDialog() == true)
            {

                string sourceAnh = imageChoose.FileName;
                string sourceAnhApp = System.IO.Path.GetFullPath(System.IO.Path.GetFileName(imageChoose.FileName));
                System.IO.File.Copy(sourceAnh, sourceAnhApp, true);
                Uri fileUri = new Uri(sourceAnhApp);
                khImage.Source = new BitmapImage(fileUri);
            }
        }
        private void khachhangListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            KhachHang kh = (KhachHang)khachhangListView.SelectedItem;

            if (kh == null)
            {

            }
            else
            {


                string fileAnh = kh.FileAnh != null ? kh.FileAnh : System.IO.Path.GetFullPath("staffWPF.jpg");

                string resourceImage1 = xuLyChuoi(fileAnh);
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.UriSource = new Uri(resourceImage1);
                image.EndInit();


                maKHTxtbox.Text = kh.MaKH.ToString();
                tenKHTxtbox.Text = kh.TenKH;
                sdtKHTxtbox.Text = kh.SdtKH.ToString();
                doanhsoKHTxtbox.Text = kh.DoanhSoKH.ToString();
                gioiTinhKHCombobox.Text = kh.GioiTinhKH;
                ngSinhKHDatePicker.Text = kh.NgSinhKH.ToString();
                khImage.Source = image;
            }
        }
        private void Window_Activated(object sender, EventArgs e)
        {
            loadDuLieuKHListView();
        }

        private void timKiemTxtbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string Querry = "";
            if (timKiemCmb.SelectedIndex == 0)
            {
                Querry = "SELECT * FROM KHACHHANG WHERE MAKH LIKE '%" + timKiemTxtbox.Text + "%'";
            }
            else if (timKiemCmb.SelectedIndex == 1)
            {
                Querry = "SELECT * FROM KHACHHANG WHERE TENKH LIKE N'%" + timKiemTxtbox.Text + "%'";
            }
            else if (timKiemCmb.SelectedIndex == 2)
            {
                Querry = "SELECT * FROM KHACHHANG WHERE SDTKH LIKE '%" + timKiemTxtbox.Text + "%'";
            }
            else if (timKiemCmb.SelectedIndex == 3)
            {
                Querry = "SELECT * FROM KHACHHANG WHERE DOANHSO LIKE '%" + timKiemTxtbox.Text + "%'";
            }
            else if (timKiemCmb.SelectedIndex == 4)
            {
                Querry = "SELECT * FROM KHACHHANG WHERE GIOITINH LIKE N'%" + timKiemTxtbox.Text + "%'";
            }
            List<KhachHang> listKH = new List<KhachHang>();
            DataTable dataKhachHang = SQL_Connect.Instance.ExecuteSQL(Querry);
            foreach (DataRow khachhangData in dataKhachHang.Rows)
            {
                try
                {
                    listKH.Add(new KhachHang() { MaKH = int.Parse(khachhangData[0].ToString()), TenKH = khachhangData[1].ToString(), SdtKH = int.Parse(khachhangData[4].ToString()), DoanhSoKH = decimal.Parse(khachhangData[5].ToString()), GioiTinhKH = khachhangData[3].ToString(), NgSinhKH = DateTime.Parse(khachhangData[2].ToString()), FileAnh = khachhangData[6].ToString() });
                }
                catch
                {

                }
            }
            khachhangListView.ItemsSource = listKH;
            khachhangListView.SelectedIndex = 0;
        }










        #endregion

    }
}

