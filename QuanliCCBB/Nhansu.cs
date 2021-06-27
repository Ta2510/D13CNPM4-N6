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
    public partial class Nhansu : Form
    {
        public Nhansu()
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
            cmd.CommandText = "select * from HSnhansu ";
            apt.SelectCommand = cmd;
            table.Clear();
            apt.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Nhansu_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(str);
            conn.Open();
            loaddata();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = "insert into HSnhansu values('" + txt_ma.Text + "','" + txt_ten.Text + "','" + cbb_ten.Text + "','" + cbb_gt.Text + "','" + txt_qq.Text + "','" + txt_ns.Text + "','" + txt_cmt.Text + "','" + txt_sdt.Text + "')";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Thêm thành công");
            loaddata();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = "update HSnhansu set mans = '" + txt_ma.Text + "',tenns = '" + txt_ten.Text + "',tencv = '" + cbb_ten.Text + "',gioitinh = '" + cbb_gt.Text + "',quequan ='" + txt_qq.Text + "',ngaysinh = '" + txt_ns.Text + "',cmt ='" + txt_cmt.Text + "',sdt ='" + txt_sdt.Text + "'  where  mans='" + txt_ma.Text + "'";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Sửa thành công");
            loaddata();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            cmd = conn.CreateCommand();
            cmd.CommandText = "delete from HSnhansu  where  mans='" + txt_ma.Text + "'";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Xóa thành công");
            loaddata();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView1.CurrentRow.Index;
            txt_ma.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txt_ten.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            cbb_ten.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            cbb_gt.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            txt_qq.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            txt_ns.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
            txt_cmt.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
            txt_sdt.Text = dataGridView1.Rows[i].Cells[7].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ChucNang cn = new ChucNang();
            cn.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = "select * from HSnhansu  where  gioitinh=N'" + cbb_gt.Text + "' ";
            apt.SelectCommand = cmd;
            table.Clear();
            apt.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Nhansu_Load(sender, e);
            txt_cmt.ResetText();
            txt_cmt.ResetText();
            txt_ns.ResetText();
            txt_qq.ResetText();
            txt_sdt.ResetText();
            txt_ten.ResetText();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {

        }
    }
}
