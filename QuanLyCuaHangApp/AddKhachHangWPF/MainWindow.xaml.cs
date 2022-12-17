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
            loadImages();
        }

        #region methods
        void ganDuLieuKH(KhachHang kh)
        {
            #region xuLyChuoi
            string[] chuoi = genderCombobox.SelectedValue.ToString().Split();
            string cmbValue = chuoi[1];
            #endregion
            int sdtKH;
           
  
            kh.TenKH = tenKHTxtbox.Text;
            kh.SdtKH = int.TryParse(sdtKHTxtbox.Text, out sdtKH) == true ? sdtKH : -1;
            kh.NgSinhKH = DateTime.Parse(ngsinhKHDatePicker.Text);
            kh.DoanhSoKH = 0;
            kh.GioiTinhKH = cmbValue;
            kh.FileAnh = loadimageImage.Source.ToString();
        }

        void loadImages()
        {
            string resourceImage1 = System.IO.Path.GetFullPath("imageDefault.jpg");
            BitmapImage logoStaff = new BitmapImage();
            logoStaff.BeginInit();
            logoStaff.UriSource = new Uri(resourceImage1);
            logoStaff.EndInit();
            loadimageImage.Source = logoStaff;



        }

        #endregion

        #region events
        private void addImageBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog loadKHImage = new OpenFileDialog();

            if(loadKHImage.ShowDialog() == true)
            {
                
                
                string sourceAnh = loadKHImage.FileName;
                string sourceAnhApp = System.IO.Path.GetFullPath(System.IO.Path.GetFileName(loadKHImage.FileName));
                System.IO.File.Copy(sourceAnh, sourceAnhApp, true);
                Uri imageUri = new Uri(sourceAnhApp);
                loadimageImage.Source = new BitmapImage(imageUri);
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
