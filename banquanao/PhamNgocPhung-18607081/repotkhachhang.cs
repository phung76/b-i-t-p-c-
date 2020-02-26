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
    public partial class repotkhachhang : Form
    {
        public repotkhachhang()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=WIN10\\SQLEXPRESS;Initial Catalog=BanQuanAo;Integrated Security=True");


        SqlDataAdapter daSach = null;
        DataTable dtSach = null;
        private void repotkhachhang_Load(object sender, EventArgs e)
        {
           


            try
            {
                daSach = new SqlDataAdapter("Select * From KhachHang", conn);
                dtSach = new DataTable();
                dtSach.Clear();
                daSach.Fill(dtSach);
                CrystalReport3 rp = new CrystalReport3();
                rp.SetDataSource(dtSach);
                crystalReportViewer1.ReportSource = rp;

            }
            catch (SqlException)
            {
                MessageBox.Show("Không Lấy Được Dữ Liệu");
            }
        }

        private void btntim_Click(object sender, EventArgs e)
        {
            daSach = new SqlDataAdapter("Select * From KhachHang where MaKH like '%" + txttim.Text.ToString() + "%'", conn);
            dtSach = new DataTable();
            dtSach.Clear();
            daSach.Fill(dtSach);
            CrystalReport3 rp = new CrystalReport3();
            rp.SetDataSource(dtSach);
            crystalReportViewer1.ReportSource = rp;
        }
    }
}
