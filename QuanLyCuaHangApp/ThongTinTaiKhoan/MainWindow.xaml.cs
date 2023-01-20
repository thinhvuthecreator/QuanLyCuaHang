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
using Models;
using System.Data;
using System.Data.SqlClient;

namespace ThongTinTaiKhoan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            loadThongTinTaiKhoan();
            en_dis(false);
        }
        #region methods
        void loadThongTinTaiKhoan()
        {
            taiKhoanTextbox.Text = Account.TaiKhoan;
            matKhauTextbox.Text = Account.MatKhau;
        }
        void en_dis(bool e)
        {
            matKhauTextbox.IsEnabled = e;
            saveButton.IsEnabled = e;
        }
        #endregion
        #region events
        private void changePassButton_Click(object sender, RoutedEventArgs e)
        {
            en_dis(true);
        }
        private void huyButton_Click(object sender, RoutedEventArgs e)
        {
            matKhauTextbox.Text = Account.MatKhau;
            en_dis(false);
        }
        #endregion

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            
            DataTable data = SQL_Connect.Instance.ExecuteSQL("SELECT MATK FROM ACCOUNT WHERE TAIKHOAN =N'" + taiKhoanTextbox.Text + "'");
            
            string maTK = data.Rows[0][0].ToString();
            if (TaiKhoan_DAL.updateTaiKhoan(maTK,matKhauTextbox.Text))
            {
                MessageBox.Show("Cập nhật thành công !");
                Account.MatKhau = matKhauTextbox.Text;
                en_dis(false);
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại !");
            }
        }
    }
}
