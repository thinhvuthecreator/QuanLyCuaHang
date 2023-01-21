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
using System.Windows.Shapes;
using SQL_Connection;
using Models;
using Microsoft.Win32;
using System.IO;

namespace QuanLyKhachHangWPF
{
    /// <summary>
    /// Interaction logic for UpdateKhachHang.xaml
    /// </summary>
    public partial class UpdateKhachHang : Window
    {
        public UpdateKhachHang()
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

            kh.MaKH = int.Parse(MaKHTxtbox.Text);
            kh.TenKH = tenKHTxtbox.Text;
            kh.SdtKH = int.TryParse(sdtKHTxtbox.Text, out sdtKH) == true ? sdtKH : -1;
            kh.SdtKH = Math.Abs(kh.SdtKH);
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
        void loadControls()
        {
            genderCombobox.SelectedIndex = 0;
            sdtKHTxtbox.Text = "0";
         
        }

        #endregion

        #region events


        private void addImageBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog loadKHImage = new OpenFileDialog();

            if (loadKHImage.ShowDialog() == true)
            {

                FileInfo file = new FileInfo(loadKHImage.FileName);

                if (file.Extension == ".jpg" || file.Extension == ".JPG" || file.Extension == ".png" || file.Extension == ".PNG")
                {
                    string sourceAnh = loadKHImage.FileName;
                    string sourceAnhApp = System.IO.Path.GetFullPath(System.IO.Path.GetFileName(loadKHImage.FileName));
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

        private void upDateKHBtn_Click(object sender, RoutedEventArgs e)
        {
            int sdt;

            if (tenKHTxtbox.Text == "")
            {
                MessageBox.Show("Tên khách hàng bị bỏ trống ! ");
            }
            else if (int.TryParse(sdtKHTxtbox.Text, out sdt) == false)
            {
                MessageBox.Show("Số điện thoại không hợp lệ !");
            }
            else if(DateTime.Parse(ngsinhKHDatePicker.ToString()) > DateTime.Now)
            {
                MessageBox.Show("Ngày sinh khách hàng không hợp lý !");
            }
            else
            {
                KhachHang kh = new KhachHang();
                ganDuLieuKH(kh);
                if (KhachHang_DAL.updateKhachHang(kh))
                {
                    MessageBox.Show("Cập nhật thành công !");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại !");
                }
            }
        }

        #endregion

    }
}
