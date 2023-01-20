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
using SQL_Connection;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace QuanLyCuaHangApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            loadImages();
        }


        #region objects
        #endregion

        #region methods
        void loadImages()
        {
            string resourceImage1 = System.IO.Path.GetFullPath("aaa.png");
            BitmapImage logoLogin = new BitmapImage();
            logoLogin.BeginInit();
            logoLogin.UriSource = new Uri(resourceImage1);
            logoLogin.EndInit();
            mainImage.Source = logoLogin;

            string resourceImage2 = System.IO.Path.GetFullPath("user.png");
            BitmapImage logoUser = new BitmapImage();
            logoUser.BeginInit();
            logoUser.UriSource = new Uri(resourceImage2);
            logoUser.EndInit();
            userImage.Source = logoUser;

            string resourceImage3 = System.IO.Path.GetFullPath("pass.png");
            BitmapImage logoPass = new BitmapImage();
            logoPass.BeginInit();
            logoPass.UriSource = new Uri(resourceImage3);
            logoPass.EndInit();
            passImage.Source = logoPass;

            string resourceImage4 = System.IO.Path.GetFullPath("productLogin1.jpg");
            BitmapImage logoBackground = new BitmapImage();
            logoBackground.BeginInit();
            logoBackground.UriSource = new Uri(resourceImage4);
            logoBackground.EndInit();
            backgroundImage.Source = logoBackground;

        }
        bool login(string tk,string mk)
        {
            string loginQuerry = "EXEC Login @TK = N'" + tk + "', @MK = N'" + mk + "'";
            DataTable accountData = SQL_Connect.Instance.ExecuteSQL(loginQuerry);
            return accountData.Rows.Count > 0;
        }
        #endregion

        #region events
        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            if(login(usernameTxtBox.Text,passBox.Password.ToString()))
            {
                if(usernameTxtBox.Text == "admin")
                {
                    MenuWPF.MainWindow window = new MenuWPF.MainWindow();
                    QuanLyTaiKhoan.Account.TaiKhoan = usernameTxtBox.Text;
                    QuanLyTaiKhoan.Account.MatKhau = passBox.Password.ToString();
                    window.Show();
                   
                }
                else
                {
                    MenuNhanVienWPF.MainWindow window = new MenuNhanVienWPF.MainWindow();
                    ThongTinTaiKhoan.Account.TaiKhoan = usernameTxtBox.Text;
                    ThongTinTaiKhoan.Account.MatKhau = passBox.Password.ToString();
                    window.Show();
                }
                
                
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu !");
            }
        }
        #endregion


    
    }
}
