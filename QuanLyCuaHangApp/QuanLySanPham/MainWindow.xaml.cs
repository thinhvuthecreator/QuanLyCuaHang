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
using Microsoft.Win32;
using Models;
using SQL_Connection;
using System.Data;
using System.Data.SqlClient;
using ProductWPF;

namespace QuanLySanPham
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            loadTimKiemCmb();
        }




        #region methods
        void loadTimKiemCmb()
        {
            List<string> danhMuc = new List<string> { "ID", "Tên", "Giá", "Loại" };
            timKiemCmb.ItemsSource = danhMuc;
            timKiemCmb.SelectedIndex = 0;
        }
        string xuLyChuoi(string s)
        {
            if (s == "")
            {
                string fileAnhmacDinh = System.IO.Path.GetFullPath("shopping.png");

                s = fileAnhmacDinh;
            }
            else
            {
                s = s.Remove(0, 8);
            }
            return s;
        }
        public void loadSanPhamView()
        {
            DataTable dataSP = SanPham_DAL.loadDuLieuSP();
            foreach(DataRow row in dataSP.Rows)
            {
                
                StackPanel SPstckPanel = new StackPanel();
                SPstckPanel.Width = 130;
                SPstckPanel.Height = 130;

                #region tao_doi_tuong_san_pham
                SanPhamObject spObject = new SanPhamObject();
                string filePath = System.IO.Path.GetFullPath("shopping.png");
                Uri imageUri = new Uri(filePath);
                try
                {
                    imageUri = new Uri(xuLyChuoi(row[6].ToString()));
                }
                catch
                {
                    imageUri = new Uri(filePath);
                }

                spObject.Source = new BitmapImage(imageUri);
                spObject.Width = 100;
                spObject.Height = 100;
                spObject.HorizontalAlignment = HorizontalAlignment.Center;
                spObject.MaSP = int.Parse(row[0].ToString());
                spObject.TenSP = row[1].ToString();
                spObject.GiaSP = decimal.Parse(row[2].ToString());
                spObject.MaLoaiSP = int.Parse(row[3].ToString());
                spObject.SoLuongSP = int.Parse(row[4].ToString());
                spObject.NgThemSP = DateTime.Parse(row[5].ToString());
                spObject.MouseDown += ImgeSP_MouseDown;
                #endregion

                #region tao_ten_san_pham_de_hien_thi
                TextBlock SPtxtblock = new TextBlock();
                SPtxtblock.Text = row[1].ToString();
                SPtxtblock.Foreground = Brushes.White;
                SPtxtblock.HorizontalAlignment = HorizontalAlignment.Center;
                #endregion

                SPstckPanel.Children.Add(spObject);
                SPstckPanel.Children.Add(SPtxtblock);
               
            
                spViewWrapPanel.Children.Add(SPstckPanel);

            }

        }
        string layTenLoaiSP(int maLoaiSP)
        {
            string tenLSP = "";
            string laytenLoaiSPQuerry = "SELECT TENLOAISP FROM LOAISP WHERE MALOAISP =" + maLoaiSP;
            DataTable data = SQL_Connect.Instance.ExecuteSQL(laytenLoaiSPQuerry);
            foreach(DataRow row in data.Rows)
            {
                tenLSP = row[0].ToString(); 
            }
            return tenLSP;
        }

        #endregion






        #region events
        private void ImgeSP_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SanPhamObject spObject = sender as SanPhamObject;
            ThongTinSanPham thongtinSP = new ThongTinSanPham();
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(ThongTinSanPham))
                {

                    (window as ThongTinSanPham).ProductImage.Source = spObject.Source;
                    (window as ThongTinSanPham).tenSPTxtbox.Text = spObject.TenSP;
                    (window as ThongTinSanPham).giaTxtbox.Text = spObject.GiaSP.ToString();
                    (window as ThongTinSanPham).soluongTxtbox.Text = spObject.SoLuongSP.ToString();
                    (window as ThongTinSanPham).loaiSPcombobox.Text = layTenLoaiSP(spObject.MaLoaiSP);
                    (window as ThongTinSanPham).ngThemspDatePicker.Text = spObject.NgThemSP.ToString();
                    (window as ThongTinSanPham).maSPTxtbox.Text = spObject.MaSP.ToString();
                }
            }
            thongtinSP.Show();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            spViewWrapPanel.Children.Clear();
            loadSanPhamView();
    
        }

        private void addSPButton_Click(object sender, RoutedEventArgs e)
        {
            ProductWPF.MainWindow themSPWindow = new ProductWPF.MainWindow();
            themSPWindow.Show();
        }
        private void lspSPButton_Click(object sender, RoutedEventArgs e)
        {
            AddLoaiSPWPF.MainWindow themLSPWindow = new AddLoaiSPWPF.MainWindow();
            themLSPWindow.Show();
        }
        private void timKiemTxtbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string Querry = "";
            if (timKiemCmb.SelectedIndex == 0)
            {
                Querry = "SELECT * FROM SANPHAM WHERE MASP LIKE '%" + timKiemTxtbox.Text + "%'";
            }
            else if (timKiemCmb.SelectedIndex == 1)
            {
                Querry = "SELECT * FROM SANPHAM WHERE TENSP LIKE N'%" + timKiemTxtbox.Text + "%'";
            }
            else if (timKiemCmb.SelectedIndex == 2)
            {
                Querry = "SELECT * FROM SANPHAM WHERE GIA LIKE '%" + timKiemTxtbox.Text + "%'";
            }
            else if (timKiemCmb.SelectedIndex == 3)
            {
                Querry = "SELECT * FROM SANPHAM,LOAISP WHERE SANPHAM.MALOAISP = LOAISP.MALOAISP AND LOAISP.TENLOAISP LIKE N'%" + timKiemTxtbox.Text + "%'";
            }
            spViewWrapPanel.Children.Clear();
            DataTable dataSP = SQL_Connect.Instance.ExecuteSQL(Querry);
            foreach (DataRow row in dataSP.Rows)
            {

                StackPanel SPstckPanel = new StackPanel();
                SPstckPanel.Width = 130;
                SPstckPanel.Height = 130;

                #region tao_doi_tuong_san_pham
                SanPhamObject spObject = new SanPhamObject();
                string filePath = System.IO.Path.GetFullPath("shopping.png");
                Uri imageUri = new Uri(filePath);
                try
                {
                    imageUri = new Uri(xuLyChuoi(row[6].ToString()));
                }
                catch
                {
                    imageUri = new Uri(filePath);
                }

                spObject.Source = new BitmapImage(imageUri);
                spObject.Width = 100;
                spObject.Height = 100;
                spObject.HorizontalAlignment = HorizontalAlignment.Center;
                spObject.MaSP = int.Parse(row[0].ToString());
                spObject.TenSP = row[1].ToString();
                spObject.GiaSP = decimal.Parse(row[2].ToString());
                spObject.MaLoaiSP = int.Parse(row[3].ToString());
                spObject.SoLuongSP = int.Parse(row[4].ToString());
                spObject.NgThemSP = DateTime.Parse(row[5].ToString());
                spObject.MouseDown += ImgeSP_MouseDown;
                #endregion

                #region tao_ten_san_pham_de_hien_thi
                TextBlock SPtxtblock = new TextBlock();
                SPtxtblock.Text = row[1].ToString();
                SPtxtblock.Foreground = Brushes.White;
                SPtxtblock.HorizontalAlignment = HorizontalAlignment.Center;
                #endregion

                SPstckPanel.Children.Add(spObject);
                SPstckPanel.Children.Add(SPtxtblock);


                spViewWrapPanel.Children.Add(SPstckPanel);

            }



        }
    }
        #endregion
}

