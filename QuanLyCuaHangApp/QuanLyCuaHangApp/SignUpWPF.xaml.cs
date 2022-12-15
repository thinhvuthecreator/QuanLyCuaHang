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
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using Models;
using SQL_Connection;
using System.Net.Mail;
namespace QuanLyCuaHangApp
{
    /// <summary>
    /// Interaction logic for SignUpWPF.xaml
    /// </summary>
    public partial class SignUpWPF : Window
    {
        public SignUpWPF()
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
            foreach (DataRow data in dataNV.Rows)
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
            try
            {
                MailAddress m = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                MessageBox.Show("Email không hợp lệ !");
                return false;
            }
        }
        bool kiemTraTenNguoiDung(string taiKhoan)
        {
            if (taiKhoan.Length <= 20 && Encoding.ASCII.GetByteCount(taiKhoan) == Encoding.UTF8.GetByteCount(taiKhoan))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Tên người dùng không hợp lệ !");
                return false;
            }
        }
        bool kiemTraMatKhau(string matKhau)
        {
            if (matKhau.Length <= 30 && Encoding.ASCII.GetByteCount(matKhau) == Encoding.UTF8.GetByteCount(matKhau))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Mật khẩu không hợp lệ !");
                return false;
            }
        }
        bool kiemTraXavNhanMatKau(string matKhau, string matkhauXacNhan)
        {
            bool isEqual = true;
            if (matKhau.Length != matkhauXacNhan.Length)
            {
                MessageBox.Show("Mật khẩu không trùng khớp !");
                return false;
            }
            else
            {
                for (int i = 0; i < matKhau.Length; i++)
                {
                    if (matKhau[i] != matkhauXacNhan[i])
                    {
                        isEqual = false;
                    }
                }

                if (isEqual == false)
                {
                    MessageBox.Show("Mật khẩu không trùng khớp !");
                }
                return isEqual;
            }

        }

        #endregion

        #region events
        private void signUpBtn_Click(object sender, RoutedEventArgs e)
        {
            if (kiemTraEmail(emailTxtbox.Text) && kiemTraTenNguoiDung(usernameTxtbox.Text) && kiemTraMatKhau(passwordTxtbox.Text) && kiemTraXavNhanMatKau(passwordTxtbox.Text, comfirmPasswordTxtbox.Text))
            {
                TaiKhoan tk = new TaiKhoan();
                tk.MaNV = int.Parse(nhanvienCombobox.SelectedValue.ToString());
                tk.taiKhoan = usernameTxtbox.Text;
                tk.MatKhau = passwordTxtbox.Text;
                tk.EMail = emailTxtbox.Text;

                if (TaiKhoan_DAL.themTaiKhoan(tk))
                {
                    MessageBox.Show("Thêm thành công !");
                }
                else
                {
                    MessageBox.Show("Thêm thất bại !");
                }
            }
            else
            {
                MessageBox.Show("Lỗi !");
            }
        }

        private void signInBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow loginWindow = new MainWindow();
            this.Hide();
            loginWindow.Show();
        }
        #endregion
    }
}
