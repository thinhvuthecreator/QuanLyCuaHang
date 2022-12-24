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
using quanlynhanvienWPF;
using QuanLyHoaDon;
using QuanLySanPham;
using QuanLyKhachHangWPF;

namespace MenuWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            loadtitle("QUẢN LÝ CỬA HÀNG ABC");
        }

        #region methods
        void loadtitle(string title)
        {
            TextBlock titleTextBlock = new TextBlock();
            titleTextBlock.Text = title;
            titleTextBlock.Foreground = Brushes.White;
            titleTextBlock.FontSize = 40;
            titleTextBlock.FontFamily = new FontFamily("Arial Rounded MT Bold");
            WrapPanel titleWrapPanel = new WrapPanel();
            titleWrapPanel.HorizontalAlignment = HorizontalAlignment.Center;
            titleWrapPanel.VerticalAlignment = VerticalAlignment.Center;
            titleWrapPanel.Children.Add(titleTextBlock);
            menuTitleGrid.Children.Add(titleWrapPanel);
        }

        #endregion

        #region events
        #endregion

        private void TextBlock_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            menuTitleGrid.Children.Clear();
            loadtitle("QUẢN LÝ HÀNG HÓA");
            foreach(Window window in Application.Current.Windows)
            {
                if(window.GetType() == typeof(QuanLySanPham.MainWindow))
                {
                    quanLyGrid.Children.Add((window as QuanLySanPham.MainWindow).spViewWrapPanel);
                }
            }
        }

        private void TextBlock_PreviewMouseDown_1(object sender, MouseButtonEventArgs e)
        {
            menuTitleGrid.Children.Clear();
            loadtitle("QUẢN LÝ NHÂN VIÊN");
        }

        private void TextBlock_PreviewMouseDown_2(object sender, MouseButtonEventArgs e)
        {
            menuTitleGrid.Children.Clear();
            loadtitle("QUẢN LÝ KHÁCH HÀNG");
        }

        private void TextBlock_PreviewMouseDown_3(object sender, MouseButtonEventArgs e)
        {
            menuTitleGrid.Children.Clear();
            loadtitle("QUẢN LÝ HÓA ĐƠN");
        }

        private void TextBlock_PreviewMouseDown_4(object sender, MouseButtonEventArgs e)
        {
            menuTitleGrid.Children.Clear();
            loadtitle("THỐNG KÊ");
        }

        private void TextBlock_PreviewMouseDown_5(object sender, MouseButtonEventArgs e)
        {
            menuTitleGrid.Children.Clear();
            loadtitle("THÙNG RÁC");
        }
    }
}
