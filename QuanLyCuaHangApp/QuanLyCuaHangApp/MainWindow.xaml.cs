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
        }


        #region objects
        #endregion

        #region methods
        bool login(string tk,string mk)
        {
            string loginQuerry = "EXEC Login @TK = N'" + tk + "', @MK = N'" + mk + "'";
            DataTable accountData = SQL_Connect.Instance.ExecuteSQL(loginQuerry);
            return accountData.Rows.Count > 0;
        }
        #endregion

        #region events
        #endregion

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            if(login(usernameTxtBox.Text,passBox.Password.ToString()))
            {
                MessageBox.Show("Đăng nhập thành công !");
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu !");
            }
        }
    }
}
