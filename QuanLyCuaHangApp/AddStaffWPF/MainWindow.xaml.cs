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
using System.Security;
using Microsoft.Win32;

namespace AddStaffWPF
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

        #region methods

        void ganGiaTriNhanVien(NhanVien nv)
        {
            int sdt, luong;
            nv.MaNV = maNVTxtbox.Text;
            nv.TenNV = tenNVTxtbox.Text;
            nv.GioiTinh = genderCombobox.SelectedValue.ToString();
            nv.SdtNV = int.TryParse(sdtNVTxtbox.Text,out sdt) == true ? sdt : 0;
            nv.NgSinhNV = DateTime.Parse(ngsinhNVDatePicker.Text);
            nv.LuongNV = int.TryParse(luongTxtbox.Text, out luong) == true ? luong : 0;

        }

        #endregion


        #region events

        private void addImageBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog loadImage = new OpenFileDialog();
            if(loadImage.ShowDialog() == true)
            {
                Uri fileUri = new Uri(loadImage.FileName);
                loadimageImage.Source = new BitmapImage(fileUri);

            }
        }

        private void huyBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void themNVBtn_Click(object sender, RoutedEventArgs e)
        {
            NhanVien nv = new NhanVien();
            ganGiaTriNhanVien(nv);   //tao mot nv se mang gia tri add vao
            // add du lieu xuong database thông qua lớp sql_connection trong viewsmodel

           
        }
        #endregion


    }
}
