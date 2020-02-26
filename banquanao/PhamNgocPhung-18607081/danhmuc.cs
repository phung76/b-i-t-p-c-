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
    public partial class danhmuc : Form
    {
        public danhmuc()
        {
            InitializeComponent();
        }
        string phung = @"Data Source=WIN10\SQLEXPRESS;Initial Catalog=BanQuanAO;Integrated Security=True";
        SqlConnection conn = null;
        SqlDataAdapter daTabale = null;
        DataTable dtTable = null;

        private void btntrove_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void danhmuc_Load(object sender, EventArgs e)
        {

            try
            {
                conn = new SqlConnection(phung);
                int intDM = Convert.ToInt32(this.Text);
                switch (intDM)
                {
                    case 1:
                        lbdanhmuc.Text = "khach hang";
                        daTabale = new SqlDataAdapter("select MaKH,TenKH,DiaChi,Sdt from KhachHang", conn);
                        break;
                    case 2:
                        lbdanhmuc.Text = "Nhân viên ";
                        daTabale = new SqlDataAdapter("select MaNV,HoNV,TenNV from NhanVien", conn);
                        break;
                    case 3:
                        lbdanhmuc.Text = "Áo Nam";
                        daTabale = new SqlDataAdapter("select MaAO,TenAO,DonViTinh,DonGia from AoNam", conn);
                        break;
                    case 4:
                        lbdanhmuc.Text = "nhà cung cấp";
                        daTabale = new SqlDataAdapter("select MaNCC,TenNCC,DiaChi,Sdt From NhaCungCap", conn);
                        break;
                    case 5:
                        lbdanhmuc.Text = "Hóa Đơn ";
                        daTabale = new SqlDataAdapter("select MaHD,MaKH,MaNV,MaAo from HoaDonKH", conn);
                        break;
                    case 6:
                        lbdanhmuc.Text = "Hóa Đơn nhà cung cấp";
                        daTabale = new SqlDataAdapter("select* from HoaDonNCC", conn);
                        break;
                }
                dtTable = new DataTable();
                dtTable.Clear();
                daTabale.Fill(dtTable);
                dgvdanhmuc.DataSource = dtTable;
                dgvdanhmuc.AutoResizeColumns();
            }
            catch (SqlException)
            {
                MessageBox.Show("không lấy dược nội dung trong table", "lỗi!!");

            }
        }
    }
}

