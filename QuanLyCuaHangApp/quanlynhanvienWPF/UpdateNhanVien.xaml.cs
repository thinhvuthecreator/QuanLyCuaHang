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
using Models;
using SQL_Connection;
using Microsoft.Win32;
using System.IO;

namespace quanlynhanvienWPF
{
    /// <summary>
    /// Interaction logic for UpdateNhanVien.xaml
    /// </summary>
    public partial class UpdateNhanVien : Window
    {
        public UpdateNhanVien()
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

            int sdt, luong;
            nv.MaNV = int.Parse(MaNVTxtbox.Text);
            nv.TenNV = tenNVTxtbox.Text;
            nv.GioiTinh = gioiTinh;
            nv.SdtNV = int.TryParse(sdtNVTxtbox.Text, out sdt) == true ? sdt : 0;
            nv.SdtNV = Math.Abs(nv.SdtNV);
            nv.NgSinhNV = DateTime.Parse(ngsinhNVDatePicker.Text);
            nv.LuongNV = int.TryParse(luongTxtbox.Text, out luong) == true ? luong : 0;
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
            sdtNVTxtbox.Text = "0";
            luongTxtbox.Text = "0";          
            genderCombobox.SelectedIndex = 0;
        }

        #endregion

        #region events

        

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
                    System.IO.File.Copy(sourceAnh, sourceAnhApp, true);
                    Uri fileUri = new Uri(sourceAnhApp);
                    loadimageImage.Source = new BitmapImage(fileUri);
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn file ảnh !");
                }


              


            }
        }

        private void updateNVBtn_Click(object sender, RoutedEventArgs e)
        {
            int sdt;
            decimal luong;
            if (tenNVTxtbox.Text == "")
            {
                MessageBox.Show("Tên nhân viên bị bỏ trống ! ");
            }
            else if(decimal.TryParse(luongTxtbox.Text,out luong) == false)
            {
                MessageBox.Show("Lương nhân viên không hợp lệ !");
            }
            else if (int.TryParse(sdtNVTxtbox.Text, out sdt) == false)
            {
                MessageBox.Show("Số điện thoại không hợp lệ !");
            }
            else if (DateTime.Parse(ngsinhNVDatePicker.ToString()) > DateTime.Now)
            {
                MessageBox.Show("Ngày sinh nhân viên không hợp lý !");
            }
            else
            {


                NhanVien nv = new NhanVien();
                ganGiaTriNhanVien(nv);
                if (NhanVien_DAL.updateNhanVien(nv))
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

        private void huyBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
