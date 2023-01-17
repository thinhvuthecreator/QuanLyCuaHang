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
            Grid thisGrid = sender as Grid;
            thisGrid.Background = tempGrid2.Background;
            foreach(Object ct in thisGrid.Children)
            {
                if(ct.GetType() == typeof(TextBlock))
                {
                    (ct as TextBlock).Foreground = Brushes.Black;
                }
            }
        }
        void mouseClick(object sender)
        {
            Grid thisGrid = sender as Grid;
            thisGrid.Background = Brushes.White;
            foreach (Object ct in thisGrid.Children)
            {
                if (ct.GetType() == typeof(TextBlock))
                {
                    (ct as TextBlock).Foreground = Brushes.Black;
                }
            }
        }
        void mouseLeave(object sender)
        {
            Grid thisGrid = sender as Grid;
            thisGrid.Background = tempGrid.Background;
            foreach (Object ct in thisGrid.Children)
            {
                if (ct.GetType() == typeof(TextBlock))
                {
                    (ct as TextBlock).Foreground = Brushes.DarkGray;
                }
            }
        }





        #endregion

        #region events

       

        #region mouseleave_mouseEnter_events
        private void nvIcon_MouseEnter(object sender, MouseEventArgs e)
        {
            mouseEnter(sender); 
        }
        private void nvIcon_MouseLeave(object sender, MouseEventArgs e)
        {
            mouseLeave(sender);
        }
          

        private void khIcon_MouseEnter(object sender, MouseEventArgs e)
        {
            mouseEnter(sender);
        }
        private void khIcon_MouseLeave(object sender, MouseEventArgs e)
        {
            mouseLeave(sender);
        }


        private void hhIcon_MouseEnter(object sender, MouseEventArgs e)
        {
            mouseEnter(sender);
        }
        private void hhIcon_MouseLeave(object sender, MouseEventArgs e)
        {
            mouseLeave(sender);
        }


        private void hdIcon_MouseEnter(object sender, MouseEventArgs e)
        {
            mouseEnter(sender);
        }
        private void hdIcon_MouseLeave(object sender, MouseEventArgs e)
        {
            mouseLeave(sender);
        }

      
        private void kmIcon_MouseEnter(object sender, MouseEventArgs e)
        {
            mouseEnter(sender);
        }
        private void kmIcon_MouseLeave(object sender, MouseEventArgs e)
        {
            mouseLeave(sender);
        }

      
        private void tkIcon_MouseEnter(object sender, MouseEventArgs e)
        {
            mouseEnter(sender);
        }
        private void tkIcon_MouseLeave(object sender, MouseEventArgs e)
        {
            mouseLeave(sender);
        }
        #endregion

        #region mouseDown_events
        private void nvIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mouseClick(sender);
        }
        private void khIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mouseClick(sender);
        }
        private void hhIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mouseClick(sender);
        }
        private void hdIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mouseClick(sender);
        }
        private void kmIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mouseClick(sender);
        }
        private void tkIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mouseClick(sender);
        }
        #endregion

        #region mouseUp_events
        private void nvIcon_MouseUp(object sender, MouseButtonEventArgs e)
        {
            mouseLeave(sender);
            quanlynhanvienWPF.MainWindow window = new quanlynhanvienWPF.MainWindow();
            window.Show();
        }
        private void khIcon_MouseUp(object sender, MouseButtonEventArgs e)
        {
            mouseLeave(sender);
            QuanLyKhachHangWPF.MainWindow window = new QuanLyKhachHangWPF.MainWindow();
            window.Show();
        }
        private void hhIcon_MouseUp(object sender, MouseButtonEventArgs e)
        {
            mouseLeave(sender);
            QuanLySanPham.MainWindow window = new QuanLySanPham.MainWindow();
            window.Show();
        }
        private void hdIcon_MouseUp(object sender, MouseButtonEventArgs e)
        {
            mouseLeave(sender);
            QuanLyHoaDon.MainWindow window = new QuanLyHoaDon.MainWindow();
            window.Show();
        }
        private void kmIcon_MouseUp(object sender, MouseButtonEventArgs e)
        {
            mouseLeave(sender);
            KhuyenMai.MainWindow window = new KhuyenMai.MainWindow();
            window.Show();
        }
        private void tkIcon_MouseUp(object sender, MouseButtonEventArgs e)
        {
            mouseLeave(sender);
            ThongKe.MainWindow window = new ThongKe.MainWindow();
            window.Show();
        }
        #endregion

        #endregion






    }
}
