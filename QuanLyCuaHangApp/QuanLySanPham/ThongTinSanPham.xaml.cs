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
using System.Data;
using System.Data.SqlClient;
using Models;
using Microsoft.Win32;
using System.IO;

namespace QuanLySanPham
{
    /// <summary>
    /// Interaction logic for ThongTinSanPham.xaml
    /// </summary>
    public partial class ThongTinSanPham : Window
    {
        public ThongTinSanPham()
        {
            InitializeComponent();
            loadLoaiSPCombobox();
            loadControls();
        }

        #region methods      
        void loadLoaiSPCombobox()
        {
            List<LoaiSP> lsp = new List<LoaiSP>();
            DataTable LoaiSPSource = LoaiSanPham_DAL.loadDuLieuLOAISP();
            foreach (DataRow data in LoaiSPSource.Rows)
            {
                lsp.Add(new LoaiSP { MaLSP = int.Parse(data[0].ToString()), TenSP = data[1].ToString() });
            }

            loaiSPcombobox.ItemsSource = lsp;
            loaiSPcombobox.DisplayMemberPath = "TenSP";
            loaiSPcombobox.SelectedValuePath = "MaLSP";
        }

        void loadControls()
        {
            maSPTxtbox.IsEnabled = false;
            ngThemspDatePicker.IsEnabled = false;
        }

        #endregion

        #region events
        private void updateSPBtn_Click(object sender, RoutedEventArgs e)
        {
            int soLuong;
            decimal gia, giaBan;
            if (tenSPTxtbox.Text == "")
            {
                MessageBox.Show("Tên sản phẩm bị bỏ trống !");
            }
            else if(int.TryParse(soluongTxtbox.Text,out soLuong) == false)
            {
                MessageBox.Show("Số lượng không hợp lệ !");
            }
            else if (decimal.TryParse(giaTxtbox.Text, out gia) == false)
            {
                MessageBox.Show("Giá không hợp lệ !");
            }
            else if (decimal.TryParse(giaBanTxtbox.Text, out giaBan) == false)
            {
                MessageBox.Show("Giá bán không hợp lệ !");
            }
            else
            {
                SanPham sp = new SanPham();
                sp.MaSP = int.Parse(maSPTxtbox.Text);
                sp.TenSP = tenSPTxtbox.Text;
                sp.MaLoaiSP = int.Parse(loaiSPcombobox.SelectedValue.ToString());
                sp.GiaSP = decimal.Parse(giaTxtbox.Text);
                sp.SoLuongSP = int.Parse(soluongTxtbox.Text);
                sp.NgThemSp = DateTime.Parse(ngThemspDatePicker.Text);
                sp.FileAnh = ProductImage.Source.ToString();
                sp.GiaBanSP = decimal.Parse(giaBanTxtbox.Text);
                if (SanPham_DAL.updateSanPham(sp))
                {
                    MessageBox.Show("Cập nhật sản phẩm thành công !");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Cập nhật sản phẩm thất bại !");
                }
            }
        }
        private void huyBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void updateImageBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog loadImage = new OpenFileDialog();
            if (loadImage.ShowDialog() == true)
            {

                FileInfo file = new FileInfo(loadImage.FileName);

                if (file.Extension == ".jpg" || file.Extension == ".JPG" || file.Extension == ".png" || file.Extension == ".PNG")
                {
                    string sourceAnh = loadImage.FileName;
                    string sourceAnhApp = System.IO.Path.GetFullPath(System.IO.Path.GetFileName(loadImage.FileName));
                    Uri fileUri = new Uri(sourceAnhApp);
                    System.IO.File.Copy(sourceAnh, sourceAnhApp, true);
                    ProductImage.Source = new BitmapImage(fileUri);
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn file ảnh !");
                }
            }

        }
        private void xoaBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SanPham_DAL.xoaSanPham(int.Parse(maSPTxtbox.Text)))
            {
                MessageBox.Show("Xóa thành công !");
                this.Close();

            }
            else
            {
                MessageBox.Show("Xóa thất bại !");
            }

        }




        #endregion

    }
}
