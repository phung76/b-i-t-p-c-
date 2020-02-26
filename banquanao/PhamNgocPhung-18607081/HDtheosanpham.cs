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

namespace PhamNgocPhung_18607081
{
    public partial class HDtheosanpham : Form
    {
        public HDtheosanpham()
        {
            InitializeComponent();
        }
        string phung = @"Data Source=WIN10\SQLEXPRESS;Initial Catalog=BanQuanAo;Integrated Security=True";
        SqlConnection conn = null;
        SqlDataAdapter daaonam = null;
        DataTable dtaonam = null;

        SqlDataAdapter daNhanVien = null;
        DataTable dtNhanVien = null;

        bool them;
        void loadData()
        {
            try
            {
                conn = new SqlConnection(phung);
                daaonam = new SqlDataAdapter("select *from ChiTietHoaDon", conn);
                dtaonam = new DataTable();
                dtaonam.Clear();
                daaonam.Fill(dtaonam);
                dgvhdtkh.DataSource = dtaonam;
                dgvhdtkh.AutoResizeColumns();


                daaonam = new SqlDataAdapter("select * from ChiTietHoaDon", conn);

                daNhanVien = new SqlDataAdapter("select *from AoNam", conn);
                dtNhanVien = new DataTable();
                dtNhanVien.Clear();
                daNhanVien.Fill(dtNhanVien);
            }
            catch (SqlException)
            {
                MessageBox.Show("không lấy được nội dung table .lỗi");
            }
        }
        private void HDtheokhachhang_Load(object sender, EventArgs e)
        {
            loadData();

            this.cbosanpham.DataSource = dtNhanVien;
            cbosanpham.DisplayMember = "MaAo";
            cbosanpham.ValueMember = "MaAo";

            int n;
            int dem = 0;
            for (int i = 0; i < dgvhdtkh.Rows.Count - 1; i++)
            {
                dem++;
            }
              txttong.Text = dem.ToString();
        }

        private void btnok_Click(object sender, EventArgs e)
        {

            if (cbosanpham.Text == "")
            {
                MessageBox.Show("Bạn phải chọn một mã hóa đơn để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbosanpham.Focus();
                return;
            }
            string kh = cbosanpham.Text;
            SqlDataAdapter a = new SqlDataAdapter("select * from ChiTietHoaDon", phung);
            DataTable dttp = new DataTable("MaAo");
            a.Fill(dttp);
            DataView dwtp = new DataView(dttp);
            dgvhdtkh.DataSource = dwtp;
            dwtp.RowFilter = " MaAo like'" + kh + "%'";
            dgvhdtkh.DataSource = dwtp;
            int dem = 0;
            for (int i = 0; i < dgvhdtkh.Rows.Count - 1; i++)
            {
                dem++;
            }
            txttong.Text = dem.ToString();
        }

        private void btnreload_Click(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
