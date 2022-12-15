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

        #endregion

        #region events
        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            AddStaffWPF.MainWindow themNVWindow = new AddStaffWPF.MainWindow();
            themNVWindow.Show();
            
        }


        #endregion

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            loadDuLieuNVListView();
        }

        private void Grid_IsMouseCapturedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            loadDuLieuNVListView();
        }

       
    }
}
