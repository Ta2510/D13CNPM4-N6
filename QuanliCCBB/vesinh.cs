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
    public partial class Vesinh : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        string str = @"Data Source=DESKTOP-P8ADKQ4\SQLEXPRESS;Initial Catalog=ChungcuBB;Integrated Security=True";
        SqlDataAdapter apt = new SqlDataAdapter();
        DataTable table = new DataTable();
        void loaddata()
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = "select * from vesinh ";
            apt.SelectCommand = cmd;
            table.Clear();
            apt.Fill(table);
            dataGridView1.DataSource = table;
        }
        private void getp()
        {
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from phong", conn);
            SqlDataAdapter add = new SqlDataAdapter(cmd);
            DataSet lop = new DataSet();
            add.Fill(lop, "khoa");
            cbb_p.DataSource = lop.Tables["khoa"];
            cbb_p.DisplayMember = "tenphong";
            cbb_p.ValueMember = "tenphong";
            conn.Close();
        }
        public Vesinh()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void vesinh_Load(object sender, EventArgs e)
        {

            conn = new SqlConnection(str);
            conn.Open();
            getp();
            loaddata();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = "insert into vesinh values('" + txt_ma.Text + "','" + cbb_p.Text + "','" + cbb_thang.Text + "','" + txt_tien.Text + "')";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Thêm thành công");
            loaddata();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = "update vesinh set tenphong = '" + cbb_p.Text + "',thang = '" + cbb_thang.Text + "',tienvs = '" + txt_tien.Text + "' where mavs='" + txt_ma.Text + "'";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Sửa thành công");
            loaddata();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = "delete  from vesinh where mavs='" + txt_ma.Text + "'";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Xóa thành công");
            loaddata();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = "select * from vesinh where mavs= '" + txt_ma.Text + "'";
            apt.SelectCommand = cmd;
            table.Clear();
            apt.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView1.CurrentRow.Index;
            cbb_p.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txt_ma.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            cbb_thang.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            txt_tien.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ChucNang cn = new ChucNang();
            cn.Show();
            this.Hide();
        }
    }
}
