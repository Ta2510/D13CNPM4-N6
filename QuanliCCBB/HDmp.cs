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
using QuanliCCBB;

namespace quanlychungcu
{
    public partial class HDmp : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        string str = @"Data Source=DESKTOP-P8ADKQ4\SQLEXPRESS;Initial Catalog=ChungcuBB;Integrated Security=True";
        SqlDataAdapter apt = new SqlDataAdapter();
        DataTable table = new DataTable();
        void loaddata()
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = "select * from hopdongmua ";
            apt.SelectCommand = cmd;
            table.Clear();
            apt.Fill(table);
            dgv_hd.DataSource = table;
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
        private void getnm()
        {
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Nguoimua", conn);
            SqlDataAdapter add = new SqlDataAdapter(cmd);
            DataSet lop = new DataSet();
            add.Fill(lop, "khoa");
            cbb_nm.DataSource = lop.Tables["khoa"];
            cbb_nm.DisplayMember = "manm";
            cbb_nm.ValueMember = "manm";
            conn.Close();
        }

        public HDmp()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ChucNang cn = new ChucNang();
            cn.Show();
            this.Hide();
        }

        private void HDmp_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(str);
            conn.Open();
            getp();
            getnm();
            loaddata();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = "delete  from hopdongmua where mahd='" + txt_ma.Text + "'";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Xóa thành công");
            loaddata();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = "insert into hopdongmua values('" + cbb_p.Text + "','" + cbb_nm.Text + "','" + txt_nm.Text + "','" + txt_ma.Text + "')";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Thêm thành công");
            loaddata();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = "update hopdongmua set tenphong='" + cbb_p.Text + "', tennm='" + cbb_nm.Text + "',ngaymua ='" + txt_nm.Text + "' where mahd='" + txt_ma.Text + "' tenphong='" + cbb_p.Text + "'";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Sửa thành công");
            loaddata();
        }

        private void dgv_hd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgv_hd.CurrentRow.Index;
            cbb_p.Text = dgv_hd.Rows[i].Cells[0].Value.ToString();
            cbb_nm.Text = dgv_hd.Rows[i].Cells[1].Value.ToString();
            txt_nm.Text = dgv_hd.Rows[i].Cells[2].Value.ToString();
            txt_ma.Text = dgv_hd.Rows[i].Cells[3].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = "select * from hopdongmua  where mahd='" + txt_ma.Text + "' ";
            apt.SelectCommand = cmd;
            table.Clear();
            apt.Fill(table);
            dgv_hd.DataSource = table;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            HDmp_Load(sender, e);
            txt_ma.ResetText();
            txt_nm.ResetText();
        }
    }
}
