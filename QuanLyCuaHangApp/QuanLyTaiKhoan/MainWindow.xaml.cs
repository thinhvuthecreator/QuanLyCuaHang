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
namespace QuanLyTaiKhoan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            loadTKListView();
         
        }
        #region objects
        public class TaiKhoan
        {
            public int maTK { get; set; }
            public int maNV { get; set; }
            public string tenNV { get; set; }
            public string taiKhoan { get; set; }
            public string matKhau { get; set; }

        }
        #endregion
        #region methods
        void loadTKListView()
        {
            taikhoanListView.ItemsSource = null;
            List<TaiKhoan> tkList = new List<TaiKhoan>();
            DataTable data = SQL_Connect.Instance.ExecuteSQL("select MATK,ACC.MANV,TENNV,TAIKHOAN,MATKHAU FROM ACCOUNT ACC,NHANVIEN NV WHERE ACC.MANV = NV.MANV");
            foreach(DataRow row in data.Rows)
            {
                tkList.Add(new TaiKhoan { maTK = int.Parse(row[0].ToString()),maNV = int.Parse(row[1].ToString()),tenNV = row[2].ToString(),taiKhoan = row[3].ToString(),matKhau = row[4].ToString()});
            }
            taikhoanListView.ItemsSource = tkList;
        }
        #endregion

        #region events
        private void Window_Activated(object sender, EventArgs e)
        {
            loadTKListView();
            taikhoanListView.SelectedIndex = 0;
        }
        private void addTkButton_Click(object sender, RoutedEventArgs e)
        {
            TaoTaiKhoan.MainWindow window = new TaoTaiKhoan.MainWindow();
            window.Show();
        }
        private void delTkButton_Click(object sender, RoutedEventArgs e)
        {
            TaiKhoan tk = (TaiKhoan)taikhoanListView.SelectedItem;
            MessageBoxResult choice = MessageBox.Show("Xóa tài khoản của "+tk.tenNV+" ?", "", MessageBoxButton.YesNo);
            if(choice == MessageBoxResult.Yes)
            {
                if (maTKTextBlock.Text == "14")
                {
                    MessageBox.Show("Không được xóa tài khoản này !");
                 }
                else
                {
                    if (TaiKhoan_DAL.xoaTaiKhoan(int.Parse(maTKTextBlock.Text)))
                    {
                        MessageBox.Show("Xóa thành công");
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại !");
                    }
                }
            }
            else
            {

            } 
        }
        private void taikhoanListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TaiKhoan tk = (TaiKhoan)taikhoanListView.SelectedItem; // lỗi 
            if (tk != null)
            {
                maTKTextBlock.Text = tk.maTK.ToString();
            }
            else
            {
                maTKTextBlock.Text = "-1";
            }
            
        }
        private void thongtinTkButton_Click(object sender, RoutedEventArgs e)
        {
            ThongTinAccount window = new ThongTinAccount();
            window.Show();
        }

        #endregion

    }
}
