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
using KhuyenMai;
using ThongKe;

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
            loadImages();
            
        }

        #region methods
        void loadImages()
        {
            string resourceImage1 = System.IO.Path.GetFullPath("aaa.png");
            BitmapImage logoLogin = new BitmapImage();
            logoLogin.BeginInit();
            logoLogin.UriSource = new Uri(resourceImage1);
            logoLogin.EndInit();
            storeImage.Source = logoLogin;
            
        }
        void mouseEnter(object sender)
        {
            Border thisBorder = sender as Border;
            thisBorder.Background = tempGrid2.Background;
            object controls = thisBorder.Child;
            if (controls.GetType() == typeof(Grid))
            {
                foreach (object ct in (controls as Grid).Children)
                    if (ct.GetType() == typeof(TextBlock))
                    {
                        (ct as TextBlock).Foreground = Brushes.Black;
                    }
            }
        }
        void mouseClick(object sender)
        {
            Border thisBorder = sender as Border;
            thisBorder.Background = Brushes.White;
            object controls = thisBorder.Child;
            if (controls.GetType() == typeof(Grid))
            {
                foreach (object ct in (controls as Grid).Children)
                    if (ct.GetType() == typeof(TextBlock))
                    {
                        (ct as TextBlock).Foreground = Brushes.Black;
                    }
            }

        }
        void mouseLeave(object sender)
        {
            Border thisBorder = sender as Border;
            thisBorder.Background = tempGrid.Background;
            object controls = thisBorder.Child;
            if (controls.GetType() == typeof(Grid))
            {
                foreach (object ct in (controls as Grid).Children)
                    if (ct.GetType() == typeof(TextBlock))
                    {
                        (ct as TextBlock).Foreground = Brushes.DarkGray;
                    }
            }
        }

        #endregion






        #region events

        #region mouseEnter_events
        private void nvBorder_MouseEnter(object sender, MouseEventArgs e)
        {
            mouseEnter(sender);
        }

        private void khBorder_MouseEnter(object sender, MouseEventArgs e)
        {
            mouseEnter(sender);
        }

        private void hhBorder_MouseEnter(object sender, MouseEventArgs e)
        {
            mouseEnter(sender);
        }

        private void hdBorder_MouseEnter(object sender, MouseEventArgs e)
        {
            mouseEnter(sender);
        }

        private void kmBorder_MouseEnter(object sender, MouseEventArgs e)
        {
            mouseEnter(sender);
        }

        private void tkBorder_MouseEnter(object sender, MouseEventArgs e)
        {
            mouseEnter(sender);
        }
      
        private void accountBorder_MouseEnter(object sender, MouseEventArgs e)
        {
            mouseEnter(sender);
        }
       
       
        #endregion

        #region mouseleave_mouseEnter_events
        private void nvBorder_MouseLeave(object sender, MouseEventArgs e)
        {
            mouseLeave(sender);
        }

        private void khBorder_MouseLeave(object sender, MouseEventArgs e)
        {
            mouseLeave(sender);
        }

        private void hhBorder_MouseLeave(object sender, MouseEventArgs e)
        {
            mouseLeave(sender);
        }

        private void hdBorder_MouseLeave(object sender, MouseEventArgs e)
        {
            mouseLeave(sender);
        }

        private void kmBorder_MouseLeave(object sender, MouseEventArgs e)
        {
            mouseLeave(sender);
        }

        private void tkBorder_MouseLeave(object sender, MouseEventArgs e)
        {
            mouseLeave(sender);
        }
        private void accountBorder_MouseLeave(object sender, MouseEventArgs e)
        {
            mouseLeave(sender);
        }

        #endregion




        #region mouseDown_events
        private void nvBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mouseClick(sender);
        }

        private void khBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mouseClick(sender);
        }

        private void hhBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mouseClick(sender);
        }

        private void hdBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mouseClick(sender);
        }

        private void kmBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mouseClick(sender);
        }

        private void tkBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mouseClick(sender);
        }
       
        private void accountBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mouseClick(sender);
        }
        #endregion
       
        #region mouseUp_events

        private void nvBorder_MouseUp(object sender, MouseButtonEventArgs e)
        {
            mouseLeave(sender);
            quanlynhanvienWPF.MainWindow  window = new quanlynhanvienWPF.MainWindow();
            window.Show();
        }

        private void khBorder_MouseUp(object sender, MouseButtonEventArgs e)
        {
            mouseLeave(sender);
            QuanLyKhachHangWPF .MainWindow window = new QuanLyKhachHangWPF.MainWindow();
            window.Show();
        }

        private void hhBorder_MouseUp(object sender, MouseButtonEventArgs e)
        {
            mouseLeave(sender);
            QuanLySanPham.MainWindow window = new QuanLySanPham.MainWindow();
            window.Show();
        }

        private void hdBorder_MouseUp(object sender, MouseButtonEventArgs e)
        {
            mouseLeave(sender);
            QuanLyHoaDon.MainWindow window = new QuanLyHoaDon.MainWindow();
            window.Show();
        }

        private void kmBorder_MouseUp(object sender, MouseButtonEventArgs e)
        {
            mouseLeave(sender);
            KhuyenMai.MainWindow window = new KhuyenMai.MainWindow();
            window.Show();
        }

        private void tkBorder_MouseUp(object sender, MouseButtonEventArgs e)
        {
            mouseLeave(sender);
            ThongKe.MainWindow window = new ThongKe.MainWindow();
            window.Show();
        }

        private void accountBorder_MouseUp(object sender, MouseButtonEventArgs e)
        {
            mouseLeave(sender);
            QuanLyTaiKhoan.MainWindow window = new QuanLyTaiKhoan.MainWindow();
            window.Show();
        }





        #endregion

        #endregion


    }
}
