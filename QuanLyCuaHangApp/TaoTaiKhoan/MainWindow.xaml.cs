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

namespace TaoTaiKhoan
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
            loadImages();
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
        void loadImages()
        {
            string resourceImage1 = System.IO.Path.GetFullPath("SUPbackground.jpg");
            BitmapImage backImage = new BitmapImage();
            backImage.BeginInit();
            backImage.UriSource = new Uri(resourceImage1);
            backImage.EndInit();
            backGroundImage.Source = backImage;


        }
        bool login(string tk, string mk)
        {
            string loginQuerry = "EXEC Login @TK = N'" + tk + "', @MK = N'" + mk + "'";
            DataTable accountData = SQL_Connect.Instance.ExecuteSQL(loginQuerry);
            return accountData.Rows.Count > 0;
        }

        #endregion

        private void signUpBtn_Click(object sender, RoutedEventArgs e)
        {

            if (kiemTraTenNguoiDung(usernameTxtbox.Text) && kiemTraMatKhau(passwordTxtbox.Text) && kiemTraXavNhanMatKau(passwordTxtbox.Text, comfirmPasswordTxtbox.Text))
            {
                TaiKhoan tk = new TaiKhoan();
                tk.MaNV = int.Parse(nhanvienCombobox.SelectedValue.ToString());
                tk.taiKhoan = usernameTxtbox.Text;
                tk.MatKhau = passwordTxtbox.Text;


                if (TaiKhoan_DAL.themTaiKhoan(tk))
                {
                    MessageBox.Show("Thêm thành công !");
                    this.Close();
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
    }
}
