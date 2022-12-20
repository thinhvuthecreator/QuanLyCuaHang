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
using System.Data;
using System.Data.SqlClient;

namespace QuanLySanPham
{
    /// <summary>
    /// Interaction logic for ThongTinSanPham.xaml
    /// </summary>
    public partial class ThongTinSanPham : Window
    {
        public ThongTinSanPham()
        {
            InitializeComponent();
            loadLoaiSPCombobox();
        }

        #region methods      
        void loadLoaiSPCombobox()
        {
            DataTable LoaiSPSource = LoaiSanPham_DAL.loadDuLieuLOAISP();
            foreach (DataRow data in LoaiSPSource.Rows)
            {
                loaiSPcombobox.Items.Add(data[1]);
            }
        }
        #endregion


        #region events
        #endregion

    }
}
