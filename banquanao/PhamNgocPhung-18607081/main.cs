using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhamNgocPhung_18607081
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        void login()
        {
            new Form2().ShowDialog();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            login();
        }

        private void thoátToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void danhMụcKháchHàngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form frm = new khachhang();

            frm.ShowDialog();
        }

        private void quảnLíNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new nhanvien();
         
            frm.ShowDialog();
        }

        private void quảnLíKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new hoadontheokhachhang();
            frm.ShowDialog();
        }

        private void quảnLíNhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // Form frm = new nhacungcap();
           // frm.ShowDialog();
        }

        private void quảnLíSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new HDtheosanpham();
            frm.ShowDialog();

        }

        private void hóaDơnBánQuầnÁoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new HoaDon();
            form.ShowDialog();

        }

        private void quảnLíHóaDơnToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form form = new HoaDon();
            form.ShowDialog();

        }

        private void xemDanhMụcToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        void xemdanhmuc(int intDanhMuc)
        {
            Form form = new danhmuc();
            form.Text = intDanhMuc.ToString();
            form.Show();
        }

        private void danhMụcKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            xemdanhmuc(1);
        }

        private void danhMụcNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            xemdanhmuc(2);
        }

        private void danhMụcSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            xemdanhmuc(3);
        }

        private void danhMụcHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            xemdanhmuc(4);
        }

        private void xemDanhMucHóaĐơnKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            xemdanhmuc(5);
        }

        private void xemDanhMụcHóaĐơnNhàCungCâpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            xemdanhmuc(6);
        }

        private void danhMụcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new aonam();
            form.ShowDialog();

        }

        private void danhMụcNhânViênToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form form = new nhanvien();
            form.ShowDialog();
        }

        private void danhMụcHóaĐơnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           // Form form = new nhacungcap();
           // form.ShowDialog();
        }

        private void phiếuNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // Form form = new PhieuNhap();
            //form.ShowDialog();
        }

        private void nhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form form = new HDNhacungcap();
            form.ShowDialog();
        }

        private void hóaĐơnTheoNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new hoadonnhanvien();
            form.ShowDialog();
        }

        private void hóaĐơnKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new repothoadon();
            form.ShowDialog();
        }

        private void danhSáchKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new repotkhachhang();
            form.ShowDialog();
        }

        private void danhSachNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new repotnhanvien();
            form.ShowDialog();
        }

        private void chiTiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new chitiethoadon();
            form.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
