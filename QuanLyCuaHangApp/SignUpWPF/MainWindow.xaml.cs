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

namespace SignUpWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            loadNhanVienCombobox();
        }

        #region objects
        public class NhanVien
        {
            public int maNV { get; set; }
            public string tenNV { get; set; }
            NhanVien()
            {

            }
            public NhanVien(int ma, string ten)
            {
                maNV = ma;
                tenNV = ten;
            }
        }
        #endregion

        #region methods
        void loadNhanVienCombobox()
        {
            List<NhanVien> nvList = new List<NhanVien>();
            string loadNV = "SELECT MANV,TENNV FROM NHANVIEN";
            DataTable dataNV = SQL_Connect.Instance.ExecuteSQL(loadNV);
            foreach(DataRow data in dataNV.Rows)
            {
                NhanVien nv = new NhanVien(int.Parse(data[0].ToString()), data[1].ToString());
                nvList.Add(nv);
            }
            nhanvienCombobox.ItemsSource = nvList;
            nhanvienCombobox.DisplayMemberPath = "tenNV";
            nhanvienCombobox.SelectedValuePath = "maNV";
        }

        bool kiemTraEmail(string email)
        {
            return false;
        }
        bool kiemTraTenNguoiDung(string taiKhoan)
        {
            return false;
        }
        bool kiemTraMatKhau(string matKau)
        {
            return false;
        }
        bool kiemTraXavNhanMatKau(string matKhau,string matkhauXacNhan)
        {
            return false;
        }

        #endregion

        #region events
        private void signUpBtn_Click(object sender, RoutedEventArgs e)
        {
            if(kiemTraEmail(emailTxtbox.Text) && kiemTraTenNguoiDung(usernameTxtbox.Text) && kiemTraMatKhau(passwordTxtbox.Text) &&  kiemTraXavNhanMatKau(passwordTxtbox.Text,comfirmPasswordTxtbox.Text))
            {
               // thêm tài khoản vào database
            }
        }

        #endregion

    }
}
