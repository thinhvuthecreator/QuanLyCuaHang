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
        }


        #region methods

        void ganGiaTriSP(SanPham sp)
        {
            int maSP;
            decimal giaSP;
            int soLuong;
            sp.MaSP = int.TryParse(maSPTxtbox.Text,out maSP) == true ? maSP : -1;
            sp.TenSP = tenSPTxtbox.Text;
            sp.GiaSP = decimal.TryParse(giaTxtbox.Text, out giaSP) == true ? giaSP : -1;
            sp.NgThemSp = DateTime.Parse(ngThemspDatePicker.Text);
            sp.SoLuongSP = int.TryParse(soluongTxtbox.Text, out soLuong) == true ? soLuong : -1;

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

            }

        }

        #endregion

        private void huyBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void themspBtn_Click(object sender, RoutedEventArgs e)
        {
            SanPham sp = new SanPham();
            ganGiaTriSP(sp);
        }
    }
}
