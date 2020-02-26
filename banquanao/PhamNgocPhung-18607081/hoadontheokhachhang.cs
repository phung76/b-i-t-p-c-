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
    public partial class hoadontheokhachhang : Form
    {
        public hoadontheokhachhang()
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
                dgvhdkh.DataSource = dtaonam;
                dgvhdkh.AutoResizeColumns();

                
                daaonam = new SqlDataAdapter("select * from HoaDonKH", conn);

                daNhanVien = new SqlDataAdapter("select *from Khachhang", conn);
                dtNhanVien = new DataTable();
                dtNhanVien.Clear();
                daNhanVien.Fill(dtNhanVien);
            }
            catch (SqlException)
            {
                MessageBox.Show("không lấy được nội dung table .lỗi");
            }
        }
        private void hoadontheokhachhang_Load(object sender, EventArgs e)
        {
            loadData();

            this.cboKH.DataSource = dtNhanVien;
            cboKH.DisplayMember = "MaKH";
            cboKH.ValueMember = "MaKH";
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            
            if (cboKH.Text == "")
            {
                MessageBox.Show("Bạn phải chọn một mã hóa đơn để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboKH.Focus();
                return;
            }
            string kh = cboKH.Text;
            SqlDataAdapter a = new SqlDataAdapter("select * from HoaDonKH", phung);
            DataTable dttp = new DataTable("MaKH");
            a.Fill(dttp);
            DataView dwtp = new DataView(dttp);
            dgvhdkh.DataSource = dwtp;
            dwtp.RowFilter = " MaKH like'" + kh + "%'";
            dgvhdkh.DataSource = dwtp;
            int dem = 0;
            for (int i = 0; i < dgvhdkh.Rows.Count - 1; i++)
            {
                dem++;
            }

            txtsoluong.Text = dem.ToString();
        }

        private void btnreload_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void btntrove_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
