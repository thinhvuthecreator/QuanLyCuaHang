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
namespace addHoaDonWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            loadNVcmb();
            loadKHcmb();
            loadSPcmb();

        }

        void loadNVcmb()
        {
            string laytenNVQuerry = "SELECT TENNV FROM NHANVIEN";
            DataTable dataNhanvien = SQL_Connect.Instance.ExecuteSQL(laytenNVQuerry);

            foreach (DataRow data in dataNhanvien.Rows)
            {
                nhanVienCombobox.Items.Add(data[0]);
            }
        }

        void  loadKHcmb()
        {
            string laytenKHQuerry = "SELECT TENKH FROM KHACHHANG";
            DataTable dataKH = SQL_Connect.Instance.ExecuteSQL(laytenKHQuerry);

            foreach (DataRow data in dataKH.Rows)
            {
                khachhangCombobox.Items.Add(data[0]);
            }
        }

        void loadSPcmb()
        {
            string laytenSPQuerry = "SELECT TENSP FROM SANPHAM";
            DataTable dataSP = SQL_Connect.Instance.ExecuteSQL(laytenSPQuerry);

            foreach (DataRow data in dataSP.Rows)
            {
                sanPhamCombobox.Items.Add(data[0]);
            }
        }

        public class danhSachSanPham
        {
            public string tenSP;
            public int soLuong;
            public int gia;
            
        }
    }
}
