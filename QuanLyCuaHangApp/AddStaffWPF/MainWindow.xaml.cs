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
using Models;
using SQL_Connection;

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
            loadImages();
        }

        #region methods

        void ganGiaTriNhanVien(NhanVien nv)
        {
            #region xuLyChuoiCombobox
            string[] chuoi = genderCombobox.SelectedValue.ToString().Split();
            string gioiTinh = chuoi[1];
            #endregion

            int sdt, luong;
          
            nv.TenNV = tenNVTxtbox.Text;
            nv.GioiTinh = gioiTinh;
            nv.SdtNV = int.TryParse(sdtNVTxtbox.Text,out sdt) == true ? sdt : 0;
            nv.NgSinhNV = DateTime.Parse(ngsinhNVDatePicker.Text);
            nv.LuongNV = int.TryParse(luongTxtbox.Text, out luong) == true ? luong : 0;
            nv.FileAnh = loadimageImage.Source.ToString();
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
            OpenFileDialog loadImage = new OpenFileDialog();
            if(loadImage.ShowDialog() == true)
            {
                

                string sourceAnh = loadImage.FileName;
                string sourceAnhApp = System.IO.Path.GetFullPath(System.IO.Path.GetFileName(loadImage.FileName));
                System.IO.File.Copy(sourceAnh, sourceAnhApp, true);
                Uri fileUri = new Uri(sourceAnhApp);
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
            ganGiaTriNhanVien(nv);      
            if(NhanVien_DAL.themNhanVien(nv))
            {
                MessageBox.Show("thêm thành công !");
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
