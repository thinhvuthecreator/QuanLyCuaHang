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

namespace AddLoaiSPWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataTable duLieuLoaiSP = LoaiSanPham_DAL.loadDuLieuLOAISP();
            foreach (DataRow data in duLieuLoaiSP.Rows)
            {
               loaiSPListView.Items.Add(data[1]);
            }
        }

        private void themLoaiSPBtn_Click(object sender, RoutedEventArgs e)
        {
            Them themLoaiWindow = new Them();
            themLoaiWindow.Show();
        }

        private void xoaLoaiSPBtn_Click(object sender, RoutedEventArgs e)
        {
            if(LoaiSanPham_DAL.xoaLoaiSP(loaiSPListView.SelectedItem.ToString()))
            {
                MessageBox.Show("xóa thành công !");
                loaiSPListView.Items.Clear();
                DataTable duLieuLoaiSP = LoaiSanPham_DAL.loadDuLieuLOAISP();
                foreach (DataRow data in duLieuLoaiSP.Rows)
                {

                   loaiSPListView.Items.Add(data[1]);
                }
            }
            else
            {
                MessageBox.Show("xóa thất bại !");
            }

        }
    }
}
