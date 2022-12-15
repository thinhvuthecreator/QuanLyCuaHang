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
                listNV.Add(new NhanVien() { MaNV = int.Parse(nhanvienData[0].ToString()), TenNV = nhanvienData[1].ToString(),SdtNV = int.Parse(nhanvienData[2].ToString()),LuongNV = decimal.Parse(nhanvienData[3].ToString()),GioiTinh = nhanvienData[4].ToString(),NgSinhNV = DateTime.Parse(nhanvienData[5].ToString()) });
            }
            nhanVienListView.ItemsSource = listNV;
        }
        void loadGioiTinhCombobox()
        {
            List<string> gioiTinh = new List<string> { "Nam","Nữ"};
            gioiTinhNVCombobox.ItemsSource = gioiTinh;
           
           
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





        #endregion

        private void nhanVienListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                NhanVien nv = (NhanVien)nhanVienListView.SelectedItem;
                if (nv == null)
                {

                }
                else
                {
                    maNVTxtbox.Text = nv.MaNV.ToString();
                    tenNVTxtbox.Text = nv.TenNV;
                    sdtNVTxtbox.Text = nv.SdtNV.ToString();
                    luongNVTxtbox.Text = nv.LuongNV.ToString();
                    gioiTinhNVCombobox.Text = nv.GioiTinh;
                    ngSinhNVDatePicker.Text = nv.NgSinhNV.ToString();
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

        }
    }
}
