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
    public partial class qlnuoc : Form
    {
        public qlnuoc()
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
            cmd.CommandText = "select * from hdnuoc ";
            apt.SelectCommand = cmd;
            table.Clear();
            apt.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = "insert into hdnuoc values('" + txt_ma.Text + "','" + cbb_phong.Text + "','" + cbb_thang.Text + "','" + txt_sodien.Text + "','" + txt_tiendien.Text + "')";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Thêm thành công");
            loaddata();

        }
        private void getp()
        {
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from phong", conn);
            SqlDataAdapter add = new SqlDataAdapter(cmd);
            DataSet lop = new DataSet();
            add.Fill(lop, "khoa");
            cbb_phong.DataSource = lop.Tables["khoa"];
            cbb_phong.DisplayMember = "tenphong";
            cbb_phong.ValueMember = "tenphong";
            conn.Close();
        }

        private void qlnuoc_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(str);
            conn.Open();
            getp();
            loaddata();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = "update hdnuoc set tenphong='" + cbb_phong.Text + "',khoinuoc='" + txt_sodien.Text + "',thang ='" + cbb_thang.Text + "', tiennuoc ='" + txt_tiendien.Text + "'  where  mahd='" + txt_ma.Text + "'";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Sửa thành công");
            loaddata();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = "delete from hddien  where  mahd = '" + txt_ma.Text + "'";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Xóa thành công");
            loaddata();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = "select * from hddien  where  mahd='" + txt_ma.Text + "'";
            //cmd.ExecuteNonQuery();
            apt.SelectCommand = cmd;
            table.Clear();
            apt.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ChucNang cn = new ChucNang();
            cn.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView1.CurrentRow.Index;
            txt_ma.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            cbb_phong.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            cbb_thang.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            txt_sodien.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            txt_dongia.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            txt_tiendien.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int sodien = Convert.ToInt32(txt_sodien.Text);
            int dongia = Convert.ToInt32(txt_dongia.Text);
            int tiendien = sodien * dongia;
            txt_tiendien.Text = tiendien.ToString();
        }
    }
}
