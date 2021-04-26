using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QuanliCCBB.Properties;

namespace QuanliCCBB
{
    public partial class Form1 : Form
    {
        SqlConnection conn;
        //    SqlCommand cmd;
        string str = @"Data Source=DESKTOP-P8ADKQ4\SQLEXPRESS;Initial Catalog=ChungcuBB;Integrated Security=True";
        //SqlDataAdapter apt = new SqlDataAdapter();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(str);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from Quanly where taikhoan ='" + txt_tk.Text + "'and matkhau='" + txt_mk.Text + "'", conn);
            int x = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            conn.Close();
            if (x == 1)
            {
                MessageBox.Show("Đăng Nhập Thành Công");
                ChucNang cn = new ChucNang();
                cn.Show();
            }
            else
            {
                MessageBox.Show("Đăng Nhập Không Thành Công" +
                    "Mời Nhập Lại");
            }
            this.Hide();
        }
    }
}
