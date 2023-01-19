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

namespace MenuNhanVienWPF
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
      

        #region events_KH
        private void khBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mouseClick(sender);
        }
        private void khBorder_MouseEnter(object sender, MouseEventArgs e)
        {
            mouseEnter(sender);
        }
        private void khBorder_MouseUp(object sender, MouseButtonEventArgs e)
        {
            mouseLeave(sender);
            KhachHangNhanVien.MainWindow window = new KhachHangNhanVien.MainWindow();
            window.Show();
        }
        private void khBorder_MouseLeave(object sender, MouseEventArgs e)
        {
            mouseLeave(sender);
        }

        #endregion

        #region events_HD
        private void hdBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mouseClick(sender);
        }

        private void hdBorder_MouseEnter(object sender, MouseEventArgs e)
        {
            mouseEnter(sender);
        }

        private void hdBorder_MouseLeave(object sender, MouseEventArgs e)
        {
            mouseLeave(sender);
        }

        private void hdBorder_MouseUp(object sender, MouseButtonEventArgs e)
        {
            mouseLeave(sender);
            HoaDonNhanVien.MainWindow window = new HoaDonNhanVien.MainWindow();
            window.Show();
        }
        #endregion

      
    }
}
