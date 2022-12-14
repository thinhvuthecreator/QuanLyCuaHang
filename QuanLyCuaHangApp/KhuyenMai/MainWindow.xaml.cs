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

namespace KhuyenMai
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        List<Khuyenmai> kmList = new List<Khuyenmai>();
        public MainWindow()
        {
            InitializeComponent();
            loadDuLieuKhuyenMai();
        }

        #region methods
        void loadDuLieuKhuyenMai()
        {
            kmListView.ItemsSource = null;
            kmList.Clear();
            DataTable dataKM = KhuyenMai_DAL.loadDuLieuKM();
            foreach (DataRow row in dataKM.Rows)
            {
                kmList.Add(new Khuyenmai {MaKM = int.Parse(row[0].ToString()),GiaTriDK = decimal.Parse(row[2].ToString()), GiaTriKM = int.Parse(row[1].ToString()) });
            }
            kmListView.ItemsSource = kmList;

            if(kmList.Count == 0)
            {
                giaTriDKTextbox.Text = giaTriKMTextbox.Text = "";
            }
            else
            {
                kmListView.SelectedIndex = 0;
            }
        }
        void ganGiaTriKhuyenMai(Khuyenmai km)
        {
            decimal giaTriDK;
            int giaTriKM;

            km.GiaTriDK = decimal.TryParse(giaTriDKTextbox.Text,out giaTriDK) == true ? giaTriDK : -1;
            km.GiaTriKM = int.TryParse(giaTriKMTextbox.Text, out giaTriKM) == true ? giaTriKM : -1;
        }


        #endregion

        #region events
        private void kmListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (kmListView.ItemsSource == null)
            {

            }
            else
            {
                Khuyenmai km = (Khuyenmai)kmListView.SelectedItem;
                giaTriDKTextbox.Text = km.GiaTriDK.ToString();
                giaTriKMTextbox.Text = km.GiaTriKM.ToString();
            }
        }
        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
           
            Khuyenmai km = new Khuyenmai();
            ganGiaTriKhuyenMai(km);
            if(KhuyenMai_DAL.themKhuyenMai(km))
            { 
                MessageBox.Show("Thêm khuyến mãi thành công !");
                loadDuLieuKhuyenMai();
            }
            else
            {
                MessageBox.Show("Thêm thất bại !");
            }
        }
      
        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if(kmListView.SelectedItem != null)
            {
                Khuyenmai km = (Khuyenmai)kmListView.SelectedItem;
               if(KhuyenMai_DAL.xoaKhuyenMai(km.MaKM))
                {
                    MessageBox.Show("Xóa thành công !");
                    loadDuLieuKhuyenMai();
                }
               else
                {
                    MessageBox.Show("Xóa thất bại ! Khuyến mại này vẫn còn tồn tại trong hóa đơn");
                }
            }
           
        }


        #endregion

    }
}
