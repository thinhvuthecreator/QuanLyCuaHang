using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThiThucHanh
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listView1.View = View.Details;
            listView1.Columns.Add("Tên khách hàng");
            listView1.Columns.Add("Địa chỉ");
            listView1.Columns.Add("Nghề nghiệp");
            listView1.Columns.Add("Số lượng vé");
            listView1.Columns.Add("Đơn giá");
            listView1.Columns.Add("Thành tiền");
            listView1.Columns.Add("Thuế VAT");
            listView1.Columns.Add("Giảm giá");
            listView1.Columns.Add("Tổng tiền");


        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult decision = MessageBox.Show("Bạn có chắc chắn muốn thoát không ?", "", MessageBoxButtons.YesNo);
            if (decision == DialogResult.Yes)
            {

            }
            else
            {
                
                   
            } // không làm gì
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListViewItem item = new ListViewItem();
            if (textBox1.Text == "" || textBox2.Text == "" || textBox4.Text == "" || textBox5.Text == "" || (sinhvienRadioButton.Checked == false && khacRadioButton.Checked == false))
            {
                MessageBox.Show("Dữ liệu Không được để trống !");
            }
            else
            {
                item.Text = textBox1.Text;
                item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = textBox2.Text });
                item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = sinhvienRadioButton.Checked == true ? sinhvienRadioButton.Text : khacRadioButton.Text });
                item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = textBox4.Text });
                item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = textBox5.Text });
                item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = textBox6.Text });
                item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = textBox7.Text });
                item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = textBox8.Text });
                item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = textBox9.Text });

                listView1.Items.Add(item);
                
            }
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
           try
            {
                if (textBox5.Text == "")
                {
                    int soLuongVe = int.Parse(textBox4.Text);
                }
                else
                {
                    int soLuongVe = int.Parse(textBox4.Text);
                    textBox6.Text = (int.Parse(textBox4.Text) * int.Parse(textBox5.Text)).ToString();
                }

            }
            catch
            {
                MessageBox.Show("vui lòng nhập số cho cả đơn giá và số lượng vé !");
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

            try
            {
                int soLuongVe = int.Parse(textBox5.Text);
                textBox6.Text = (int.Parse(textBox4.Text) * int.Parse(textBox5.Text)).ToString();
            }
               
            catch
            {
                MessageBox.Show("vui lòng nhập số cho cả đơn giá và số lượng vé !");
            }

            
        }
    }
}
