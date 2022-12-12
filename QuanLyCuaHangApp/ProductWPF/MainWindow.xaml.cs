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
using System.IO;
using Microsoft.Win32;
using Models;
using System.Data;
using System.Data.SqlClient;
using SQL_Connection;

namespace ProductWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            loadForm();
        }


        #region methods

        string returnMaLoaiSPcuaCombobox()
        {
            string LoaiSPcmb = loaiSPcombobox.SelectedItem.ToString();
            string Querry = "SELECT MALOAISP FROM LOAISP WHERE TENLOAISP =N'" +LoaiSPcmb+ "'"; // Cau lenh lay ra maloaisp
            DataTable data = SQL_Connect.Instance.ExecuteSQL(Querry); // tra ra maloaisp cua selected combobox
            string ketQua = data.Rows[0][0].ToString();
            return ketQua;
        }

        void loadForm()
        {
            DataTable LoaiSPSource = LoaiSanPham_DAL.loadDuLieuLOAISP();
            foreach(DataRow data in LoaiSPSource.Rows) 
            {
                loaiSPcombobox.Items.Add(data[1]);
            }

        }
          

        void ganGiaTriSP(SanPham sp)
        {
            

            decimal giaSP;
            int soLuong;
            
            sp.TenSP = tenSPTxtbox.Text;
            sp.GiaSP = decimal.TryParse(giaTxtbox.Text, out giaSP) == true ? giaSP : -1;
            sp.NgThemSp = DateTime.Parse(ngThemspDatePicker.Text);
            sp.SoLuongSP = int.TryParse(soluongTxtbox.Text, out soLuong) == true ? soLuong : -1;
            sp.MaLoaiSP = int.Parse(returnMaLoaiSPcuaCombobox());

        }

        #endregion

        #region events
        private void addImageBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog loadImage = new OpenFileDialog();
            if (loadImage.ShowDialog() == true)
            {
                Uri fileUri = new Uri(loadImage.FileName);
                ProductImage.Source = new BitmapImage(fileUri);
                string sourceAnh = loadImage.FileName;
                string sourceAnhApp = "..//..//..//Hinh anh//Nhan vien//" + System.IO.Path.GetFileName(loadImage.FileName);
                System.IO.File.Copy(sourceAnh, sourceAnhApp, true);
            }

            

        }
        private void huyBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void themspBtn_Click(object sender, RoutedEventArgs e)
        {
            SanPham sp = new SanPham();
            ganGiaTriSP(sp);
            if(SanPham_DAL.themSanPham(sp))
            {
                MessageBox.Show("Thêm thành công !");
            }
            else
            {
                MessageBox.Show("Thêm thất bại !");
            }
        }

        #endregion


    }
}
