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
using System.Data;
using System.Data.SqlClient;
using SQL_Connection;

namespace AddLoaiSPWPF
{
    /// <summary>
    /// Interaction logic for Them.xaml
    /// </summary>
    public partial class Them : Window
    {
        public Them()
        {
            InitializeComponent();

           
        }

      

        private void huy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void xong_Click(object sender, RoutedEventArgs e)
        {

            string ketQua = addTextbox.Text;
            if (ketQua != "")
            {
                if (LoaiSanPham_DAL.themLoaiSP(ketQua))
                {
                    foreach (Window window in Application.Current.Windows)
                    {
                        if (window.GetType() == typeof(AddLoaiSPWPF.MainWindow))
                        {
                            (window as AddLoaiSPWPF.MainWindow).loaiSPListView.Items.Clear();

                            DataTable duLieuLoaiSP = LoaiSanPham_DAL.loadDuLieuLOAISP();
                            foreach (DataRow data in duLieuLoaiSP.Rows)
                            {

                                (window as AddLoaiSPWPF.MainWindow).loaiSPListView.Items.Add(data[1]);
                            }
                        }
                    }

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
                MessageBox.Show("Không được để trống !");
            }

                

                
            
           
            
        }
    }
}
