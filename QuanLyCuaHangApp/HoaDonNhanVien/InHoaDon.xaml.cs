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
using SQL_Connection;
using Models;
using System.Data;
using System.Data.SqlClient;

namespace HoaDonNhanVien
{
    /// <summary>
    /// Interaction logic for InHoaDon.xaml
    /// </summary>
    public partial class InHoaDon : Window
    {
        public InHoaDon()
        {
            InitializeComponent();
            loadListSP(HoaDonTemp.SoHD);
        }
       
        
        #region object
        class HoaDon
        {
            public int soHD { get; set; }
            public string tenSP { get; set; }
            public int soLuong { get; set; }
            public string gia { get; set; }
        }

        #endregion
        
        
        #region methods
        void loadListSP(int soHD)
        {
            List<HoaDon> listHD = new List<HoaDon>();
            DataTable data = SQL_Connect.Instance.ExecuteSQL("EXEC HOADON_CTHD_View @maHD =" + soHD);
            foreach(DataRow row in data.Rows)
            {
                listHD.Add(new HoaDon {soHD = int.Parse(row[0].ToString()),tenSP = row[1].ToString(),gia = row[3].ToString() + " VND",soLuong = int.Parse(row[2].ToString())});
            }
            dsSpListView.ItemsSource = listHD;
        }
        #endregion

        #region events
        private void hoaDonWindow_Activated(object sender, EventArgs e)
        {

            if (dsSpListView.Items.Count > 7)
            {
                hoaDonWindow.Height += (50 * (dsSpListView.Items.Count - 7));
            }
            
        }

        private void PrintBorder_MouseEnter(object sender, MouseEventArgs e)
        {
            PrintBorder.Background = Brushes.Gray;
        }

        private void PrintBorder_MouseLeave(object sender, MouseEventArgs e)
        {
            PrintBorder.Background = Brushes.Transparent;
        }
        #endregion

        private void PrintBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            PrintDialog print = new PrintDialog();
            if(print.ShowDialog() == true)
            {
                print.PrintVisual(HD_Receipt,"Hóa Đơn ABC Store");
                MessageBox.Show("Đã xuất file PDF để in !");
                
            }
        }
    }
}
