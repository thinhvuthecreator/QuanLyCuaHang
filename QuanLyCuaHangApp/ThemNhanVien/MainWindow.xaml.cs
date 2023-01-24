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
using SQL_Connection;
using Models;
using System.IO;
namespace ThemNhanVien
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
            loadControls();
            
        }

        #region methods

        void ganGiaTriNhanVien(NhanVien nv)
        {
            #region xuLyChuoiCombobox
            string[] chuoi = genderCombobox.SelectedValue.ToString().Split();
            string gioiTinh = chuoi[1];
            #endregion

            int sdt; 
            decimal luong;

            nv.TenNV = tenNVTxtbox.Text;
            nv.GioiTinh = gioiTinh;
            nv.SdtNV = int.TryParse(sdtNVTxtbox.Text, out sdt) == true ? sdt : 0;
            nv.SdtNV = Math.Abs(nv.SdtNV);
            nv.NgSinhNV = DateTime.Parse(ngsinhNVDatePicker.Text);
            nv.LuongNV = decimal.TryParse(luongTxtbox.Text, out luong) == true ? luong : 0;
            nv.LuongNV = Math.Abs(nv.LuongNV);
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

        void loadControls()
        {
            genderCombobox.SelectedIndex = 0;
            sdtNVTxtbox.Text = "0";
            luongTxtbox.Text = "0";
            ngsinhNVDatePicker.Text = "1/1/1900";
        }

        #endregion

        private void addImageBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog loadImage = new OpenFileDialog();
            if (loadImage.ShowDialog() == true)
            {
                FileInfo file = new FileInfo(loadImage.FileName);
                
                if(file.Extension == ".jpg" || file.Extension == ".JPG" || file.Extension == ".png" || file.Extension == ".PNG")
                {
                    string sourceAnh = loadImage.FileName;
                    string sourceAnhApp = System.IO.Path.GetFullPath(System.IO.Path.GetFileName(loadImage.FileName));
                    Uri fileUri = new Uri(sourceAnhApp);
                    System.IO.File.Copy(sourceAnh, sourceAnhApp, true);
                    loadimageImage.Source = new BitmapImage(fileUri);
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn file ảnh !");
                }


            }

        }

        private void huyBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void themNVBtn_Click(object sender, RoutedEventArgs e)
        {
            int sdt = 0;
            decimal luong = 0;         
            if (tenNVTxtbox.Text == "")
            {
                MessageBox.Show("Tên nhân viên bị để trống ! ");
            }
            else if(int.TryParse(sdtNVTxtbox.Text,out sdt) == false)
            {
                MessageBox.Show("Số điện thoại không hợp lệ !");
            }
            else if(decimal.TryParse(luongTxtbox.Text, out luong) == false)
            {
                MessageBox.Show("Lương nhân viên không hợp lệ !");
            }
            else if (DateTime.Parse(ngsinhNVDatePicker.ToString()) > DateTime.Now)
            {
                MessageBox.Show("Ngày sinh nhân viên không hợp lý !");
            }
            else
            {
                NhanVien nv = new NhanVien();
                ganGiaTriNhanVien(nv);
                if (NhanVien_DAL.themNhanVien(nv))
                {
                    MessageBox.Show("thêm thành công !");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("thêm thất bại !");

                }
            }

        }
    }
}
