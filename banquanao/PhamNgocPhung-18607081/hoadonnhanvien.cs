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
    public partial class hoadonnhanvien : Form
    {
        public hoadonnhanvien()
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
                daaonam = new SqlDataAdapter("select *from HoaDonKH", conn);
                dtaonam = new DataTable();
                dtaonam.Clear();
                daaonam.Fill(dtaonam);
                dgvnhanvien.DataSource = dtaonam;
                dgvnhanvien.AutoResizeColumns();
                

                daaonam = new SqlDataAdapter("select * from HoaDonKH", conn);

                daNhanVien = new SqlDataAdapter("select *from NhanVien", conn);
                dtNhanVien = new DataTable();
                dtNhanVien.Clear();
                daNhanVien.Fill(dtNhanVien);
            }
            catch (SqlException)
            {
                MessageBox.Show("không lấy được nội dung table .lỗi");
            }
        }

        private void hoadonnhanvien_Load(object sender, EventArgs e)
        {
            loadData();

            int dem = 0;


            for (int i = 0; i < dgvnhanvien.Rows.Count - 1; i++)
            {
                dem++;
            }
            txttongnv.Text = dem.ToString();

            this.cboMaNV.DataSource = dtNhanVien;
            cboMaNV.DisplayMember = "MaNV";
            cboMaNV.ValueMember = "MaNV";


        }

        private void btnok_Click(object sender, EventArgs e)
        {

            if (cboMaNV.Text == "")
            {
                MessageBox.Show("Bạn phải chọn một mã hóa đơn để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaNV.Focus();
                return;
            }
            string kh = cboMaNV.Text;
            SqlDataAdapter a = new SqlDataAdapter("select * from HoaDonKH", phung);
            DataTable dttp = new DataTable("MaNV");
            a.Fill(dttp);
            DataView dwtp = new DataView(dttp);
            dgvnhanvien.DataSource = dwtp;
            dwtp.RowFilter = " MaNV like'" + kh + "%'";
            dgvnhanvien.DataSource = dwtp;
            int dem = 0;
            for (int i = 0; i < dgvnhanvien.Rows.Count - 1; i++)
            {
                dem++;
            }

            txttongnv.Text = dem.ToString();

        }

        private void btntrove_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnreload_Click(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
