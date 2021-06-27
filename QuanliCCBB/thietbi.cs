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

namespace QuanliCCBB
{
    public partial class thietbi : Form
    {
        public thietbi()
        {
            InitializeComponent();
        }
        SqlConnection conn;
        SqlCommand cmd;
        string str = @"Data Source=DESKTOP-P8ADKQ4\SQLEXPRESS;Initial Catalog=ChungcuBB;Integrated Security=True";
        SqlDataAdapter apt = new SqlDataAdapter();
        DataTable table = new DataTable();
        void loaddata()
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = "select * from thietbi ";
            apt.SelectCommand = cmd;
            table.Clear();
            apt.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void thietbi_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(str);
            conn.Open();
            loaddata();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = "select * from thietbi where manhap='" + txt_nhap.Text + "' ";
            apt.SelectCommand = cmd;
            table.Clear();
            apt.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = "insert into thietbi values '" + txt_nhap.Text + "','" + txt_tb.Text + "','" + txt_nn.Text + "','" + txt_gia.Text + "'";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Thêm thành công");
            loaddata();
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = "update thietbi set ttb = '" + txt_tb.Text + "',ngaynhap = '" + txt_nn.Text + "',gianhap = '" + txt_gia.Text + "' where manhap='" + txt_nhap.Text + "' ";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Sửa thành công");
            loaddata();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = "delete from thietbi  where  mans='" + txt_nhap.Text + "'";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Xóa thành công");
            loaddata();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView1.CurrentRow.Index;
            txt_nhap.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txt_tb.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txt_nn.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            txt_gia.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            ChucNang cn = new ChucNang();
            cn.Show();
            this.Hide();
        }

        private void btn_thoat_Click_1(object sender, EventArgs e)
        {
            ChucNang cn = new ChucNang();
            cn.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
