using quanlychungcu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanliCCBB
{
    public partial class ChucNang : Form
    {
        public ChucNang()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ttphong p = new Ttphong();
            p.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            qldien qldien = new qldien();
            qldien.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            qlnuoc nuoc = new qlnuoc();
            nuoc.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HDmp hd = new HDmp();
            hd.Show();

        }

        private void button9_Click(object sender, EventArgs e)
        {
            thietbi tb = new thietbi();
            tb.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            guixe gx = new guixe();
            gx.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Nhansu ns = new Nhansu();
            ns.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Luongns luong = new Luongns();
            luong.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Vesinh vs = new Vesinh();
            vs.Show();
        }
    }
}
