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
            int maKH, sdtKH, doanhSoKH;
            kh.MaKH = int.TryParse(maKHTxtbox.Text, out maKH) == true ? maKH : -1;
            kh.TenKH = tenKHTxtbox.Text;
            kh.SdtKH = int.TryParse(sdtKHTxtbox.Text, out sdtKH) == true ? sdtKH : -1;
            kh.NgSinhKH = DateTime.Parse(ngsinhKHDatePicker.Text);
            kh.DoanhSoKH = int.TryParse(doanhSoKHTxtbox.Text, out doanhSoKH) == true ? doanhSoKH : -1;
            kh.GioiTinhKH = genderCombobox.SelectedValue.ToString();
        }
        bool themVaoDatabase(KhachHang kh)
        {

            return false;
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
            themVaoDatabase(kh);
        }

        #endregion

    }
}
