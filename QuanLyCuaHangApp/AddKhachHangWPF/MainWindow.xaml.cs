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
namespace AddKhachHangWPF
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
        void ganDuLieuKH(KhachHang kh)
        {
            #region xuLyChuoi
            string[] chuoi = genderCombobox.SelectedValue.ToString().Split();
            string cmbValue = chuoi[1];
            #endregion
            int sdtKH, doanhSoKH;
  
            kh.TenKH = tenKHTxtbox.Text;
            kh.SdtKH = int.TryParse(sdtKHTxtbox.Text, out sdtKH) == true ? sdtKH : -1;
            kh.NgSinhKH = DateTime.Parse(ngsinhKHDatePicker.Text);
            kh.DoanhSoKH = int.TryParse(doanhSoKHTxtbox.Text, out doanhSoKH) == true ? doanhSoKH : -1;
            kh.GioiTinhKH = cmbValue;
        }
       


        #endregion

        #region events
        private void addImageBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog loadKHImage = new OpenFileDialog();

            if(loadKHImage.ShowDialog() == true)
            {
                Uri imageUri = new Uri(loadKHImage.FileName);
                loadimageImage.Source = new BitmapImage(imageUri);
                string sourceAnh = loadKHImage.FileName;
                string sourceAnhApp = "..//..//..//Hinh anh//Khach hang//" + System.IO.Path.GetFileName(loadKHImage.FileName);
                System.IO.File.Copy(sourceAnh, sourceAnhApp, true);
            }
           
        }
        private void huyBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void themNVBtn_Click(object sender, RoutedEventArgs e)
        {
            KhachHang kh = new KhachHang();
            ganDuLieuKH(kh);
            if(KhachHang_DAL.themKhachHang(kh))
            {
                MessageBox.Show("Thêm thành công !");
                this.Close();
            }
            else
            {
                MessageBox.Show("thêm thất bại !");
            }


        }

        #endregion

    }
}
