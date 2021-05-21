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
    public partial class Luongns : Form
    {
        public Luongns()
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
            cmd.CommandText = "select * from luongns ";
            apt.SelectCommand = cmd;
            table.Clear();
            apt.Fill(table);
            dataGridView1.DataSource = table;
        }
        private void getmans()
        {
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from HSnhansu", conn);
            SqlDataAdapter add = new SqlDataAdapter(cmd);
            DataSet lop = new DataSet();
            add.Fill(lop, "khoa");
            cbb_ma.DataSource = lop.Tables["khoa"];
            cbb_ma.DisplayMember = "mans";
            cbb_ma.ValueMember = "mans";
            conn.Close();
        }
        void getcv()
        {
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from HSnhansu where mans='" + cbb_ma.Text + "'", conn);
            SqlDataAdapter add = new SqlDataAdapter(cmd);
            DataSet lop = new DataSet();
            add.Fill(lop, "ta");
            cbb_ten.DataSource = lop.Tables["ta"];
            cbb_ten.DisplayMember = "tencv";
            cbb_ten.ValueMember = "tencv";
            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ChucNang cn = new ChucNang();
            cn.Show();
            this.Hide();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Luongns_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(str);
            conn.Open();
            getmans();
            getcv();
            loaddata();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = "insert into luongns values('" + txt_ma.Text + "','" + cbb_ma.Text + "','" + cbb_ten.Text + "','" + cbb_thang.Text + "','" + txt_cong.Text + "','" + txt_tiencong.Text + "','" + txt_luong.Text + "')";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Thêm thành công");
            loaddata();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = "update luongns set mans= '" + cbb_ma.Text + "',tencv ='" + cbb_ten.Text + "',thang ='" + cbb_thang.Text + "',cong ='" + txt_cong.Text + "',tiencong = '" + txt_tiencong.Text + "',tienluong = '" + txt_luong.Text + "' where maluong ='" + txt_ma.Text + "' ";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Sửa thành công");
            loaddata();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = "delete  from luongns where mahd='" + txt_ma.Text + "'";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Xóa thành công");
            loaddata();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView1.CurrentRow.Index;
            txt_ma.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            cbb_ma.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            cbb_ten.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            cbb_thang.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            txt_cong.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            txt_tiencong.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
            txt_luong.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = "select * from luongns where mans = '" + cbb_ma.Text + "' ";
            apt.SelectCommand = cmd;
            table.Clear();
            apt.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int cong = Convert.ToInt32(txt_cong.Text);
            int tiencong = Convert.ToInt32(txt_tiencong.Text);
            int luong = cong * tiencong;
            txt_luong.Text = luong.ToString();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Luongns_Load(sender, e);
            txt_ma.ResetText();
            txt_cong.ResetText();
            txt_luong.ResetText();
            txt_tiencong.ResetText();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            getcv();
        }
    }
}
