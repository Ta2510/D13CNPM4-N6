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
    public partial class guixe : Form
    {
        public guixe()
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
            cmd.CommandText = "select * from guixe ";
            apt.SelectCommand = cmd;
            table.Clear();
            apt.Fill(table);
            dataGridView1.DataSource = table;
        }
        private void getnm()
        {
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Nguoimua", conn);
            SqlDataAdapter add = new SqlDataAdapter(cmd);
            DataSet lop = new DataSet();
            add.Fill(lop, "khoa");
            cbb_ma.DataSource = lop.Tables["khoa"];
            cbb_ma.DisplayMember = "manm";
            cbb_ma.ValueMember = "manm";
            conn.Close();
        }
      

        private void guixe_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(str);
            conn.Open();
            getnm();
            loaddata();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            ChucNang cn = new ChucNang();
            cn.Show();
            this.Hide();
        }

        private void btn_find_Click(object sender, EventArgs e)
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = "select * from guixe where maguixe ='" + txt_ma.Text + "' ";
            apt.SelectCommand = cmd;
            table.Clear();
            apt.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            guixe_Load(sender, e);
            txt_ma.ResetText();
            cbb_ma.ResetText();
            cbb_loai.ResetText();
            cbb_thang.ResetText();
            txt_gia.ResetText();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = "insert into guixe values('" + txt_ma.Text + "','" + cbb_ma.Text + "','" + cbb_loai.Text + "','" + txt_gia.Text + "','" + cbb_thang.Text + "')";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Thêm thành công");
            loaddata();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = "update guixe set manm = '" + cbb_ma.Text + "',loaixe = '" + cbb_loai.Text + "',gia = '" + txt_gia.Text + "',thang = '" + cbb_thang.Text + "' where maguixe='" + txt_ma.Text + "'";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Sửa thành công");
            loaddata();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = "delete  from guixe where maguixe='" + txt_ma.Text + "'";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Xóa thành công");
            loaddata();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView1.CurrentRow.Index;
            cbb_ma.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txt_ma.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            cbb_thang.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            cbb_loai.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            txt_gia.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            ChucNang cn = new ChucNang();
            cn.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
