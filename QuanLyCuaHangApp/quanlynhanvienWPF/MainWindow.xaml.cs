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
using AddStaffWPF;
using System.Data;
using System.Data.SqlClient;
using SQL_Connection;
using Models;
using System.Collections.ObjectModel;
using Microsoft.Win32;

namespace quanlynhanvienWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
      
        public MainWindow()
        {
            InitializeComponent();
            loadDuLieuNVListView();
            loadGioiTinhCombobox();
            loadImages();
        }

        #region objects
        
        #endregion

        #region methods
        void loadDuLieuNVListView()
        {
            List<NhanVien> listNV = new List<NhanVien>();
            DataTable dataNhanVien = NhanVien_DAL.loadDuLieuNV();
            foreach(DataRow nhanvienData in dataNhanVien.Rows )
            {
                listNV.Add(new NhanVien() { MaNV = int.Parse(nhanvienData[0].ToString()), TenNV = nhanvienData[1].ToString(),SdtNV = int.Parse(nhanvienData[2].ToString()),LuongNV = decimal.Parse(nhanvienData[3].ToString()),GioiTinh = nhanvienData[4].ToString(),NgSinhNV = DateTime.Parse(nhanvienData[5].ToString()),FileAnh = nhanvienData[6].ToString() });
            }
            nhanVienListView.ItemsSource = listNV;
        }
        void loadGioiTinhCombobox()
        {
            List<string> gioiTinh = new List<string> { "Nam","Nữ"};
            gioiTinhNVCombobox.ItemsSource = gioiTinh;
           
           
        }
        void loadImages()
        {
            string resourceImage1 = System.IO.Path.GetFullPath("staff.jpg");
            BitmapImage logoStaff = new BitmapImage();
            logoStaff.BeginInit();
            logoStaff.UriSource = new Uri(resourceImage1);
            logoStaff.EndInit();
            nvImage.Source = logoStaff;
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
        #endregion

        #region events
        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            AddStaffWPF.MainWindow themNVWindow = new AddStaffWPF.MainWindow();
            themNVWindow.Show();
            
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            loadDuLieuNVListView();
        }

        private void nhanVienListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
              NhanVien nv = (NhanVien)nhanVienListView.SelectedItem;

            if (nv == null)
            {

            }
            else
            {

               
                string fileAnh = nv.FileAnh != null ? nv.FileAnh : System.IO.Path.GetFullPath("staffWPF.jpg");

                string resourceImage1 = xuLyChuoi(fileAnh);
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.UriSource = new Uri(resourceImage1);
                image.EndInit();


                maNVTxtbox.Text = nv.MaNV.ToString();
                tenNVTxtbox.Text = nv.TenNV;
                sdtNVTxtbox.Text = nv.SdtNV.ToString();
                luongNVTxtbox.Text = nv.LuongNV.ToString();
                gioiTinhNVCombobox.Text = nv.GioiTinh;
                ngSinhNVDatePicker.Text = nv.NgSinhNV.ToString();
                nvImage.Source = image;
            }
         
        }


        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult decicion = MessageBox.Show("Bạn có muốn xóa nhân viên này không ?", "", MessageBoxButton.YesNo);
            if (decicion == MessageBoxResult.Yes)
            {
                if (NhanVien_DAL.xoaNhanVien(maNVTxtbox.Text))
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
            NhanVien nvUpdate = new NhanVien();
            nvUpdate.MaNV = int.Parse(maNVTxtbox.Text);
            nvUpdate.TenNV = tenNVTxtbox.Text;
            nvUpdate.SdtNV = int.Parse(sdtNVTxtbox.Text);
            nvUpdate.NgSinhNV = DateTime.Parse(ngSinhNVDatePicker.Text);
            nvUpdate.GioiTinh = gioiTinhNVCombobox.Text;
            nvUpdate.FileAnh =  nvImage.Source.ToString();
            nvUpdate.LuongNV = decimal.Parse(luongNVTxtbox.Text);

            if(NhanVien_DAL.updateNhanVien(nvUpdate) == true)
            {
                MessageBox.Show("Cập nhật thành công !");
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại !");
            }
        }




        #endregion

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {

            OpenFileDialog imageChoose = new OpenFileDialog();
            if (imageChoose.ShowDialog() == true)
            {

                string sourceAnh = imageChoose.FileName;
                string sourceAnhApp = System.IO.Path.GetFullPath(System.IO.Path.GetFileName(imageChoose.FileName));
                System.IO.File.Copy(sourceAnh, sourceAnhApp, true);
                Uri fileUri = new Uri(sourceAnhApp);
                nvImage.Source = new BitmapImage(fileUri);
            }
        }
    }
}
